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

    [HideInInspector] public QuestKeeper QuestKeeper;
    [HideInInspector] public QuestManager QuestManager;

    [HideInInspector] public DialogueManager DialogueManager;
    [SerializeField] public NpcInformation NpcInformation;
    [HideInInspector] public QuestGiver QuestGiver;
    [SerializeField] public GameObject InteractIcon;

    [HideInInspector] public bool InteractionPossible;
    [HideInInspector] public bool IsInteracting;

    [HideInInspector] public Vector3 StartPos;
    [HideInInspector] public Quaternion StartAngle;

    private Quaternion _startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    private Quaternion _stepAngle = Quaternion.AngleAxis(5, Vector3.up);

    #endregion

    public void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        QuestGiver = GameObject.FindGameObjectWithTag("NPCManager").GetComponent<QuestGiver>();

        QuestKeeper = Player.GetComponent<QuestKeeper>();
        QuestManager = GameObject.FindGameObjectWithTag("QuestManager").GetComponent<QuestManager>();

        InteractionPossible = true;
        SetState(new AIBehaviours(this));

        StartPos = transform.position;
        StartAngle = transform.rotation;
    }
    public void Start()
    {
        DialogueManager = DontDestroyUI.UIInstance.UIGameObjects[0].GetComponent<DialogueManager>();
    }

    public void Update()
    {
        checkState();
    }

    private void checkState()
    {
        var ObjectFound = checkEnvironment();
        var interactionPossible = checkAvailability();

        if (interactionPossible == true)
        {
            InteractIcon.SetActive(true);
            if (ObjectFound != null)
            {
                if (Vector3.Distance(transform.position, Player.transform.position) < CheckingRadius && Vector3.Distance(transform.position, Player.transform.position) > 10f)
                {
                    StartCoroutine(State.Follow());
                }
                else if (Vector3.Distance(transform.position, Player.transform.position) < 10f)
                {
                    StartCoroutine(State.Interact());
                }
            }
            else
            {
                if (transform.position != StartPos)
                {
                    StartCoroutine(State.Return());
                }
                StartCoroutine(State.Idle());
            }
        }
        else if (interactionPossible == false)
        {
            InteractIcon.SetActive(false);

            if (transform.position != StartPos)
            {
                StartCoroutine(State.Return());
            }
            StartCoroutine(State.Idle());
        }
    }

    /// <summary>
    /// Checks if NPC is available for talking
    /// </summary>
    private bool checkAvailability()
    {
        if (QuestKeeper.Quest != null)
        {
            if (gameObject.name != QuestKeeper.Quest.Goal.NpcToInteractWith.gameObject.name)
            {
                if (NpcInformation.ConversationFinished == true)
                {
                    return false;
                }
                return false;
            }
        }

        if (QuestKeeper.Quest == null)
        {
            if (NpcInformation.Quests[0].SideQuest != true)
            {
                if (NpcInformation.Quests[0].name != QuestManager.QuestChecker().name)
                {
                    return false;
                }
                if (NpcInformation.ConversationFinished == true)
                {
                    return false;
                }

            }
            else if(NpcInformation.Quests[0].name != QuestManager.QuestChecker().name)
            {
                if (NpcInformation.ConversationFinished == true)
                {
                    return false;
                }
            }
        }
        return true;
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

    public void OnApplicationQuit()
    {
        NpcInformation.ConversationFinished = false;
        for (int i = 0; i < NpcInformation.Quests.Length; i++)
        {
            NpcInformation.Quests[i].IsActive = false;
            NpcInformation.Quests[i].Goal.CurrentAmount = 0;
        }
    }
}
