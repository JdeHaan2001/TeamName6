using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : PhoneScreenWithView<HomeView>
{
    public override void EnterScreen()
    {
        base.EnterScreen();
        phoneView.ChatBtn.onClick.AddListener(_PFSM.ChangeScreen<SettingsScreen>);
        phoneView.MapsBtn.onClick.AddListener(_PFSM.ChangeScreen<MapsScreen>);
        phoneView.GalleryBtn.onClick.AddListener(_PFSM.ChangeScreen<GalleryScreen>);
        phoneView.ContactsBtn.onClick.AddListener(_PFSM.ChangeScreen<ContactsScreen>);
        phoneView.QuestsBtn.onClick.AddListener(_PFSM.ChangeScreen<QuestsScreen>);
        phoneView.FilesBtn.onClick.AddListener(_PFSM.ChangeScreen<FilesScreen>);
        phoneView.CameraBtn.onClick.AddListener(_PFSM.ChangeScreen<CameraScreen>);
        phoneView.SettingsBtn.onClick.AddListener(_PFSM.ChangeScreen<SettingsScreen>);
    }
}
