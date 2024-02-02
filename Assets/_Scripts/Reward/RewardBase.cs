using Dobeil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class RewardBase : MonoBehaviour
{
    [SerializeField] private RTLTMPro.RTLTextMeshPro dayIndexText;
	[SerializeField] private Image rewardImage;
    [SerializeField] private RTLTMPro.RTLTextMeshPro rewardCountText;
	[SerializeField] private Color receivedColor;
	[SerializeField] private Color normalColor;
	[SerializeField] private Image rewardBg;
    [SerializeField] private Button rewardBtn;

    private DailyRewardClass rewardData;
	public virtual void Init(DailyRewardClass _rewardData)
    {
        rewardData = _rewardData;
        rewardImage.sprite = rewardData.reward.rewardIcon;
		rewardCountText.text = rewardData.reward.count.ToString();
		SetRewardBg(_rewardData.received);
        rewardBtn.interactable = !_rewardData.received && (DateTime.Now > rewardData.avaiableDate);
	}

    public virtual void Select()
    {
        rewardData.received = true;
        DobeilEventManager.SendGlobalEvent("SHOW_REWARD", rewardData);
        Init(rewardData);
    }

    public void SetRewardBg(bool received)
    {
        rewardBg.color = received ? receivedColor : normalColor;
    }
}
