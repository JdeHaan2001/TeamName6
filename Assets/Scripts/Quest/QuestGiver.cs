using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    [HideInInspector] private DialogueManager _dialogueManager;
    [HideInInspector] private QuestKeeper _questKeeper;
    [HideInInspector] private DialogueTextKeeper _dialogueTextKeeper;

    [SerializeField] private GameObject _questWindow;

    [HideInInspector] private Quest _quest;
    [HideInInspector] private int _questNumber;

    public void Awake()
    {
        _questKeeper = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();

        _questWindow.SetActive(false);
    }

    public void Update()
    {
        if (_dialogueManager != null)
        {
            _dialogueManager = GameObject.FindGameObjectWithTag("NPC").gameObject.GetComponent<DialogueManager>();
            _dialogueTextKeeper = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueTextKeeper>();

            if (_dialogueManager.CurrentQuest() >= 0)
            {
                _questNumber = _dialogueManager.CurrentQuest();
            }

            if (_dialogueManager.Npc != null)
            {
                if (_dialogueManager.Npc.Quests.Length != 0)
                {
                    _quest = _dialogueManager.Npc.Quests[_questNumber];
                }
            }
            OpenQuestWindow();
        }
    }

    public void OpenQuestWindow()
    {
        if (_dialogueManager.OpenQuest == true)
        {
            Debug.Log("Quest should be opened");
            _questWindow.SetActive(true);
            _dialogueTextKeeper.QuestName.text = _quest.Title;
            _dialogueTextKeeper.QuestDescription.text = _quest.Description;
            _dialogueTextKeeper.RewardsFollowers.text = "Followers: +" + _quest.FollowersReward;
            _dialogueTextKeeper.RewardsMoney.text = "Money: +" + _quest.MoneyReward;
        }
        else
        {
            _questWindow.SetActive(false);
        }
    }
    public void AcceptQuest()
    {
        _questWindow.SetActive(false);
        _quest.IsActive = true;
        _questKeeper.Quest = _quest;

        if (_quest.Goal.goalType == GoalType.Picking)
        {
            GameObject.FindGameObjectWithTag("Phone").GetComponent<PickupBehaviour>().IsPickable = true;
        }
    }

    public void DeclineQuest()
    {
        _questWindow.SetActive(false);
    }
}
