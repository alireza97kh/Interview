using Dobeil;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DailyRewardData", menuName = "Data/DailyRewardData")]
public class DailyRewardData : ScriptableObject
{
    public List<DailyRewardClass> dailyRewards = new List<DailyRewardClass>();
    public float hoursOfDay = 1;

    public List<DailyRewardsPrefab> dailyRewardsPrefabs = new List<DailyRewardsPrefab>();
}
