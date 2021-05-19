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
    [SerializeField] private DialogueTextKeeper _dialogueTextKeeper;

    [HideInInspector] private bool _isTalking;
    [HideInInspector] public bool OpenQuest;

    [HideInInspector] private int _currentCheckedString = 0;
    [HideInInspector] private int _changedButton = -1;
    [HideInInspector] private bool SpawnNewDialogue;

    [SerializeField] private GameObject _dialogueUI;
    [HideInInspector] private GameObject _responsePanel;
    [HideInInspector] private GameObject _playerDialoguePanel;

    [HideInInspector] private List<GameObject> _playerResponsesList = new List<GameObject>();

    private Vector3 _lastPosition;
    #endregion
    private void Awake()
    {
        _playerDialoguePanel = GameObject.FindGameObjectWithTag("PlayerDialoguePanel");
        _responsePanel = GameObject.FindGameObjectWithTag("ResponsePanel");
    }

    private void Start()
    {
        _dialogueUI.SetActive(false);
        changeQuestInDialogue();
    }

    private void Update()
    {
        ButtonClick();
    }

    /// <summary>
    /// This function just triggers everything to make the conversation possible
    /// </summary>
    public void StartConversation()
    {
        DestroyResponses();
        _isTalking = true;
        _dialogueUI.SetActive(true);
        renderPlayerDialogue();
        _dialogueTextKeeper.NPCNameText.text = Npc.name;
        _dialogueTextKeeper.NPCDialogueText.text = Npc.Dialogue[0];
        _dialogueTextKeeper.NPCPicture.sprite = Npc.Picture;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    /// <summary>
    /// This function just checks which message it has to show for the NPC after a button has been clicked.
    /// </summary>
    public void ButtonClick()
    {
        if (_isTalking == true)
        {
            for (int i = 0; i < _playerResponsesList.Count; i++)
            {
                int textToShow = i;
                _playerResponsesList[textToShow].GetComponent<Button>().onClick.RemoveAllListeners();
                _playerResponsesList[textToShow].GetComponent<Button>().onClick.AddListener(() => ButtonClicked(textToShow));
                _playerResponsesList[textToShow].GetComponent<Button>().onClick.AddListener(() => changeButtonState(textToShow));
            }
            CurrentQuest();
        }
    }

    /// <summary>
    /// This will show the correct answer to your response of the NPC. This happens when you press on the player response.
    /// </summary>
    /// <param name="textToShow"></param>
    private void ButtonClicked(int textToShow)
    {
        _dialogueTextKeeper.NPCDialogueText.text = Npc.Dialogue[textToShow + 1];

        if (Npc.WhenToShowNewDialogue == textToShow)
        {
            if (SpawnNewDialogue == false)
            {
                RenderExtraDialogue(textToShow);
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
        if (Npc.ChoosingDialogue == true && SpawnNewDialogue == true)
        {
            if (currentButton > Npc.PlayerDialogue.Length - 1)
            {
                for (int i = 0/*npc.PlayerDialogue.Length*/; i < Npc.NewQuestion.Length + Npc.PlayerDialogue.Length; i++)
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
        _responsePanel.SetActive(true);
        for (int i = 0; i < Npc.PlayerDialogue.Length; i++)
        {
            _dialogueTextKeeper.PlayerDialogueText.text = Npc.PlayerDialogue[i];
            var instantiatedGO = Instantiate(_responsePanel);

            _playerResponsesList.Add(instantiatedGO);
            _playerResponsesList[i].transform.SetParent(_playerDialoguePanel.transform, false);
        }
        _responsePanel.SetActive(false);
    }

    /// <summary>
    /// This function makes it possible to add extra responses for the player when he said something else before. 
    /// This makes the dialogue system way more advanced :)
    /// </summary>
    /// <param name="textToShow"></param>
    private void RenderExtraDialogue(int textToShow)
    {
        if (Npc.WhenToShowNewDialogue != 0)
        {
            _responsePanel.SetActive(true);
            var listLength = _playerResponsesList.Count;
            if (Npc.WhenToShowNewDialogue == textToShow)
            {
                for (int i = 0; i < Npc.NewQuestion.Length; i++)
                {
                    _dialogueTextKeeper.PlayerDialogueText.text = Npc.NewQuestion[i];
                    var newDialogue = Instantiate(_responsePanel);
                    _playerResponsesList.Add(newDialogue);

                    _playerResponsesList[listLength + i].transform.SetParent(_playerDialoguePanel.transform, false);
                }
            }
            SpawnNewDialogue = true;
            _responsePanel.SetActive(false);
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
        if (Npc.ToBeReplaced.Length != 0)
        {
            for (int i = 0; i < Npc.Dialogue.Length; i++)
            {
                if (Npc.Dialogue[i].Contains(Npc.ToBeReplaced[_currentCheckedString]))
                {
                    string replacedString = Npc.Dialogue[i].Replace(Npc.ToBeReplaced[_currentCheckedString], Npc.Quests[_currentCheckedString].Title);
                    Npc.Dialogue[i] = replacedString;
                    if (_currentCheckedString < (Npc.ToBeReplaced.Length - 1))
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
        if (Npc.ToBeReplaced.Length != 0)
        {
            for (int i = Npc.Dialogue.Length - 1; i > 0; i--)
            {
                if (Npc.Dialogue[i].Contains(Npc.Quests[_currentCheckedString].Title))
                {
                    string resetString = Npc.Dialogue[i].Replace(Npc.Quests[_currentCheckedString].Title, Npc.ToBeReplaced[_currentCheckedString]);
                    Npc.Dialogue[i] = resetString;

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
    }

    /// <summary>
    /// This functions destroys all the responses of the player in the list. It will generate the new ones when you start talking with a NPC.
    /// </summary>
    private void DestroyResponses()
    {
        foreach (GameObject obj in _playerResponsesList)
        {
            Destroy(obj);
        }
        _playerResponsesList.Clear();
    }

    /// <summary>
    /// This function disables everything that is needed to stop the conversation
    /// </summary>
    public void EndDialogue()
    {
        _isTalking = false;
        Npc.ConversationFinished = true;
        DestroyResponses();
        _dialogueUI.SetActive(false);
        SpawnNewDialogue = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnApplicationQuit()
    {
        Npc.ConversationFinished = false;
        resetQuestInDialogue();
        DestroyResponses();
    }
}
