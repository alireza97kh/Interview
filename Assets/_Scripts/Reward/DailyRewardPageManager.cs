using Dobeil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardPageManager : DobeilPageBase
{
	private List<DailyRewardClass> dailyRewards = new List<DailyRewardClass>();
	private int lastReceivedIndex = -1;

	[SerializeField] private Transform content;
	protected override void ShowPage(object data = null)
	{
		lastReceivedIndex = SaveManager<int>.LoadData(SaveManagerKeys.LastRewardGet.ToString());

		dailyRewards = VisualData.Instance.DailyRewardData.dailyRewards;

		foreach (var item in dailyRewards)
		{

		}
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

	
}
