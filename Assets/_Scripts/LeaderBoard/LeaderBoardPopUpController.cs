using Defective.JSON;
using Dobeil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LeaderBoardPopUpController : DobeilPageBase
{

	[SerializeField] private LeaderBoardScrollRectController leaderBoardScroller;
	private List<Member> leaderBoardMemebers;
	protected override void HidePage(object data = null)
	{
		
	}

	protected override void SetPageEvents()
	{
		
	}

	protected override void SetPageProperty()
	{
		leaderBoardMemebers = new List<Member>();
	}

	protected override void ShowPage(object data = null)
	{
		if (leaderBoardMemebers.Count == 0)
		{
			LoadingManager.Instance.ShowLoading();
			GetLeaderBoardData();
		}
	}

	private async void GetLeaderBoardData()
	{
		await DobeilGameServiceBase.Instance.SendRequestAsync(
			GameData.Instance.baseUrl,
			Dobeil.SendRequestMethods.GET,
			callback: (result) =>
			{
				if (String.IsNullOrEmpty(result.Error))
				{
					JSONObject leaderBoardData = JSONObject.Create(result.Text);
					for (int i = 0; i < leaderBoardData.GetField("Members").count; i++)
						leaderBoardMemebers.Add(GetMember(leaderBoardData.GetField("Members")[i]));

					leaderBoardScroller.Init(leaderBoardMemebers);
				}
				LoadingManager.Instance.HideLoading();
			});
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
}
