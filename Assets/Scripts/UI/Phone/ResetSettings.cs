//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class ResetSettings : MonoBehaviour
//{
//    [SerializeField] private SettingsMenu _menuSettings = null;
//    //[SerializeField] private List<Button> _checkButtons = null;
//    [SerializeField] private Image _sfxButton = null;
//    [SerializeField] private Image _musicButton = null;
//    [SerializeField] private Image _readButton = null;
//    [SerializeField] private Slider volumeSlider = null;

//    public void ResetSetting()
//    {
//        volumeSlider.value = volumeSlider.maxValue;
//        _menuSettings.SetVolume(volumeSlider.maxValue);
//        if (!_sfxButton.gameObject.activeInHierarchy) _menuSettings.SetSFXActive(_sfxButton);
//        if (!_musicButton.gameObject.activeInHierarchy) _menuSettings.SetMusicActive(_musicButton);
//        if (!_readButton.gameObject.activeInHierarchy) _menuSettings.SetReadActive(_readButton);
//    }
//}
