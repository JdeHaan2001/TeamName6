using System.Linq;
using UnityEngine;
using TMPro;

//Made by: Jorrit Bos
public class AISystem : StateMachine
{
    #region Variables
    [SerializeField] public GameObject ObjectToFollow;
    [SerializeField] public int FollowSpeed = 0;
    [SerializeField] public int WandeSpeed = 0;
    [SerializeField] public int CheckingRadius = 0;

    [SerializeField] private LayerMask _layerMask;

    [HideInInspector] public Vector3 Destination;
    [HideInInspector] public Quaternion DesiredRotation;
    [HideInInspector] public Vector3 Direction;
    [SerializeField] public Vector3 WanderPositions;

    [HideInInspector] public DialogueManager DialogueManager;
    [SerializeField] public GameObject InteractText;

    [HideInInspector] public bool InteractionPossible = false;

    Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);

    #endregion
    private void Start()
    {
        SetState(new BeginState(this));
        InteractText.SetActive(false);
        DialogueManager = GetComponent<DialogueManager>();
    }

    private void Update()
    {
        var ObjectFound = checkEnvironment();

        if (ObjectFound != null)
        {
            if (ObjectToFollow != null)
            {
                StartCoroutine(State.Follow());
                if (Vector3.Distance(transform.position, ObjectToFollow.transform.position) < 10f)
                {
                    if(InteractionPossible == true)
                    {
                        StartCoroutine(State.Interact());
                    }
                    else
                    {
                        StartCoroutine(State.Unavailable());
                    }
                }
                else
                {
                    InteractText.SetActive(false);
                }
            }
        }
        else
        {
            StartCoroutine(State.Idle());
        }
    }

    private Transform checkEnvironment()
    {
        RaycastHit hit;
        var angle = transform.rotation * startingAngle;
        var direction = angle * Vector3.forward;
        var pos = transform.position;
        for (var i = 0; i < 24; i++)
        {
            if (Physics.Raycast(pos, direction, out hit, CheckingRadius))
            {
                var player = hit.collider.GetComponent<ThirdPersonCharacterController>();
                if (player != null)
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.red);
                    return player.transform;                    
                }
                else
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.yellow);
                }
            }
            else
            {
                Debug.DrawRay(pos, direction * CheckingRadius, Color.white);
            }
            direction = stepAngle * direction;
        }
        return null;
    }
}
