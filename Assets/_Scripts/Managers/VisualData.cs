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
		


	}
}

