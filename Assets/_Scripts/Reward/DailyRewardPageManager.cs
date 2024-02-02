using Dobeil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardPageManager : DobeilPageBase
{
	private List<DailyRewardClass> dailyRewards = new List<DailyRewardClass>();
	[SerializeField] private Transform content;

	private List<RewardBase> dailyRewardsList = new List<RewardBase>();
	protected override void ShowPage(object data = null)
	{
		dailyRewards = VisualData.Instance.DailyRewardData.dailyRewards;
		if (dailyRewardsList.Count != dailyRewards.Count)
		{
			foreach (var item in dailyRewards)
			{
				switch (item.reward.type)
				{
					case RewardType.Coin:
						DailyRewardsPrefab coinPrefab = VisualData.Instance.DailyRewardData.dailyRewardsPrefabs.Find(x => x.rewardType == RewardType.Coin);
						if (coinPrefab != null)
						{
							CoinReward coinReward = Instantiate(coinPrefab.rewardPrefab as CoinReward, content);
							coinReward.Init(item);
							dailyRewardsList.Add(coinReward);
						}
						break;
					case RewardType.Gem:
						DailyRewardsPrefab gemPrefab = VisualData.Instance.DailyRewardData.dailyRewardsPrefabs.Find(x => x.rewardType == RewardType.Gem);
						if (gemPrefab != null)
						{
							GemReward gemReward = Instantiate(gemPrefab.rewardPrefab as GemReward, content);
							gemReward.Init(item);
							dailyRewardsList.Add(gemReward);
						}
						break;
				}
			}
		}
		else
		{
			int index = 0;
			foreach(var item in dailyRewardsList)
			{
				item.Init(dailyRewards[index]);
				index++;
			}
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
