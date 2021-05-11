using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By: Jorrit Bos
[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;
    public string ItemToGet;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void ItemPicked()
    {
        if (goalType == GoalType.Picking)
        {
            currentAmount++;
        }
    }

    public void ItemGathered()
    {
        if (goalType == GoalType.Gathering)
        {
            currentAmount++;
        }
    }

}


public enum GoalType
{
    Picking,
    Gathering
}