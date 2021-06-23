using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlisenMovement : MonoBehaviour
{
    [SerializeField] private Vector3 _moveSpeed = new Vector3(0f, 5f, 0f);

    private void Update()
    {
        transform.position += _moveSpeed;
    }

    private void handleOutOfScreen()
    {
        if (transform.position.y > 0)
            Debug.Log($"{transform.name} ahdiasjsfgesdfjstehfg");
    }
}
