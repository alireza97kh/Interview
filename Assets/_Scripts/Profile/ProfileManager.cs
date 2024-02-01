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
		if (data is RewardDataBase)
		{
			RewardDataBase reward = data as RewardDataBase;
			switch (reward.type)
			{
				case RewardType.Coin:
					GameData.Instance.playerProfile.coin += reward.count;
					break;
				case RewardType.Gem:
					GameData.Instance.playerProfile.gem += reward.count;
					break;
				default:
					break;
			}
			Init();
		}
	}
}
