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
    [HideInInspector] private AISystem _aiSystem;
    [SerializeField] public NPCInformation npc;

    [HideInInspector] private bool _isTalking;
    [HideInInspector] private bool _buttonClicked = false;
    [HideInInspector] public bool OpenQuest;
    [HideInInspector] public bool CheckNPC;
    [HideInInspector] public bool NPCChecked;

    [HideInInspector] private int _currentCheckedString = 0;
    [HideInInspector] private int _currentResponseTracker = 0;
    [HideInInspector] public int QuestToShow = 0;

    [HideInInspector] private GameObject _player;
    [SerializeField] public GameObject DialogueUI;
    [HideInInspector] private GameObject _responsePanel;

    [SerializeField] public TextMeshProUGUI NpcName;
    [SerializeField] public TextMeshProUGUI NpcDialogueBox;
    [SerializeField] public TextMeshProUGUI PlayerResponse;

    [HideInInspector] public QuestGiver QuestGiver;
    [SerializeField] public List<GameObject> InstantiatedPrefab = new List<GameObject>();
    #endregion
    private void Awake()
    {
        QuestGiver = GetComponent<QuestGiver>();
        _responsePanel = GameObject.FindGameObjectWithTag("ResponsePanel");
        _player = GameObject.FindGameObjectWithTag("Player");
        _aiSystem = GameObject.FindGameObjectWithTag("NPC").GetComponent<AISystem>();
    }

    private void Start()
    {
        DialogueUI.SetActive(false);
        changeQuestInDialogue();
    }

    private void Update()
    {
        DialogueHandler();
    }

    /// <summary>
    /// This function handles the dialogue. When you scroll you can scroll trough the things you can say to the NPC.
    /// When you press enter it answers the npc with the current response.
    /// </summary>
    //public void DialogueHandler()
    //{
    //    if (isTalking == true)
    //    {
    //        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
    //        {
    //            _currentResponseTracker++;
    //            if (_currentResponseTracker >= npc.PlayerDialogue.Length - 1)
    //            {
    //                _currentResponseTracker = npc.PlayerDialogue.Length - 1;
    //            }
    //        }
    //        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
    //        {
    //            _currentResponseTracker--;
    //            if (_currentResponseTracker < 0)
    //            {
    //                _currentResponseTracker = 0;
    //            }
    //        }

    //        PlayerResponse.text = npc.PlayerDialogue[_currentResponseTracker];
    //        if (Input.GetKeyDown(KeyCode.Return))
    //        {
    //            NpcDialogueBox.text = npc.Dialogue[_currentResponseTracker + 1];
    //            CurrentQuest();
    //        }
    //    }
    //}

    public void DialogueHandler()
    {
        if (_isTalking == true)
        {
            for (int i = 0; i < InstantiatedPrefab.Count; i++)
            {
                int textToShow = i;
                InstantiatedPrefab[textToShow].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(textToShow));
            }
            CurrentQuest();
        }
    }

    private int SpawnNewDialogue = 0;
    private void ButtonClicked(int textToShow)
    {
        NpcDialogueBox.text = npc.Dialogue[textToShow + 1];

        RenderExtraDialogue(textToShow);
        SpawnNewDialogue++;
    }

    private Vector3 _lastPosition;
    private void renderPlayerDialogue()
    {
        _lastPosition = _responsePanel.transform.position;
        _responsePanel.SetActive(true);
        for (int i = 0; i < npc.PlayerDialogue.Length; i++)
        {
            PlayerResponse.text = npc.PlayerDialogue[i];
            var instantiatedGO = Instantiate(_responsePanel, _lastPosition, _responsePanel.transform.rotation);

            InstantiatedPrefab.Add(instantiatedGO);
            InstantiatedPrefab[i].transform.SetParent(DialogueUI.transform, false);
            InstantiatedPrefab[i].transform.position = _lastPosition;

            _lastPosition.y = _lastPosition.y - 40.0f;
        }
        _responsePanel.SetActive(false);
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

    private void RenderExtraDialogue(int textToShow)
    {
        if(SpawnNewDialogue == 1)
        {
            if (_aiSystem.NPCInformation.WhenToShowNewDialogue != 0)
            {
                _responsePanel.SetActive(true);
                var listLength = InstantiatedPrefab.Count;
                if (_aiSystem.NPCInformation.WhenToShowNewDialogue == textToShow)
                {
                    for (int i = 0; i < _aiSystem.NPCInformation.NewQuestion.Length; i++)
                    {
                        PlayerResponse.text = _aiSystem.NPCInformation.NewQuestion[i];
                        var newDialogue = Instantiate(_responsePanel, _lastPosition, _responsePanel.transform.rotation);
                        InstantiatedPrefab.Add(newDialogue);

                        InstantiatedPrefab[listLength + i].transform.SetParent(DialogueUI.transform, false);
                        if(i == 0)
                        {
                            _lastPosition.y = _lastPosition.y + 40f;
                        }
                        InstantiatedPrefab[listLength + i].transform.position = _lastPosition;

                        _lastPosition.y = _lastPosition.y - 40f;
                        Debug.LogError(InstantiatedPrefab.Count);
                    }
                }
                _responsePanel.SetActive(false);
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

    public void StartConversation()
    {
        DestroyResponses();
        _isTalking = true;
        DialogueUI.SetActive(true);
        renderPlayerDialogue();
        NpcName.text = npc.name;
        NpcDialogueBox.text = npc.Dialogue[0];

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void DestroyResponses()
    {
        foreach (GameObject obj in InstantiatedPrefab)
        {
            Destroy(obj);
        }
        InstantiatedPrefab.Clear();
    }

    public void EndDialogue()
    {
        _isTalking = false;
        DestroyResponses();
        DialogueUI.SetActive(false);
        SpawnNewDialogue = 0;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnApplicationQuit()
    {
        resetQuestInDialogue();
        DestroyResponses();
    }
}
