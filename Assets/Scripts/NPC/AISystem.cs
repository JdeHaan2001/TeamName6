using System.Linq;
using UnityEngine;
using UnityEngine.UI;

//Made by: Jorrit Bos
public class AISystem : StateMachine
{
    #region Variables
    [HideInInspector] public GameObject Player;
    [SerializeField] public int FollowSpeed = 0;
    [SerializeField] public int CheckingRadius = 0;

    [HideInInspector] private QuestKeeper _questKeeper;

    [HideInInspector] public DialogueManager DialogueManager;
    [SerializeField] public NpcInformation NpcInfo;
    [HideInInspector] public QuestGiver QuestGiver;
    [SerializeField] public GameObject InteractIcon;

    [HideInInspector] public bool InteractionPossible;
    [HideInInspector] public bool IsInteracting;
    [HideInInspector] public Vector3 StartPos;
    [HideInInspector] public Quaternion StartAngle;

    private Quaternion _startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    private Quaternion _stepAngle = Quaternion.AngleAxis(5, Vector3.up);

    #endregion

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        QuestGiver = GameObject.FindGameObjectWithTag("NPCManager").GetComponent<QuestGiver>();
    }
    private void Start()
    {
        DialogueManager = DontDestroyUI.UIInstance.UIGameObjects[0].GetComponent<DialogueManager>();
        _questKeeper = Player.GetComponent<QuestKeeper>();

        InteractionPossible = true;
        SetState(new AIBehaviours(this));

        StartPos = transform.position;
        StartAngle = transform.rotation;
    }

    private void Update()
    {
        var ObjectFound = checkEnvironment();
        checkAvailability();

        if (ObjectFound != null)
        {
            if (InteractionPossible == true)
            {
                if (Vector3.Distance(transform.position, StartPos) < 40)
                {
                    if (Vector3.Distance(transform.position, Player.transform.position) < CheckingRadius && Vector3.Distance(transform.position, Player.transform.position) > 5f)
                    {
                        StartCoroutine(State.Follow());
                    }
                    else if (Vector3.Distance(transform.position, Player.transform.position) < 5f)
                    {
                        StartCoroutine(State.Interact());
                    }
                    else
                    {
                        StartCoroutine(State.Return());
                    }
                }
                else
                {
                    StartCoroutine(State.Return());
                }
            }
            else if (InteractionPossible == false)
            {
                if (transform.position != StartPos)
                {
                    StartCoroutine(State.Return());
                }
                InteractIcon.SetActive(false);
                StartCoroutine(State.Unavailable());
            }
        }
        else
        {
            StartCoroutine(State.Idle());
        }
    }

    /// <summary>
    /// Checks if NPC is available for talking
    /// </summary>
    private void checkAvailability()
    {
        if (NpcInfo != null)
        {
            if (NpcInfo.ConversationFinished != true)
            {
                InteractionPossible = true;
            }
        }

        //if (_questKeeper.Quest != null)
        //{
        //    if (_questKeeper.Quest.IsActive == true)
        //    {
        //        for (int i = 0; i < NpcInfo.Quests.Length; i++)
        //        {
        //            if (NpcInfo.Quests[i].Goal.npcToTalkTo.NpcInfo.ConversationFinished == true)
        //            {
        //                _questKeeper.UpdateQuest();
        //                InteractionPossible = false;
        //            }
        //            else
        //            {
        //                InteractionPossible = true;
        //            }
        //        }
        //    }
        //}
    }

    /// <summary>
    /// Checks if the NPC sees something
    /// </summary>
    /// <returns></returns>
    private Transform checkEnvironment()
    {
        RaycastHit hit;
        var angle = transform.rotation * _startingAngle;
        var direction = angle * Vector3.forward;
        var pos = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        for (var i = 0; i < 24; i++)
        {
            if (Physics.Raycast(pos, direction, out hit, CheckingRadius))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.red);
                    return Player.transform;
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
            direction = _stepAngle * direction;
        }
        return null;
    }
}
