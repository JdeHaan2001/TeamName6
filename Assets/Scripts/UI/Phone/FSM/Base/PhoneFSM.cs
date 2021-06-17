using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneFSM : MonoBehaviour
{
    private Dictionary<Type, PhoneScreen> _screenMap = new Dictionary<Type, PhoneScreen>();

    private PhoneScreen _currentScreen = null;

    [SerializeField] private PhoneScreen _startScreen = null;

    private void Awake()
    {
        PhoneScreen[] screens = GetComponentsInChildren<PhoneScreen>(true);
        foreach (PhoneScreen screen in screens)
        {
            _screenMap.Add(screen.GetType(), screen);
            screen.Initialize(this);
        }
    }

    private void Start()
    {
        ChangeScreen(_startScreen.GetType());
    }

    public void ChangeScreen<T>() where T : PhoneScreen
    {
        ChangeScreen(typeof(T));
    }

    public void ChangeScreen(Type pType)
    {
        //Check if the screen is not already active
        if (_currentScreen != null && _currentScreen.GetType() == pType) return;

        if (_currentScreen != null)
        {
            _currentScreen.ExitScreen();
            _currentScreen = null;
        }

        if (pType != null && _screenMap.ContainsKey(pType))
        {
            _currentScreen = _screenMap[pType];
            _currentScreen.EnterScreen();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            ChangeScreen<HomeScreen>();
    }
}
