using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By: Jorrit Bos
public class QuestKeeper : MonoBehaviour
{
    public Quest Quest;

    [HideInInspector] public int Followers;
    [HideInInspector] public int Money;

    public void UpdateQuest()
    {
        if (Quest.IsActive == true)
        {
            if(Quest.Goal.goalType == GoalType.Gathering)
            {
                Quest.Goal.ItemGathered();
            }

            if(Quest.Goal.goalType == GoalType.Picking)
            {
                Quest.Goal.ItemPicked();
            }

            if (Quest.Goal.IsReached())
            {
                Followers += Quest.FollowersReward;
                Money += Quest.MoneyReward;
                Quest.Complete();
                Quest.IsActive = false;
            }
        }
    }
}
