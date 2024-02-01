using Dobeil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VisualData : MonoSingleton<VisualData>
{
    public LeaderBoardData LeaderBoardData;
	public DailyRewardData DailyRewardData;

	protected override void Awake()
	{
		base.Awake();
		foreach (var item in LeaderBoardData.leaderBoardAvararsClass) 
		{
			LeaderBoardData.leaderBoardAvatars.Add(item.avatarId, item);
		}

		foreach (var item in LeaderBoardData.leaderBoardFrameClasses)
		{
			LeaderBoardData.leaderBoardFrames.Add(item.frameId, item);
		}

		int lastRewardGet = SaveManager<int>.LoadData(SaveManagerKeys.LastRewardGet.ToString());

		for (int i = 0; i < DailyRewardData.dailyRewards.Count; i++)
		{
			DailyRewardData.dailyRewards[i].avaiableDate = System.DateTime.Now.AddHours(i * DailyRewardData.dayHours);
			DailyRewardData.dailyRewards[i].received = (i < lastRewardGet);
		}


	}
}

