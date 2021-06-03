using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneScreenWithView<T> : PhoneScreen where T : PhoneView
{
    [SerializeField] private T _phoneView = null;
    protected T phoneView { get { return _phoneView; } }

    public override void Initialize(PhoneFSM pPhoneScreen)
    {
        base.Initialize(pPhoneScreen);
        phoneView?.Hide();

        Debug.Log($"Initialized phone screen {this.name} -- Linked to view: {phoneView?.name}");
    }

    public override void EnterScreen()
    {
        base.EnterScreen();
        phoneView?.Show();
    }

    public override void ExitScreen()
    {
        base.ExitScreen();
        phoneView?.Hide();
    }
}
