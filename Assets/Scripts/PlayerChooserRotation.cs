using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChooserRotation : MonoBehaviour
{
    private void Awake()
    {
        gameObject.transform.Rotate(0, 180, 0);
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        gameObject.transform.Rotate(0, 90 * Time.deltaTime, 0); //Rotates the gameobject 90 degrees per second around z axis per second
    }
}
