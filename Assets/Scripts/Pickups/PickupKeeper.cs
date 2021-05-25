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

        //if (Quest != null)
        //{
        //    Pickups[0].SetActive(true);
        //    Pickups[1].SetActive(true);
        //}
        //else
        //{
        //    Pickups[0].SetActive(false);
        //    Pickups[1].SetActive(true);
        //}
    }
}
