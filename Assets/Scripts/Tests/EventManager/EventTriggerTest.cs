using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggerTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            EventManager.TriggerEvent("test");
        }

        if (Input.GetKey("w"))
        {
            EventManager.TriggerEvent("walk");
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            EventManager.TriggerEvent("Jump");
        }
        else
        {
            EventManager.TriggerEvent("idle");
        }
    }
}
