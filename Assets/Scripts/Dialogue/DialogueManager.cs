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
    [SerializeField] public NPCInformation Npc;

    [HideInInspector] public JsonNpc readNpcDialogue;
    [HideInInspector] public bool IsTalking;
    [HideInInspector] public bool OpenQuest;

    [HideInInspector] private int _currentCheckedString = 0;
    [HideInInspector] private int _changedButton = -1;
    [HideInInspector] private bool SpawnNewDialogue;

    [SerializeField] private GameObject _dialogueUI;
    [SerializeField] private GameObject _playerDialogue;
    [SerializeField] private GameObject _playerDialoguePanel;
    [SerializeField] private GameObject _player;
    [SerializeField] private DialogueTextKeeper _dialogueTextKeeper;

    [HideInInspector] private List<GameObject> _playerResponsesList = new List<GameObject>();

    #endregion
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        Npc = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueManager>().Npc;


        _dialogueUI = DontDestroyUI.UIInstance.UIGameObjects[0];
        _playerDialoguePanel = DontDestroyUI.UIInstance.UIGameObjects[1];
        _playerDialogue = DontDestroyUI.UIInstance.UIGameObjects[2];
        _dialogueTextKeeper = DontDestroyUI.UIInstance.UIGameObjects[0].GetComponent<DialogueTextKeeper>();

        _dialogueUI.SetActive(false);
    }

    private void Update()
    {
        if (IsTalking == true)
        {
            readNpcDialogue = JsonReader.LoadNpcFromFile(Npc.NpcDialogue);
            ButtonClick();
        }

        openNewDialogue();
    }

    public NPCInformation GetNPC()
    {
        var NpcArray = GameObject.FindGameObjectsWithTag("NPC");

        for (int i = 0; i < NpcArray.Length; i++)
        {
            if (Vector3.Distance(_player.transform.position, NpcArray[i].transform.position) < 5f)
            {
                return NpcArray[i].GetComponent<AISystem>().NpcInfo;
            }
        }
        return null;
    }

    /// <summary>
    /// This function just triggers everything to make the conversation possible
    /// </summary>
    public void StartConversation()
    {
        destroyResponses();
        IsTalking = true;
        _dialogueUI.SetActive(true);
        renderPlayerDialogue();

        _dialogueTextKeeper.NPCNameText.text = readNpcDialogue.Name;
        _dialogueTextKeeper.NPCDialogueText.text = readNpcDialogue.Dialogue[0];
        _dialogueTextKeeper.NPCPicture.sprite = Npc.Picture;

        changeQuestInDialogue();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// This function just checks which message it has to show for the NPC after a button has been clicked.
    /// </summary>
    public void ButtonClick()
    {
        if (_playerResponsesList.Count > 0)
        {
            for (int i = 0; i < _playerResponsesList.Count; i++)
            {
                int textToShow = i;
                _playerResponsesList[textToShow].GetComponent<Button>().onClick.RemoveAllListeners();
                _playerResponsesList[textToShow].GetComponent<Button>().onClick.AddListener(() => buttonClicked(textToShow));
                _playerResponsesList[textToShow].GetComponent<Button>().onClick.AddListener(() => changeButtonState(textToShow));
            }
        }
    }

    /// <summary>
    /// This will show the correct answer to your response of the NPC. This happens when you press on the player response.
    /// </summary>
    /// <param name="textToShow"></param>
    private void buttonClicked(int textToShow)
    {
        _dialogueTextKeeper.NPCDialogueText.text = readNpcDialogue.Dialogue[textToShow + 1];

        if (readNpcDialogue.WhenToShowNewDialogue == textToShow)
        {
            if (SpawnNewDialogue == false)
            {
                renderExtraDialogue(textToShow);
            }
        }
        checkExtraDialogue(textToShow);
    }

    private void changeButtonState(int textToShow)
    {
        if (_changedButton != -1)
        {
            if (_changedButton != textToShow)
            {
                _playerResponsesList[_changedButton].GetComponent<Button>().interactable = false;
                _playerResponsesList[_changedButton].GetComponent<Image>().color = Color.white;
            }
        }
        _playerResponsesList[textToShow].GetComponent<Image>().color = _dialogueTextKeeper.PlayerResponseSelectColor;
        _changedButton = textToShow;
    }

    private void checkExtraDialogue(int currentButton)
    {
        if (readNpcDialogue.ChoosingDialogue == true && SpawnNewDialogue == true)
        {
            if (currentButton > readNpcDialogue.PlayerDialogue.Length - 1)
            {
                for (int i = 0; i < readNpcDialogue.ExtraDialogue.Length + readNpcDialogue.PlayerDialogue.Length; i++)
                {
                    if (_playerResponsesList[i] != _playerResponsesList[currentButton])
                    {
                        _playerResponsesList[i].SetActive(false);
                    }
                }
            }
        }
    }

    /// <summary>
    /// This function will render the player dialogue when you start talking with an NPC.
    /// It gets the player dialogue of the NPC and puts it in a list and then shows it on the screen.
    /// </summary>
    private void renderPlayerDialogue()
    {
        _playerDialogue.SetActive(true);
        for (int i = 0; i < readNpcDialogue.PlayerDialogue.Length; i++)
        {
            _dialogueTextKeeper.PlayerDialogueText.text = readNpcDialogue.PlayerDialogue[i];
            var instantiatedGO = Instantiate(_playerDialogue);

            _playerResponsesList.Add(instantiatedGO);
            _playerResponsesList[i].transform.SetParent(_playerDialoguePanel.transform, false);
        }
        _playerDialogue.SetActive(false);
    }

    /// <summary>
    /// This function makes it possible to add extra responses for the player when he said something else before. 
    /// This makes the dialogue system way more advanced :)
    /// </summary>
    /// <param name="textToShow"></param>
    private void renderExtraDialogue(int textToShow)
    {
        if (readNpcDialogue.WhenToShowNewDialogue != 0)
        {
            _playerDialogue.SetActive(true);
            var listLength = _playerResponsesList.Count;
            if (readNpcDialogue.WhenToShowNewDialogue == textToShow)
            {
                for (int i = 0; i < readNpcDialogue.ExtraDialogue.Length; i++)
                {
                    _dialogueTextKeeper.PlayerDialogueText.text = readNpcDialogue.ExtraDialogue[i];
                    var newDialogue = Instantiate(_playerDialogue);
                    _playerResponsesList.Add(newDialogue);

                    _playerResponsesList[listLength + i].transform.SetParent(_playerDialoguePanel.transform, false);
                }
            }
            SpawnNewDialogue = true;
            _playerDialogue.SetActive(false);
        }
    }

    /// <summary>
    /// This function will check which quest it has to show in the dialogue system.
    /// </summary>
    /// <returns></returns>
    public int CurrentQuest()
    {
        if (Npc.Quests != null)
        {
            for (int i = 0; i < Npc.Quests.Length; i++)
            {
                if (_dialogueTextKeeper.NPCDialogueText.text.Contains(Npc.Quests[i].Title))
                {
                    OpenQuest = true;
                    return i;
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
        try
        {
            if (readNpcDialogue.ToBeReplaced.Length != 0)
            {
                if (Npc.Quests.Length != 0)
                {
                    for (int i = 0; i < readNpcDialogue.Dialogue.Length; i++)
                    {
                        if (readNpcDialogue.Dialogue[i].Contains(readNpcDialogue.ToBeReplaced[_currentCheckedString]))
                        {
                            string replacedString = readNpcDialogue.Dialogue[i].Replace(readNpcDialogue.ToBeReplaced[_currentCheckedString], Npc.Quests[_currentCheckedString].Title);
                            readNpcDialogue.Dialogue[i] = replacedString;
                            if (_currentCheckedString < (readNpcDialogue.ToBeReplaced.Length - 1))
                            {
                                _currentCheckedString++;
                            }
                        }
                    }
                }
            }
        }
        catch
        {
            Debug.LogError("Something went while changing the quest in the dialogue:");
        }
    }

    /// <summary>
    /// This function will reset the names in the dialogue scriptable object to the original name to be renamed.
    /// </summary>
    private void resetQuestInDialogue()
    {
        if (readNpcDialogue.ToBeReplaced.Length != 0)
        {
            for (int i = readNpcDialogue.Dialogue.Length - 1; i > 0; i--)
            {
                if (Npc.Quests.Length != 0)
                {
                    if (readNpcDialogue.Dialogue[i].Contains(Npc.Quests[_currentCheckedString].Title))
                    {
                        string resetString = readNpcDialogue.Dialogue[i].Replace(Npc.Quests[_currentCheckedString].Title, readNpcDialogue.ToBeReplaced[_currentCheckedString]);
                        readNpcDialogue.Dialogue[i] = resetString;

                        if (_currentCheckedString != 0)
                        {
                            _currentCheckedString--;
                        }
                    }
                }


                if (i == 0)
                {
                    _currentCheckedString = 0;
                }
            }
        }
    }

    /// <summary>
    /// This functions destroys all the responses of the player in the list. It will generate the new ones when you start talking with a NPC.
    /// </summary>
    private void destroyResponses()
    {
        foreach (GameObject obj in _playerResponsesList)
        {
            Destroy(obj);
        }
        _playerResponsesList.Clear();
    }

    private void openNewDialogue()
    {
        if (IsTalking == true)
        {
            if (Input.GetKeyDown("q"))
            {
                var newReadStuff = JsonReader.LoadNpcFromFile(readNpcDialogue.NewDialogueFile);
                Debug.Log(newReadStuff.Name);
            }
        }
    }

    /// <summary>
    /// This function disables everything that is needed to stop the conversation
    /// </summary>
    public void EndDialogue()
    {
        IsTalking = false;
        Npc.ConversationFinished = true;
        destroyResponses();
        _dialogueUI.SetActive(false);
        SpawnNewDialogue = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnApplicationQuit()
    {
        Npc.ConversationFinished = false;
        resetQuestInDialogue();
        destroyResponses();
    }
}
