using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] private QuestGiver _questGiver;

    public void AcceptOnClick()
    {
        Debug.Log("Quest Accepted");
        _questGiver.AcceptQuest();
    }

    public void DeclineOnClick()
    {
        Debug.Log("Quest Declined");
        _questGiver.DeclineQuest();
    }
}
