using System;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Dobeil
{
	[Serializable]
	public class DailyRewardClass
	{
		public bool received;
		public int dayIndex;
		public DateTime avaiableDate;
		public RewardDataBase reward;
	}
	[Serializable]
	public class RewardDataBase
	{
		public RewardType type;
		public Sprite rewardIcon;
		public int count;
	}

	public enum RewardType
	{
		Coin = 0,
		Gem = 1
	}
	[Serializable]
	public class DailyRewardsPrefab
	{
		public RewardType rewardType;
		public RewardBase rewardPrefab;
	}
}