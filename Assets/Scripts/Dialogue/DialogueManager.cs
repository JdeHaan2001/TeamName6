using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

//Made by: Jorrit Bos
public class DialogueManager : MonoBehaviour
{
    #region Variables
    [SerializeField] public AISystem AISystem;
    [SerializeField] public NPCInformation npc;

    [HideInInspector] private bool isTalking;
    [HideInInspector] public bool OpenQuest;
    [HideInInspector] public bool CheckNPC;
    [HideInInspector] public bool NPCChecked;

    [HideInInspector] private int _currentCheckedString = 0;
    [HideInInspector] private int _currentResponseTracker = 0;
    [HideInInspector] public int QuestToShow = 0;

    [HideInInspector] private GameObject _player;
    [SerializeField] public GameObject DialogueUI;
    [SerializeField] public GameObject ResponsePanel;

    [SerializeField] public TextMeshProUGUI NpcName;
    [SerializeField] public TextMeshProUGUI NpcDialogueBox;
    [SerializeField] public TextMeshProUGUI PlayerResponse;

    [HideInInspector] public QuestGiver QuestGiver;
    #endregion
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        QuestGiver = GetComponent<QuestGiver>();

        AISystem = GameObject.FindGameObjectWithTag("NPC").GetComponent<AISystem>();
    }

    private void Start()
    {
        DialogueUI.SetActive(false);
        changeQuestInDialogue();
    }

    private void Update()
    {
        //This is being tested rn.
        //renderPlayerDialogue();
        dialogueHandler();        
    }

    /// <summary>
    /// This function handles the dialogue. When you scroll you can scroll trough the things you can say to the NPC.
    /// When you press enter it answers the npc with the current response.
    /// </summary>
    private void dialogueHandler()
    {
        if (isTalking == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                _currentResponseTracker++;
                if (_currentResponseTracker >= npc.PlayerDialogue.Length - 1)
                {
                    _currentResponseTracker = npc.PlayerDialogue.Length - 1;
                }
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                _currentResponseTracker--;
                if (_currentResponseTracker < 0)
                {
                    _currentResponseTracker = 0;
                }
            }

            PlayerResponse.text = npc.PlayerDialogue[_currentResponseTracker];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                NpcDialogueBox.text = npc.Dialogue[_currentResponseTracker + 1];
                CurrentQuest();
            }
        }
    }

    public int CurrentQuest()
    {
        if (npc != null)
        {
            if (npc.Quests.Length > 0)
            {
                for (int i = 0; i < npc.Quests.Length; i++)
                {
                    if (NpcDialogueBox.text.Contains(npc.Quests[i].Title))
                    {
                        OpenQuest = true;
                        return i;
                    }
                }
            }
        }

        OpenQuest = false;
        return -1;

    }

    /// <summary>
    /// This function will change the names in the dialogue scriptable object to the quest that is selected.
    /// In Scriptable Objects, you can't add code to the strings, so it has to be done like this.
    /// </summary>
    private void changeQuestInDialogue()
    {
        if (npc != null)
        {
            for (int i = 0; i < npc.Dialogue.Length; i++)
            {
                if (npc.Dialogue[i].Contains(npc.ToBeReplaced[_currentCheckedString]))
                {
                    string replacedString = npc.Dialogue[i].Replace(npc.ToBeReplaced[_currentCheckedString], npc.Quests[_currentCheckedString].Title);
                    npc.Dialogue[i] = replacedString;
                    if (_currentCheckedString < (npc.ToBeReplaced.Length - 1))
                    {
                        _currentCheckedString++;
                    }
                }
            }
        }
    }

    /// <summary>
    /// This function will reset the names in the dialogue scriptable object to the original name to be renamed.
    /// </summary>
    private void resetQuestInDialogue()
    {
        for (int i = npc.Dialogue.Length - 1; i > 0; i--)
        {
            if (npc.Dialogue[i].Contains(npc.Quests[_currentCheckedString].Title))
            {
                string resetString = npc.Dialogue[i].Replace(npc.Quests[_currentCheckedString].Title, npc.ToBeReplaced[_currentCheckedString]);
                npc.Dialogue[i] = resetString;

                if (_currentCheckedString != 0)
                {
                    _currentCheckedString--;
                }
            }

            if (i == 0)
            {
                _currentCheckedString = 0;
            }
        }
    }

    private void renderPlayerDialogue()
    {
        for(int i = 0; i < npc.PlayerDialogue.Length; i++)
        {
            Debug.Log("Faka");
            Vector3 ResponsePanelPosition = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z);
            Instantiate(ResponsePanel, ResponsePanelPosition, transform.rotation);
            ResponsePanelPosition.x = +10;
        }
    }

    public void StartConversation()
    {
            isTalking = true;
            _currentResponseTracker = 0;
            DialogueUI.SetActive(true);
            NpcName.text = npc.name;
            NpcDialogueBox.text = npc.Dialogue[0];     
    }

    public void EndDialogue()
    {
        isTalking = false;
        DialogueUI.SetActive(false);
    }

    public void OnApplicationQuit()
    {
        resetQuestInDialogue();
    }
}
