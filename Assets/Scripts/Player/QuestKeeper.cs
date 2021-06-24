using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By: Jorrit Bos
public class QuestKeeper : MonoBehaviour
{
    public Quest Quest;

    [HideInInspector] public int Followers;
    [HideInInspector] public int Money;
    [HideInInspector] public int Moral;

    [HideInInspector] public bool questIsDone;

    public void UpdateQuest()
    {
        if (Quest != null)
        {
            if (Quest.IsActive == true)
            {
                if (Quest.Goal.goalType == GoalType.Giving)
                {
                    Quest.Goal.ItemGiven();
                }

                if (Quest.Goal.goalType == GoalType.TakingPicture)
                {
                    Quest.Goal.PictureTaken();
                }

                if (Quest.Goal.goalType == GoalType.Picking)
                {
                    Quest.Goal.ItemPicked();
                }

                if (Quest.Goal.goalType == GoalType.Talking)
                {
                    Quest.Goal.TalkedToNPC();
                }

                if (Quest.Goal.IsReached() || questIsDone == true)
                {
                    Debug.Log(Quest.Title + " is completed!");

                    Followers += Quest.FollowersReward;
                    Money += Quest.MoneyReward;
                    Moral += Quest.AcceptMoralPoints;
                    Quest.IsActive = false;
                    Quest = null;

                    if(questIsDone == true)
                    {
                        questIsDone = false;
                    }
                }
            }
        }
    }
}
