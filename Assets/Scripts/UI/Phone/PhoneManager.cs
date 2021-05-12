//Made by Jeroen de Haan

using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhoneManager : MonoBehaviour
{
    public PhoneState PhoneScreen;

    //private List<GameObject> _screens = new List<GameObject>();
    private Dictionary<Type, PhoneState> _screens = new Dictionary<Type, PhoneState>();

    public enum PhoneState
    {
        HOMESCREEN, SETTINGS
    };

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log($"{transform.GetChild(i).GetType()}");
        }
    }

    public void ChangesScreen()
    {

    }
}
