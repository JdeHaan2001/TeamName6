using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


//Made by: Jorrit Bos
public class DialogueManager : MonoBehaviour
{
    #region Variables
    [HideInInspector] public NpcInformation Npc;

    [HideInInspector] public JsonNpc currentNpcDialogue;
    [HideInInspector] public JsonNpc firstNpcDialogue;

    [HideInInspector] public bool IsTalking;
    [HideInInspector] public bool OpenQuest;

    [HideInInspector] private int _oldPlayerDialogueAmount = 0;
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
    public AISystem GetNPC()
    {
        var NpcArray = GameObject.FindGameObjectsWithTag("NPC");

        for (int i = 0; i < NpcArray.Length; i++)
        {
            if (Vector3.Distance(_player.transform.position, NpcArray[i].transform.position) < 5f)
            {
                return NpcArray[i].GetComponent<AISystem>();
            }
        }
        return null;
    }

    /// <summary>
    /// Triggers the conversation with the NPC and the player.
    /// </summary>
    public void StartConversation()
    {
        Npc = GetNPC().NpcInfo;

        destroyResponses();
        IsTalking = true;
        _dialogueUI.SetActive(true);
        renderDialogue(Npc.NpcDialogue);
        firstNpcDialogue = JsonReader.LoadNpcFromFile(Npc.NpcDialogue);

        _dialogueTextKeeper.NPCNameText.text = currentNpcDialogue.Name;
        _dialogueTextKeeper.NPCDialogueText.text = currentNpcDialogue.Dialogue[0];
        _dialogueTextKeeper.NPCPicture.sprite = Npc.Picture;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// Checks which message it has to show based on what button you clicked
    /// </summary>
    public void ButtonClick()
    {
        if (_playerResponsesList.Count > 0)
        {
            for (int i = 0; i < _playerResponsesList.Count; i++)
            {
                int buttonClicked = i;
                _playerResponsesList[buttonClicked].GetComponent<Button>().onClick.RemoveAllListeners();
                _playerResponsesList[buttonClicked].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(buttonClicked));
                _playerResponsesList[buttonClicked].GetComponent<Button>().onClick.AddListener(() => changeButtonState(buttonClicked));
            }
        }
    }

    /// <summary>
    /// This will show the correct answer to your response of the NPC. This happens when you press on the player response.
    /// </summary>
    /// <param name="textToShow"></param>
    private void ButtonClicked(int textToShow)
    {
        _dialogueTextKeeper.NPCDialogueText.text = _npcDialogueList[textToShow + 1];

        checkChoosingStatus(textToShow);
        loadNewJson(textToShow);
    }

    /// <summary>
    /// Will change the state of the button (Color and interaction)
    /// </summary>
    /// <param name="buttonClicked"></param>
    private void changeButtonState(int buttonClicked)
    {
        if (_changedButton != -1)
        {
            if (_changedButton != buttonClicked)
            {
                _playerResponsesList[_changedButton].SetActive(false);
                _playerResponsesList[_changedButton].GetComponent<Button>().interactable = false;
                _playerResponsesList[_changedButton].GetComponent<Image>().color = Color.white;
            }
        }
        _playerResponsesList[buttonClicked].GetComponent<Image>().color = _dialogueTextKeeper.PlayerResponseSelectColor;
        _changedButton = buttonClicked;
    }

    /// <summary>
    /// Will render the dialogue. 
    /// </summary>
    private void renderDialogue(TextAsset jsonNpc)
    {
        _oldPlayerDialogueAmount = _playerResponsesList.Count;

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

        currentNpcDialogue = readJsonNpc;
    }

    /// <summary>
    /// Will load the new .json file
    /// </summary>
    /// <param name="buttonClicked"></param>
    private void loadNewJson(int buttonClicked)
    {
        try
        {
            if (currentNpcDialogue.NewDialogueFile[0].Contains("nothing") != true)
            {
                for (int i = 0; i < currentNpcDialogue.WhenToShowNewDialogue.Length; i++)
                {
                    if (currentNpcDialogue.WhenToShowNewDialogue[i] == buttonClicked - _oldPlayerDialogueAmount)
                    {
                        var newJson = currentNpcDialogue.NewDialogueFile[i];

                        TextAsset jsonAsset = Resources.Load(newJson) as TextAsset;
                        renderDialogue(jsonAsset);
                    }
                }
            }
        }
        catch
        {
            Debug.LogWarning("Something went wrong when trying to initialize a new Json File");
        }

    }

    /// <summary>
    /// Will check if a choice has been made when the dialogue is a choice.
    /// </summary>
    /// <param name="currentButton"></param>
    private void checkChoosingStatus(int currentButton)
    {
        if (currentNpcDialogue.ChoosingDialogue == true)
        {
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

    /// <summary>
    /// This will replace the Quest titles back to the "ToBeReplaced" string.
    /// </summary>
    private void resetQuestInDialogue()
    {
        try
        {
            if (currentNpcDialogue.ToBeReplaced.Length != 0)
            {
                for (int i = currentNpcDialogue.Dialogue.Length - 1; i > 0; i--)
                {
                    if (Npc.Quests.Length != 0)
                    {
                        if (currentNpcDialogue.Dialogue[i].Contains(Npc.Quests[_currentCheckedString].Title))
                        {
                            string resetString = currentNpcDialogue.Dialogue[i].Replace(Npc.Quests[_currentCheckedString].Title, currentNpcDialogue.ToBeReplaced[_currentCheckedString]);
                            currentNpcDialogue.Dialogue[i] = resetString;

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
        catch
        {
            Debug.LogWarning("Something went wrong during resetting quests in the dialogue.");
        }
    }

    /// <summary>
    /// This functions destroys all the responses of the player in the list.
    /// </summary>
    private void destroyResponses()
    {
        foreach (GameObject obj in _playerResponsesList)
        {
            obj.SetActive(true);
            Destroy(obj);
        }

        _playerResponsesList.Clear();
        _npcDialogueList.Clear();
        _changedButton = -1;
        _oldPlayerDialogueAmount = 0;
    }

    /// <summary>
    /// This function disables everything that is needed to stop the conversation.
    /// </summary>
    public void EndDialogue()
    {
        try
        {
            IsTalking = false;
            resetQuestInDialogue();
            destroyResponses();
            _dialogueUI.SetActive(false);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            if (Npc != null)
            {
                Npc.ConversationFinished = true;
            }

            Npc = null;
        }
        catch
        {
            Debug.LogWarning("Could not properly end the dialogue.");
        }
    }
        

    public void OnApplicationQuit()
    {
        Npc.ConversationFinished = false;
        resetQuestInDialogue();
        destroyResponses();
    }
}
