using Dobeil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileManager : MonoBehaviour
{
	[SerializeField] RTLTMPro.RTLTextMeshPro coinCountText;
	[SerializeField] RTLTMPro.RTLTextMeshPro gemCountText;

	private void Awake()
	{
		DobeilEventManager.RegisterGlobalEvent("SHOW_REWARD", ShowReward);
	}

	public void Init()
	{
		coinCountText.text = GameData.Instance.playerProfile?.coin.ToString();
		gemCountText.text = GameData.Instance.playerProfile?.gem.ToString();
	}

	public void ShowReward(object data)
	{
		if (data is DailyRewardClass)
		{
			DailyRewardClass reward = data as DailyRewardClass;
			switch (reward.reward.type)
			{
				case RewardType.Coin:
					GameData.Instance.playerProfile.coin += reward.reward.count;
					break;
				case RewardType.Gem:
					GameData.Instance.playerProfile.gem += reward.reward.count;
					break;
				default:
					break;
			}
			Init();
			GameData.Instance.playerProfile.lastRewardIndex = reward.dayIndex;
			SaveManager<PlayerProfileClass>.SaveData(SaveManagerKeys.PlayerProfile.ToString(), GameData.Instance.playerProfile);
		}
	}
}
