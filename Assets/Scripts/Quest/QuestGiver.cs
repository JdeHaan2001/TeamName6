using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    [HideInInspector] public DialogueManager DialogueManager;
    [SerializeField] public QuestKeeper QuestKeeper;

    [SerializeField] public GameObject QuestWindow;
    [SerializeField] public TextMeshProUGUI TitleText;
    [SerializeField] public TextMeshProUGUI DescriptionText;
    [SerializeField] public TextMeshProUGUI FollowerText;
    [SerializeField] public TextMeshProUGUI MoneyText;

    [HideInInspector] public Quest Quest;
    [HideInInspector] public int QuestNumber;

    public void Awake()
    {
        DialogueManager = GameObject.FindGameObjectWithTag("NPC").gameObject.GetComponent<DialogueManager>();
        QuestWindow.SetActive(false);
    }

    public void Update()
    {
        if(DialogueManager != null)
        {
            if(DialogueManager.CurrentQuest() >= 0)
            {
                QuestNumber = DialogueManager.CurrentQuest();
            }
            
            if (DialogueManager.npc != null)
            {
                Quest = DialogueManager.npc.Quests[QuestNumber];
            }
            OpenQuestWindow();
        }        
    }
    
    public void OpenQuestWindow()
    {
        if(DialogueManager.OpenQuest == true)
        {
            QuestWindow.SetActive(true);
            TitleText.text = Quest.Title;
            DescriptionText.text = Quest.Description;
            FollowerText.text = Quest.FollowersReward.ToString();
            MoneyText.text = Quest.MoneyReward.ToString();

            if (Input.GetKeyDown(KeyCode.Q))
            {
                AcceptQuest();
            }
        }
        else
        {
            QuestWindow.SetActive(false);
        }                 
    }
    public void AcceptQuest()
    {
        QuestWindow.SetActive(false);
        Quest.IsActive = true;
        QuestKeeper.Quest = Quest;

        GameObject.FindGameObjectWithTag("Phone").GetComponent<PickupBehaviour>().IsPickable = true;
    }
}
