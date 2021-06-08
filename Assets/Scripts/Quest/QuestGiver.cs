using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    #region Variables
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private QuestKeeper _questKeeper;
    [HideInInspector] private DialogueTextKeeper _dialogueTextKeeper;
    [SerializeField] private NPCInformation Npc;

    [HideInInspector] private GameObject _questWindow;
    [HideInInspector] private Waypoint _waypoint;

    [HideInInspector] private Quest _quest;
    [HideInInspector] private int _questNumber;
    #endregion

    public void Awake()
    {
        _dialogueManager = DontDestroyUI.UIInstance.UIGameObjects[0].GetComponent<DialogueManager>();
        _questKeeper = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();
        _questWindow = DontDestroyUI.UIInstance.UIGameObjects[3];
        _dialogueTextKeeper = DontDestroyUI.UIInstance.UIGameObjects[0].GetComponent<DialogueTextKeeper>();
        //_waypoint = GameObject.FindGameObjectWithTag("WayPoint").GetComponent<Waypoint>();
        _questWindow.SetActive(false);
    }

    public void Update()
    {
        if(_dialogueManager.IsTalking == true)
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

            if (_dialogueManager.readNpcDialogue != null)
            {
                if (Npc.Quests.Length != 0)
                {
                    _quest = Npc.Quests[_questNumber];
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
        _questWindow.SetActive(false);
        _quest.IsActive = true;
        _questKeeper.Quest = _quest;
        //_waypoint.WayPointIcon.SetActive(true);
    }

    public void DeclineQuest()
    {
        _questWindow.SetActive(false);
    }
}
