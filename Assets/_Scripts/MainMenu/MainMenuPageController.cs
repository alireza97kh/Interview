using Defective.JSON;
using Dobeil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPageController : DobeilPageBase
{
	[SerializeField] private string baseUrl = "https://baghenegar.ir/api/ChampionsLeague/TopUserMedals";
	[SerializeField] private ProfileManager profileManager;
	private List<Member> leaderBoardMemebers;
	protected override void ShowPage(object data = null)
	{
		GameData.Instance.baseUrl = baseUrl;
		profileManager.Init();
		LoadingManager.Instance.HideLoading();
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
			GameData.Instance.playerProfile = new PlayerProfileClass();
			GameData.Instance.playerProfile.firstLoginTime = DateTime.Now;
			SaveManager<PlayerProfileClass>.SaveData(SaveManagerKeys.PlayerProfile.ToString(), GameData.Instance.playerProfile);
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
		for (int i = 0; i < VisualData.Instance.DailyRewardData.dailyRewards.Count; i++)
		{
			VisualData.Instance.DailyRewardData.dailyRewards[i].avaiableDate =
				GameData.Instance.playerProfile.firstLoginTime.AddHours(i * VisualData.Instance.DailyRewardData.hoursOfDay);

			VisualData.Instance.DailyRewardData.dailyRewards[i].received = (i < GameData.Instance.playerProfile.lastRewardIndex);
		}
	}

}
