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
		DobeilGameServiceBase.Instance.SendRequest(
			baseUrl,
			Dobeil.SendRequestMethods.GET,
			callback: (result) =>
			{
				Debug.Log(result);
				if (String.IsNullOrEmpty(result.Error))
				{
					leaderBoardMemebers = new List<Member>();
					JSONObject leaderBoardData = JSONObject.Create(result.Text);
					for (int i = 0; i < leaderBoardData.GetField("Members").count; i++)
						leaderBoardMemebers.Add(GetMember(leaderBoardData.GetField("Members")[i]));
				}
			});
		profileManager.Init();
	}

	private Member GetMember(JSONObject memberData)
	{
		Member member = new Member()
		{
			UserId = int.Parse(memberData.GetField("UserId").ToString()),
			AvatarIndex = int.Parse(memberData.GetField("AvatarIndex").ToString()),
			FrameIndex = int.Parse(memberData.GetField("FrameIndex").ToString()),
			Username = DobeilHelper.Instance.StripQuote(memberData.GetField("Username").ToString()),
			GoldMedals = int.Parse(memberData.GetField("GoldMedals").ToString()),
			SilverMedals = int.Parse(memberData.GetField("SilverMedals").ToString()),
			BronzeMedals = int.Parse(memberData.GetField("BronzeMedals").ToString())
		};
		return member;
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
			SaveManager<PlayerProfileClass>.SaveData(SaveManagerKeys.PlayerProfile.ToString(), GameData.Instance.playerProfile);
		}
		Debug.Log(GameData.Instance.playerProfile.playerName);
	}

	public void LeaderBoardBtnClick()
	{
		DobeilPageManager.Instance.ShowPageByName("LeaderBoardPopUp", true, leaderBoardMemebers);
	}
	
}
