using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By: Jorrit Bos
[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int RequiredAmount;
    public int CurrentAmount;
    public string ItemToGet;
    public GameObject NpcToInteractWith;

    public bool IsReached()
    {
        return (CurrentAmount >= RequiredAmount);
    }

    public void ItemPicked()
    {
        if (goalType == GoalType.Picking)
        {
            CurrentAmount++;
        }
    }

    public void TalkedToNPC()
    {
        if (goalType == GoalType.Talking)
        {
            GameObject[] Npc = GameObject.FindGameObjectsWithTag("NPC");

            for (int j = 0; j < Npc.Length; j++)
            {
                if (Npc[j].name == NpcToInteractWith.name)
                {
                    NPCInformation npcInformaton = Npc[j].GetComponent<AISystem>().NpcInformation;

                    if (npcInformaton.ConversationFinished == true)
                    {
                        CurrentAmount++;
                    }
                }
            }
        }
    }

    public void ItemGiven()
    {
        if (goalType == GoalType.Giving)
        {
            CurrentAmount++;
        }
    }

    public void PictureTaken()
    {
        if(goalType == GoalType.TakingPicture)
        {
            CurrentAmount++;
        }
    }
}
    public enum GoalType
    {
        Picking,
        Talking,
        Giving,
        TakingPicture
    }