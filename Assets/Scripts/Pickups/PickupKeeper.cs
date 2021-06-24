using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKeeper : MonoBehaviour
{
    public GameObject[] Pickups;
    public Quest Quest;

    void Update()
    {
        Quest = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>().Quest;

        if (Quest != null)
        {
            if(Quest.Goal.goalType == GoalType.Picking)
            {
                for(int i = 0; i < Pickups.Length; i++)
                {
                    if(Pickups[i].tag == Quest.Goal.ItemToGet)
                    {
                        Pickups[i].GetComponent<PickupBehaviour>().IsPickable = true;
                    }
                }
            }
        }
    }
}
