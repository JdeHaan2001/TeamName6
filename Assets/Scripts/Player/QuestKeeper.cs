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

                if (Quest.Goal.IsReached())
                {
                    Debug.Log(Quest.Title + " is completed!");

                    Followers += Quest.FollowersReward;
                    Money += Quest.MoneyReward;
                    Moral += Quest.AcceptMoralPoints;

                    Quest.IsFinished = true;
                    Quest.IsActive = false;
                    Quest = null;
                }
            }
            else if (Quest.IsActive == false)
            {
                if(Quest.Goal.IsDeclined == true)
                {
                    Debug.Log(Quest.Title + " is Declined!");

                    if(Quest.SideQuest == true)
                    {
                        Followers += Quest.FollowersDecrease;
                        Money += Quest.MoneyDecrease;
                        Moral += Quest.DeclineMoralPoints;
                        Quest.IsFinished = true;
                    }
                    Quest = null;
                }
            }
        }
    }
}
