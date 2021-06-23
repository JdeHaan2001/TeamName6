//Made by Jeroen de Haan
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Button _SFXButton;
    [SerializeField] private Button _MusicButton;
    [SerializeField] private Button _VoiceOverButton;
    [Space()]
    [SerializeField] private AudioMixer audioMixer;
    [Space()]
    [SerializeField] private AudioMixerGroup _SFXGroup;
    [SerializeField] private AudioMixerGroup _MusicGroup;
    [SerializeField] private AudioMixerGroup _VoiceOverGroup;

    private float _volume;
    
    public void SetVolume(float pVolume)
    {
        _volume = pVolume;
        audioMixer.SetFloat("MainVolume", _volume);
    }

    private void Awake()
    {
        _SFXButton.onClick.AddListener(delegate { SetActive(_SFXGroup, _SFXButton); });
        _MusicButton.onClick.AddListener(delegate { SetActive(_MusicGroup, _MusicButton); });
        _VoiceOverButton.onClick.AddListener(delegate { SetActive(_VoiceOverGroup, _VoiceOverButton); });
    }

    private void SetActive(AudioMixerGroup pMixerGroup, Button pButton)
    {
        GameObject imageObj = pButton.transform.GetChild(0).gameObject;

        if (imageObj != null)
        {
            if (imageObj.activeInHierarchy)
            {
                imageObj.SetActive(false);
                pMixerGroup.audioMixer.SetFloat($"{pMixerGroup.name}Volume", -80f);
            }
            else
            {
                imageObj.SetActive(true);
                pMixerGroup.audioMixer.SetFloat($"{pMixerGroup.name}Volume", 0f);
            }
        }
    }
    #region old Settings
    //    FMOD.Studio.Bus _master;
    //    FMOD.Studio.Bus _music;
    //    FMOD.Studio.Bus _SFX;
    //    FMOD.Studio.Bus _readAloud;

    //    private float _lastVolume;

    //    private void Awake()
    //    {
    //        _master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
    //        _music = FMODUnity.RuntimeManager.GetBus("bus:/Master/TestMusic");
    //    }

    //    public void SetVolume(float pVolume)
    //    {
    //        _music.setVolume(pVolume);
    //        Debug.Log(pVolume);
    //    }

    //    public void SetMusicActive(Image pButton)
    //    {
    //        if (pButton.gameObject.activeInHierarchy)
    //        {
    //            pButton.gameObject.SetActive(false);
    //            _music.setMute(true);
    //        }
    //        else
    //        {
    //            pButton.gameObject.SetActive(true);
    //            _music.setMute(false);
    //        }
    //    }

    //    public void SetSFXActive(Image pButton)
    //    {
    //        if (pButton.gameObject.activeInHierarchy)
    //        {
    //            pButton.gameObject.SetActive(false);
    //            _SFX.setMute(false);
    //        }
    //        else
    //        {
    //            pButton.gameObject.SetActive(true);
    //            _SFX.setMute(true);
    //        }
    //    }

    //    public void SetReadActive(Image pImage)
    //    {
    //        if (pImage.gameObject.activeInHierarchy)
    //        {
    //            pImage.gameObject.SetActive(false);
    //            _readAloud.setMute(false);
    //        }
    //        else
    //        {
    //            pImage.gameObject.SetActive(true);
    //            _readAloud.setMute(true);
    //        }
    //    }
    #endregion
}
