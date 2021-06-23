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
    [SerializeField] private Camera _cam = null;

    [SerializeField] private playEvent _playEvent;

    

    private void Awake()
    {
        setSourceValues();
        if (_playEvent == playEvent.Awake)
        {
            if(!_sound.Source.isPlaying)
                _sound.Source.Play();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseCheck(gameObject);
            Debug.Log("Clicks mouse");
        }
        #region comments
        //switch (_playEvent)
        //{
        //    case (playEvent)1:
        //        if (mouseCheck(gameObject))
        //        {
        //            if (!_sound.Source.isPlaying)
        //            {
        //                Debug.Log($"{EventSystem.current.currentSelectedGameObject.name}");
        //                _sound.Source.Play();
        //            }
        //            break;
        //        }
        //        break;
        //    case (playEvent)2:
        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            if (mouseCheck(gameObject))
        //            {
        //                if (!_sound.Source.isPlaying)
        //                    _sound.Source.Play();
        //            }
        //            break;
        //        }
        //        break;
        //}
        #endregion
    }

    private bool mouseCheck(GameObject pObj)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //EventSystem.current.IsPointerOverGameObject(,);
        RaycastHit hit;
        Debug.Log("Gets in mouseCheck()");
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log(hit.transform.name);
            return true;
        }
        else
            return false;
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
}
