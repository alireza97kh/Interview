using Dobeil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LeaderBoardPopUpController : DobeilPageBase
{

	[SerializeField] private LeaderBoardScrollRectController leaderBoardScroller;
	protected override void HidePage(object data = null)
	{
		
	}

	protected override void SetPageEvents()
	{
		
	}

	protected override void SetPageProperty()
	{
		
	}

	protected override void ShowPage(object data = null)
	{
		if (data is List<Member>)
		{
			leaderBoardScroller.Init(data as List<Member>);
		}
	}
}
