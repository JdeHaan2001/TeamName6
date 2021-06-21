//Made by Jeroen de Haan
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class SoundEmitter : MonoBehaviour
{
    public enum playEvent
    {
        MouseHover = 1, MouseClick, Awake
    }

    [SerializeField] private Sound _sound = null;

    [SerializeField] private playEvent _playEvent;

    private void Awake()
    {
        //Debug.Log(_playEvent);
        setSourceValues();
        //if (_playEvent == playEvent.Awake)
        //{
        //    Debug.Log("Jghjhdgasjhdhfgasghjrdft");
        //    _sound.Source.Play();
        //}
    }

    private void Start()
    {
        Debug.Log(_sound.Clip.loadState);
        //if(!_sound.Source.isPlaying)
        //    _sound.Source.Play();
    }

    private void Update()
    {
        //switch (_playEvent)
        //{
        //    case (playEvent) 1:
        //        if (EventSystem.current.IsPointerOverGameObject())
        //        {
        //            _sound.Source.Play();
        //            break;
        //        }
        //        break;
        //    case (playEvent) 2:
        //        if (EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
        //        {
        //            _sound.Source.Play();
        //            break;
        //        }
        //        break;
        //}
    }

    private void setSourceValues()
    {
        _sound.Source = gameObject.AddComponent<AudioSource>();
        _sound.Source.clip = _sound.Clip;

        _sound.Source.loop = _sound.Loop;
        //_sound.Source.playOnAwake = _sound.PlayOnAwake;
        _sound.Source.volume = _sound.Volume;
        _sound.Source.pitch = _sound.Pitch;
        _sound.Source.spatialBlend = _sound.SpatialBlend;
    }
}
