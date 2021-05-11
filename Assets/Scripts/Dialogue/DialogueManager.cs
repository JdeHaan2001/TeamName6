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

    [HideInInspector] private bool isTalking;
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

    private bool oke = false;
    /// <summary>
    /// This function handles the dialogue. When you scroll you can scroll trough the things you can say to the NPC.
    /// When you press enter it answers the npc with the current response.
    /// </summary>
    public void DialogueHandler()
    {
        for (int i = 0; i < InstantiatedPrefab.Count; i++)
        {
            Button b = InstantiatedPrefab[i].GetComponent<Button>();
            b.onClick.AddListener(delegate () { oke = true; });
            if (oke == true)
            {
                Debug.Log(i);
                NpcDialogueBox.text = npc.Dialogue[i + 1];
                oke = false;
                break;
            }
            CurrentQuest();
        }
    }

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
    private void renderPlayerDialogue()
    {
        var lastPosition = _responsePanel.transform.position;
        _responsePanel.SetActive(true);
        for (int i = 0; i < npc.PlayerDialogue.Length; i++)
        {
            PlayerResponse.text = npc.PlayerDialogue[i];
            var instantiatedGO = Instantiate(_responsePanel, lastPosition, _responsePanel.transform.rotation);

            InstantiatedPrefab.Add(instantiatedGO);
            InstantiatedPrefab[i].transform.SetParent(DialogueUI.transform, false);
            InstantiatedPrefab[i].transform.position = lastPosition;

            lastPosition.y = lastPosition.y - 30.0f;
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
        isTalking = true;
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
        isTalking = false;
        DestroyResponses();
        DialogueUI.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnApplicationQuit()
    {
        resetQuestInDialogue();
        DestroyResponses();
    }
}
