using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

//Made by: Jorrit Bos
public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;

    int CurrentResponseTracker = 0;

    public GameObject Player;
    public GameObject DialogueUI;
    public GameObject ResponsePanel;

    public TextMeshProUGUI NpcName;
    public TextMeshProUGUI NpcDialogueBox;
    public TextMeshProUGUI PlayerResponse;

    // Start is called before the first frame update
    void Start()
    {
        DialogueUI.SetActive(false);
    }

    private void Update()
    {
        checkStrings();
        dialogueHandler();
    }

    private void dialogueHandler()
    {
        if (isTalking == true)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                CurrentResponseTracker++;
                if (CurrentResponseTracker >= npc.PlayerDialogue.Length - 1)
                {
                    CurrentResponseTracker = npc.PlayerDialogue.Length - 1;
                }
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                CurrentResponseTracker--;
                if (CurrentResponseTracker < 0)
                {
                    CurrentResponseTracker = 0;
                }
            }

            PlayerResponse.text = npc.PlayerDialogue[CurrentResponseTracker];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                NpcDialogueBox.text = npc.Dialogue[CurrentResponseTracker + 1];
            }

            //for (int i = 0; i < npc.PlayerDialogue.Length; i++)
            //{
            //    Instantiate(ResponsePanel);
            //    NpcDialogueBox.text = npc.Dialogue[i];
            //}
        }
    }

    private int _current = 0;
    private bool _stringChanged;
    private void checkStrings()
    {
        for (int i = 0; i < npc.Dialogue.Length; i++)
        {
            Debug.LogWarning(_current);
            if (isTalking == true)
            {
                if (npc.Dialogue[i].Contains(npc.ToBeReplaced[_current]))
                {
                    string replacedString = npc.Dialogue[i].Replace(npc.ToBeReplaced[_current], npc.Quests[_current].Title);
                    npc.Dialogue[i] = replacedString;
                    _stringChanged = true;
                    if(_current < (npc.ToBeReplaced.Length - 1))
                    {
                        _current++;
                    }

                }
            }

            if (isTalking == false && _stringChanged == true)
            {
                if (npc.Dialogue[i].Contains(npc.Quests[_current].Title))
                {
                    _current = 0;
                    string resetString = npc.Dialogue[i].Replace(npc.Quests[_current].Title, npc.ToBeReplaced[_current]);
                    npc.Dialogue[i] = resetString;

                    if (_current < (npc.ToBeReplaced.Length - 1))
                    {
                        _current++;
                    }
                }

                if(i == npc.Dialogue.Length)
                {
                    _stringChanged = false;
                    _current = 0;
                }
            }
        }
    }

    public void StartConversation()
    {
        isTalking = true;
        CurrentResponseTracker = 0;
        DialogueUI.SetActive(true);
        NpcName.text = npc.name;
        NpcDialogueBox.text = npc.Dialogue[0];
    }

    public void EndDialogue()
    {
        isTalking = false;
        DialogueUI.SetActive(false);
    }

}
