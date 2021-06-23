using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By: Jorrit Bos
[CreateAssetMenu(fileName = "Quest File", menuName = "Quest Files Archive")]
public class Quest : ScriptableObject
{
    [Header("Quest Information")]
    public bool IsActive;

    public string Title;
    public string Description;
    public bool SideQuest;

    [Header("Quest Complete Information")]
    public int FollowersReward;
    public int MoneyReward;
    public int AcceptMoralPoints;

    [Header("Quest Decline Information")]
    public int FollowersDecrease;
    public int MoneyDecrease;
    public int DeclineMoralPoints;

    [Header("Quest Goal")]
    public QuestGoal Goal;

    public void Complete()
    {
        IsActive = false;
        Debug.Log(Title + " is completed!");        
    }
}
