using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoint : MonoBehaviour
{
    public Text distanceText;

    public Transform player;
    public Transform target;
    public Camera cam;
    public GameObject WayPointIcon;

    public float closeEnoughDist;

    private void Update()
    {
        if (target != null && WayPointIcon != null)
        {
            GetDistance();
            CheckOnScreen();
        }
    }

    private void GetDistance()
    {
        float dist = Vector3.Distance(player.position, target.position);
        distanceText.text = dist.ToString("f0") + "m";

        if (dist < closeEnoughDist)
        {
            WayPointIcon.SetActive(false);
        }
    }

    private void CheckOnScreen()
    {
        float thing = Vector3.Dot((target.position - cam.transform.position).normalized, cam.transform.forward);

        if(thing >= 0)
        {
            transform.position = cam.WorldToScreenPoint(target.position);
        }
    }

    private void ToggleUI(bool _value)
    {
        WayPointIcon.SetActive(_value);
    }



}
