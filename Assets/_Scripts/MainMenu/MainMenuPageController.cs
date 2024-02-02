using Defective.JSON;
using Dobeil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPageController : DobeilPageBase
{
	[SerializeField] private string baseUrl = "https://baghenegar.ir/api/ChampionsLeague/TopUserMedals";
	[SerializeField] private ProfileManager profileManager;
	protected override void ShowPage(object data = null)
	{
		GameData.Instance.baseUrl = baseUrl;
		profileManager.Init();
		LoadingManager.Instance.HideLoading();

		if (GameData.Instance.playerProfile.lastRewardIndex == VisualData.Instance.DailyRewardData.dailyRewards.Count)
			UpdateDailyRewardData();
	}

	

	protected override void HidePage(object data = null)
	{
		
	}

	protected override void SetPageEvents()
	{
		
	}

	protected override void SetPageProperty()
	{
		GameData.Instance.playerProfile = SaveManager<PlayerProfileClass>.LoadData(SaveManagerKeys.PlayerProfile.ToString());
		if (GameData.Instance.playerProfile == null)
		{
			SavePlayerProfile(new PlayerProfileClass());
		}
		UpdateDailyRewardData();
	}

	public void LeaderBoardBtnClick()
	{
		DobeilPageManager.Instance.ShowPageByName("LeaderBoardPopUp", true);
	}

	public void DailyRewardBtnClick()
	{
		DobeilPageManager.Instance.ShowPageByName("DailyRewardPopUp", true);
	}
	private void UpdateDailyRewardData()
	{
		if (GameData.Instance.playerProfile.lastRewardIndex < VisualData.Instance.DailyRewardData.dailyRewards.Count)
		{
			for (int i = 0; i < VisualData.Instance.DailyRewardData.dailyRewards.Count; i++)
			{
				DateTime _lastLoginTime = DateTime.ParseExact(GameData.Instance.playerProfile.firstLoginTime, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
				VisualData.Instance.DailyRewardData.dailyRewards[i].avaiableDate =
					_lastLoginTime.AddHours(i * VisualData.Instance.DailyRewardData.hoursOfDay);

				VisualData.Instance.DailyRewardData.dailyRewards[i].received = (i < GameData.Instance.playerProfile.lastRewardIndex);
			}
		}
		else
		{
			//Reset Daily Rewards
			SavePlayerProfile(
				new PlayerProfileClass(
					GameData.Instance.playerProfile.playerName, 
					GameData.Instance.playerProfile.coin, 
					GameData.Instance.playerProfile.gem, 
					0));

		}
	}

	private void SavePlayerProfile(PlayerProfileClass profile)
	{
		GameData.Instance.playerProfile = profile;
		GameData.Instance.playerProfile.firstLoginTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
		SaveManager<PlayerProfileClass>.SaveData(SaveManagerKeys.PlayerProfile.ToString(), GameData.Instance.playerProfile);
	}

}
