using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made by: Jorrit
public class QuestGiver : MonoBehaviour
{
    #region Variables
    [HideInInspector] private DialogueManager _dialogueManager;
    [HideInInspector] private QuestKeeper _questKeeper;
    [HideInInspector] private DialogueTextKeeper _dialogueTextKeeper;
    [HideInInspector] private QuestManager _questManager;
    [HideInInspector] public NPCInformation Npc;

    [HideInInspector] private GameObject _questWindow;
    [HideInInspector] private Waypoint _waypoint;

    [HideInInspector] private Quest _quest;
    [HideInInspector] private int _questNumber;
    #endregion

    public void Awake()
    {
        _dialogueManager = DontDestroyUI.UIInstance.UIGameObjects[0].GetComponent<DialogueManager>();
        _questKeeper = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();
        _questManager = GameObject.FindGameObjectWithTag("QuestManager").GetComponent<QuestManager>();
        _questWindow = DontDestroyUI.UIInstance.UIGameObjects[3];
        _dialogueTextKeeper = DontDestroyUI.UIInstance.UIGameObjects[0].GetComponent<DialogueTextKeeper>();
        _questWindow.SetActive(false);
    }

    public void Update()
    {
        if (_dialogueManager.IsTalking == true)
        {
            if (Npc == null)
            {
                Npc = _dialogueManager.Npc;
            }

            if (_questKeeper != null)
            {
                if (_dialogueManager.CurrentQuest() >= 0)
                {
                    _questNumber = _dialogueManager.CurrentQuest();
                }
            }

            if (_dialogueManager.CurrentNpcDialogue != null)
            {
                if (_dialogueManager.GetNPC().NpcInformation.Quests.Length != 0)
                {
                    if (_questNumber != -1)
                    {
                        _quest = _dialogueManager.GetNPC().NpcInformation.Quests[_questNumber];
                    }
                }
            }

            if (_dialogueManager.OpenQuest == true)
            {
                OpenQuestWindow();
            }
            else
            {
                _questWindow.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Opens the quest window
    /// </summary>
    public void OpenQuestWindow()
    {
        _questWindow.SetActive(true);

        _dialogueTextKeeper.QuestName.text = _quest.Title;
        _dialogueTextKeeper.QuestDescription.text = _quest.Description;
        _dialogueTextKeeper.RewardsFollowers.text = "Followers: +" + _quest.FollowersReward;
        _dialogueTextKeeper.RewardsMoney.text = "Money: +" + _quest.MoneyReward;

        _dialogueManager.OpenQuest = false;
    }

    public void AcceptQuest()
    {
        setQuestActive(true);

        _dialogueManager.EndDialogue();
        _questWindow.SetActive(false);
    }

    public void DeclineQuest()
    {  
        setQuestActive(false);

        _dialogueManager.EndDialogue();
        _questWindow.SetActive(false);
    }

    private void setQuestActive(bool accepted)
    {
        _questKeeper.Quest = _quest;

        if (accepted == true)
        {
            _questKeeper.Quest.IsActive = true;
            _dialogueManager.GetNPC().NpcInformation.ConversationFinished = true;
        }
        else if (accepted == false)
        {
            if (_quest.SideQuest == true)
            {
                _dialogueManager.GetNPC().NpcInformation.ConversationFinished = true;

                _questKeeper.Followers = -_quest.FollowersDecrease;
                _questKeeper.Money = -_quest.MoneyDecrease;
                _questKeeper.Moral = _quest.DeclineMoralPoints;
            }

            _questKeeper.Quest.IsActive = false;
        }
            _questKeeper.UpdateQuest();
    }
}
