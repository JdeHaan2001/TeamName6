//Made by Jeroen de Haan
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class SoundEmitter : MonoBehaviour
{
    public enum playEvent
    {
        Awake
    }

    [SerializeField] private Sound _sound = null;
    [SerializeField] private Camera _cam = null;

    [SerializeField] private playEvent _playEvent;

    private void Awake()
    {
        setSourceValues();
        if (_playEvent == playEvent.Awake)
        {
            if (!_sound.Source.isPlaying)
                _sound.Source.Play();
        }
    }

    private void setSourceValues()
    {
        _sound.Source = gameObject.AddComponent<AudioSource>();
        _sound.Source.clip = _sound.Clip;

        _sound.Source.outputAudioMixerGroup = _sound.MixerGroup;

        _sound.Source.loop = _sound.Loop;
        _sound.Source.volume = _sound.Volume;
        _sound.Source.pitch = _sound.Pitch;
        _sound.Source.spatialBlend = _sound.SpatialBlend;
    }

    public void SoundButton(AudioClip pAudioClip)
    {
        _sound.Clip = pAudioClip;
        setSourceValues();
        _sound.Source.Play();
    }
}
