using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreen : PhoneScreenWithView<HomeView>
{
    public override void EnterScreen()
    {
        base.EnterScreen();
        phoneView.Button.onClick.AddListener(_PFSM.ChangeScreen<SettingsScreen>);
    }

    private void changeScreen()
    {
        _PFSM.ChangeScreen<SettingsScreen>();
    }
}
