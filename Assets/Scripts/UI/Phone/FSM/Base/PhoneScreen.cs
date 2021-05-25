using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PhoneScreen : MonoBehaviour
{
    protected PhoneFSM _PFSM { get; private set; }

    public virtual void Initialize(PhoneFSM pScreenFSM)
    {
        _PFSM = pScreenFSM;
        gameObject.SetActive(false);
    }

    public virtual void EnterScreen()
    {
        Debug.Log($"Entering {this} phone screen");
        gameObject.SetActive(true);
    }

    public virtual void ExitScreen()
    {
        Debug.Log($"Exiting {this} phone screen");
        gameObject.SetActive(false);
    }

}
