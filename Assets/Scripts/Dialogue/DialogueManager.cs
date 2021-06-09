using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


//Made by: Jorrit Bos
public class DialogueManager : MonoBehaviour
{
    #region Variables
    [HideInInspector] public NPCInformation Npc;

    [HideInInspector] public JsonNpc readNpcDialogue;
    [HideInInspector] public bool IsTalking;
    [HideInInspector] public bool OpenQuest;

    [HideInInspector] private int _oldDialogueAmount = 0;
    [HideInInspector] private int _currentCheckedString = 0;
    [HideInInspector] private int _changedButton = -1;

    [HideInInspector] private GameObject _dialogueUI;
    [HideInInspector] private GameObject _playerDialogue;
    [HideInInspector] private GameObject _playerDialoguePanel;
    [HideInInspector] private GameObject _player;
    [SerializeField] public MonoBehaviour Camera;
    [HideInInspector] private DialogueTextKeeper _dialogueTextKeeper;

    [HideInInspector] private List<GameObject> _playerResponsesList = new List<GameObject>();
    [HideInInspector] private List<string> _npcDialogueList = new List<string>();

    #endregion
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _dialogueUI = DontDestroyUI.UIInstance.UIGameObjects[0];
        _playerDialoguePanel = DontDestroyUI.UIInstance.UIGameObjects[1];
        _playerDialogue = DontDestroyUI.UIInstance.UIGameObjects[2];
        _dialogueTextKeeper = DontDestroyUI.UIInstance.UIGameObjects[0].GetComponent<DialogueTextKeeper>();

        _dialogueUI.SetActive(false);
    }

    void OnEnable()
    {
        Camera.enabled = false;
    }

    void OnDisable()
    {
        Camera.enabled = true;
    }

    private void Update()
    {
        if (IsTalking == true)
        {
            ButtonClick();

        }
    }

    /// <summary>
    /// Gets the NPC when in range of the player.
    /// </summary>
    /// <returns></returns>
    public NPCInformation GetNPC()
    {
        var NpcArray = GameObject.FindGameObjectsWithTag("NPC");

        for (int i = 0; i < NpcArray.Length; i++)
        {
            if (Vector3.Distance(_player.transform.position, NpcArray[i].transform.position) < 10f)
            {
                return NpcArray[i].GetComponent<AISystem>().NpcInfo;
            }
        }
        return null;
    }

    /// <summary>
    /// Triggers the conversation with the NPC and the player.
    /// </summary>
    public void StartConversation()
    {
        Npc = GetNPC();

        destroyResponses();
        IsTalking = true;
        _dialogueUI.SetActive(true);
        renderDialogue(Npc.NpcDialogue);

        _dialogueTextKeeper.NPCNameText.text = readNpcDialogue.Name;
        _dialogueTextKeeper.NPCDialogueText.text = _npcDialogueList[0];
        _dialogueTextKeeper.NPCPicture.sprite = Npc.Picture;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    #region buttonFunctions
    /// <summary>
    /// Checks which message it has to show based on what button you clicked
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
        checkChoosingStatus(textToShow);

        loadNewJson(textToShow);
        _dialogueTextKeeper.NPCDialogueText.text = _npcDialogueList[textToShow + 1];
    }

    /// <summary>
    /// Will change the state of the button (Color and interaction)
    /// </summary>
    /// <param name="textToShow"></param>
    private void changeButtonState(int textToShow)
    {
        if (_changedButton != -1)
        {
            if (_changedButton != textToShow)
            {
                _playerResponsesList[_changedButton].SetActive(false);
                _playerResponsesList[_changedButton].GetComponent<Button>().interactable = false;
                _playerResponsesList[_changedButton].GetComponent<Image>().color = Color.white;
            }
        }
        _playerResponsesList[textToShow].GetComponent<Image>().color = _dialogueTextKeeper.PlayerResponseSelectColor;
        _changedButton = textToShow;
    }

    #endregion

    #region RenderDialogues

    /// <summary>
    /// Will render the dialogue. 
    /// </summary>
    private void renderDialogue(TextAsset jsonNpc)
    {
        _playerDialogue.SetActive(true);
        var readJsonNpc = JsonReader.LoadNpcFromFile(jsonNpc);
        changeQuestInDialogue(readJsonNpc);

        for (int i = 0; i < readJsonNpc.Dialogue.Length; i++)
        {
            _npcDialogueList.Add(readJsonNpc.Dialogue[i]);
        }

        var listLength = _playerResponsesList.Count;

        for (int i = 0; i < readJsonNpc.PlayerDialogue.Length; i++)
        {
            _dialogueTextKeeper.PlayerDialogueText.text = readJsonNpc.PlayerDialogue[i];
            var instantiatedGO = Instantiate(_playerDialogue);

            _playerResponsesList.Add(instantiatedGO);
            _playerResponsesList[listLength + i].transform.SetParent(_playerDialoguePanel.transform, false);
        }
        _playerDialogue.SetActive(false);

        _oldDialogueAmount = _oldDialogueAmount + readNpcDialogue.PlayerDialogue.Length;
        readNpcDialogue = readJsonNpc;
    }

    /// <summary>
    /// Will load the new .json file
    /// </summary>
    /// <param name="textToShow"></param>
    private void loadNewJson(int textToShow)
    {
        if (readNpcDialogue.WhenToShowNewDialogue == textToShow - _oldDialogueAmount)
        {
            var newJson = readNpcDialogue.NewDialogueFile;

            TextAsset jsonAsset = Resources.Load(newJson) as TextAsset;
            renderDialogue(jsonAsset);
        }
    }

    #endregion

    /// <summary>
    /// Will check if a choice has been made when the dialogue is a choice.
    /// </summary>
    /// <param name="currentButton"></param>
    private void checkChoosingStatus(int currentButton)
    {
        if (readNpcDialogue.ChoosingDialogue == true)
        {
            Debug.Log(readNpcDialogue.Dialogue[0]);
            for (int i = 0; i < _playerResponsesList.Count; i++)
            {
                if (_playerResponsesList[i] != _playerResponsesList[currentButton])
                {
                    _playerResponsesList[i].SetActive(false);
                }
            }
        }
    }

    /// <summary>
    /// Will check if dialogue contains a title of the quest, if so, it will show up in the game.
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
    /// Will change the "ToBeReplaced" string into the quest title.
    /// This is done because ScriptableObject strings can't contain code.
    /// </summary>
    private void changeQuestInDialogue(JsonNpc jsonNpc)
    {
        try
        {
            if (jsonNpc.ToBeReplaced.Length != 0)
            {
                if (Npc.Quests.Length != 0)
                {
                    for (int i = 0; i < jsonNpc.Dialogue.Length; i++)
                    {
                        if (jsonNpc.Dialogue[i].Contains(jsonNpc.ToBeReplaced[_currentCheckedString]))
                        {
                            string replacedString = jsonNpc.Dialogue[i].Replace(jsonNpc.ToBeReplaced[_currentCheckedString], Npc.Quests[_currentCheckedString].Title);
                            jsonNpc.Dialogue[i] = replacedString;
                            if (_currentCheckedString < (jsonNpc.ToBeReplaced.Length - 1))
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

    #region ResettingDialogue
    /// <summary>
    /// This will replace the Quest titles back to the "ToBeReplaced" string.
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
    /// This functions destroys all the responses of the player in the list.
    /// </summary>
    private void destroyResponses()
    {
        foreach (GameObject obj in _playerResponsesList)
        {
            Destroy(obj);
        }
        _playerResponsesList.Clear();
        _npcDialogueList.Clear();
    }

    /// <summary>
    /// This function disables everything that is needed to stop the conversation.
    /// </summary>
    public void EndDialogue()
    {
        IsTalking = false;
        Npc.ConversationFinished = true;
        destroyResponses();
        _dialogueUI.SetActive(false);

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
#endregion
