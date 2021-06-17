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

    public void GetWayPoint(GameObject target)
    {
        Target = target;
    }

    private void GetDistance()
    {
        float dist = Vector3.Distance(_player.position, Target.transform.position);

        if (dist < CloseEnoughDist)
        {
            _wayPointIcon.SetActive(false);
            distanceText.text = "";
        }
        else
        {
            _wayPointIcon.SetActive(true);
            distanceText.text = dist.ToString("f0") + "m";
        }
    }

    private void CheckOnScreen()
    {
        float InScreen = Vector3.Dot((Target.transform.position - _camera.transform.position).normalized, _camera.transform.forward);

        if (InScreen >= 0)
        {
            transform.position = _camera.WorldToScreenPoint(Target.transform.position);
        }
    }
}
