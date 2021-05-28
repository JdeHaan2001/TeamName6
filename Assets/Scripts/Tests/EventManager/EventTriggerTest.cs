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

        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            EventManager.TriggerEvent("walk");

            if (Input.GetKey("left shift"))
            {
                EventManager.TriggerEvent("sprint");
            }
        }
        else if (Input.GetKeyDown("space"))
        {
            EventManager.TriggerEvent("jump");
        }
        else
        {
            EventManager.TriggerEvent("idle");
        }

    }
}
