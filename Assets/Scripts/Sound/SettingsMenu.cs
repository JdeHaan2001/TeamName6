using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer = null;
    private float lastVolume;
    private bool _isActive = true;

    public void SetVolume(float pVolume)
    {
        //masterMixer.SetFloat("Volume", pVolume);
        //lastVolume = pVolume;
        Debug.Log(pVolume);
    }

    public void SetActiveAudio()
    {
        if (_isActive)
        {
            masterMixer.SetFloat("Volume", -80f);
            _isActive = false;
        }
        else
        {
            masterMixer.SetFloat("Volume", lastVolume);
            _isActive = true;
        }
    }
}
