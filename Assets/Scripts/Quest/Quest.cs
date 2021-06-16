using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By: Jorrit Bos
[CreateAssetMenu(fileName = "Quest File", menuName = "Quest Files Archive")]
public class Quest : ScriptableObject
{
    [Header("Quest Information")]
    public bool IsActive;
    public bool IsFinished;

    public string Title;
    public string Description;
    public int FollowersReward;
    public int MoneyReward;

    [Header("Quest Goal")]
    public QuestGoal Goal;

    public void Complete()
    {
        IsActive = false;
        IsFinished = true;
        Debug.Log(Title + " is completed!");        
    }
}
