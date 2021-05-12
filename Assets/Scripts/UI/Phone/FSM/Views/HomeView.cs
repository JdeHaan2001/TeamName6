using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HomeView : PhoneView
{
    [SerializeField] private Button _chatBtn = null;
    [SerializeField] private Button _mapsBtn = null;
    [SerializeField] private Button _galleryBtn = null;
    [SerializeField] private Button _contactsBtn = null;
    [SerializeField] private Button _questsBtn = null;
    [SerializeField] private Button _filesBtn = null;
    [SerializeField] private Button _cameraBtn = null;
    [SerializeField] private Button _settingsBtn = null;

    public Button ChatBtn { get => _chatBtn; }
    public Button MapsBtn { get => _mapsBtn; }
    public Button GalleryBtn { get => _galleryBtn; }
    public Button ContactsBtn { get => _contactsBtn; }
    public Button QuestsBtn { get => _questsBtn; }
    public Button FilesBtn { get => _filesBtn; }
    public Button CameraBtn { get => _cameraBtn; }
    public Button SettingsBtn { get => _settingsBtn; }
}
