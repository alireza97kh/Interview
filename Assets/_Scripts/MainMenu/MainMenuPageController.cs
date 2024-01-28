using Defective.JSON;
using Dobeil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPageController : DobeilPageBase
{
	[SerializeField] private string baseUrl = "https://baghenegar.ir/api/ChampionsLeague/TopUserMedals";
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
	}

	private Member GetMember(JSONObject memberData)
	{
		Member member = new Member()
		{
			UserId = int.Parse(memberData.GetField("UserId").ToString()),
			AvatarIndex = int.Parse(memberData.GetField("AvatarIndex").ToString()),
			FrameIndex = int.Parse(memberData.GetField("FrameIndex").ToString()),
			Username = memberData.GetField("Username").ToString(),
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
		
	}

	public void LeaderBoardBtnClick()
	{
		DobeilPageManager.Instance.ShowPageByName("LeaderBoardPopUp", true, leaderBoardMemebers);
	}
	
}
