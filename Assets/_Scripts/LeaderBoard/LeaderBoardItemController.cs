using Dobeil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTLTMPro;

public class LeaderBoardItemController : MonoBehaviour
{
    [SerializeField] private Image avatarImage;
    [SerializeField] private Image frameImage;
    [SerializeField] private RTLTextMeshPro userNameTxt;
    //Gold
    [SerializeField] private GameObject goldMedalObject;
    [SerializeField] private RTLTextMeshPro goldMedalText;
    
    //Silver
    [SerializeField] private GameObject silverMedalObject;
    [SerializeField] private RTLTextMeshPro silverMedalText;

    //Bronze
    [SerializeField] private GameObject bronzeMedalObject;
    [SerializeField] private RTLTextMeshPro bronzeMedalText;


    public void SetMemberData(object data)
    {
        if (data is Member)
        {
            Member member = (Member)data;
            Debug.Log((data as Member).Username);
            userNameTxt.text = member.Username;
            goldMedalObject.SetActive(member.GoldMedals > 0);
            silverMedalObject.SetActive(member.SilverMedals > 0);
            bronzeMedalObject.SetActive(member.BronzeMedals > 0);

            goldMedalText.text = member.GoldMedals.ToString();
            silverMedalText.text = member.SilverMedals.ToString();
            bronzeMedalText.text = member.BronzeMedals.ToString();
        }
    }
}
