//Made by Jeroen de haan

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Movement Speed")]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _shiftBoost = 20f;
    [Space]
    [SerializeField] private float _camSensitivity = 0.25f;

    private Vector3 _velocity;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
            handleCamControls();
    }

    private void handleCamControls()
    {
        transform.eulerAngles += _camSensitivity * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float zAxis = (Input.GetKey(KeyCode.Q) ? -1 : 0) + (Input.GetKey(KeyCode.E) ? 1 : 0);

        float moveSpeed = (Input.GetKey(KeyCode.LeftShift) ? _shiftBoost : _speed);

        transform.position += (transform.forward * moveSpeed * vertical + transform.right * moveSpeed * horizontal + transform.up * moveSpeed * zAxis) * Time.deltaTime;
    }
}
