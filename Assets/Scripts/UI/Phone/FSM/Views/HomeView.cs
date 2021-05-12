using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeView : PhoneView
{
    [SerializeField] private Button _buttons = null;

    public Button Button { get => _buttons; }
}
