using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Made by: Jorrit Bos
public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;

    float Distance;
    int CurrentResponseTracker = 0;

    public GameObject Player;
    public GameObject DialogueUI;

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
        dialogueHandler();
    }

    private void dialogueHandler()
    {
        if(isTalking == true)
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
