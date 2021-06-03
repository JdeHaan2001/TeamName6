using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickupBehaviour : MonoBehaviour
{
    public bool IsPickable;
    private QuestKeeper _questKeeper;

    private void Awake()
    {
        _questKeeper = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();
    }
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0); //Rotates the gameobject 90 degrees per second around z axis per second
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsPickable == true)
        {
            if (collision.collider.tag == "Player")  //Destroys gameobject when collision with Player
            {
                _questKeeper.UpdateQuest();
            }
        }
    }
}
