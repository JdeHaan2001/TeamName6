using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButtonFunctions : MonoBehaviour
{
    [HideInInspector] private QuestGiver _questGiver;

    public void Awake()
    {
        _questGiver = GameObject.FindGameObjectWithTag("NPCManager").GetComponent<QuestGiver>();
    }
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
