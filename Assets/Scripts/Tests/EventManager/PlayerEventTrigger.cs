using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made by: Jorrit Bos
public class PlayerEventTrigger : MonoBehaviour
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

                if (Input.GetKeyDown("space"))
                {
                    EventManager.TriggerEvent("jump");
                }
            }

            if (Input.GetKeyDown("space"))
            {
                EventManager.TriggerEvent("jump");
            }
        }
        else
        {
            EventManager.TriggerEvent("idle");
        }

    }
}
