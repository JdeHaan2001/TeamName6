using TMPro;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public TextMeshProUGUI distanceText;

    [HideInInspector] private Transform _player;
    [SerializeField] public GameObject Target;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _wayPointIcon;

    [SerializeField] public float CloseEnoughDist;

    public void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Target != null)
        {
            GetDistance();
            CheckOnScreen();
        }
    }

    private void GetDistance()
    {
        float dist = Vector3.Distance(_player.position, Target.transform.position);
        distanceText.text = dist.ToString("f0") + "m"; 

        if (dist < CloseEnoughDist)
        {
            _wayPointIcon.SetActive(false);
        }
        else
        {
            _wayPointIcon.SetActive(true);
        }
    }

    private void CheckOnScreen()
    {
        float thing = Vector3.Dot((Target.transform.position - _camera.transform.position).normalized, _camera.transform.forward);

        if (thing >= 0)
        {
            transform.position = _camera.WorldToScreenPoint(Target.transform.position);
        }
    }
}
