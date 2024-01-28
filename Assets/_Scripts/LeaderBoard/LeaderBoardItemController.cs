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


    private void SetMemberData(object data)
    {
        if (data is Member)
        {
            Debug.Log((data as Member).Username);
        }
    }
}
