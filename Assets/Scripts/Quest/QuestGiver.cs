using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private QuestKeeper _questKeeper;
    [HideInInspector] private DialogueTextKeeper _dialogueTextKeeper;

    [HideInInspector] private GameObject _questWindow;

    [HideInInspector] private Quest _quest;
    [HideInInspector] private int _questNumber;

    public void Awake()
    {
        _questKeeper = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();
        _questWindow = DontDestroyUI.UIInstance.UIGameObjects[3];
        _dialogueTextKeeper = DontDestroyUI.UIInstance.UIGameObjects[0].GetComponent<DialogueTextKeeper>();
        _questWindow.SetActive(false);
    }

    public void Update()
    {
        if(_questKeeper != null)
        {
            if (_dialogueManager.CurrentQuest() >= 0)
            {
                _questNumber = _dialogueManager.CurrentQuest();
            }
        }
        
        if (_dialogueManager.NPC != null)
        {
            if (_dialogueManager.Npc.Quests.Length != 0)
            {
                _quest = _dialogueManager.Npc.Quests[_questNumber];
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
    }

    public void DeclineQuest()
    {
        _questWindow.SetActive(false);
    }
}
