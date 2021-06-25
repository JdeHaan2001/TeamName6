using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//Made by: Jorrit Bos
[Serializable]
public class QuestConnection
{
    public Quest CurrentQuest;
    public Quest NextQuest;
}

public class QuestManager : MonoBehaviour
{
    [HideInInspector] private QuestKeeper _questKeeper;
    [HideInInspector] private Quest _quest;
    [HideInInspector] public Quest _CurrentTrackedQuest;
    [SerializeField] private QuestConnection[] _questConnections;

    [HideInInspector] private GameObject _wayPoint;
    [HideInInspector] private Waypoint _wayPointScript;
    [SerializeField] private GameObject _phoneUI;
    [SerializeField] private TextMeshProUGUI _screenMessage;

    private bool gameFinished;

    public void Awake()
    {
        _wayPoint = DontDestroyUI.UIInstance.UIGameObjects[4];
        _wayPointScript = DontDestroyUI.UIInstance.UIGameObjects[4].GetComponent<Waypoint>();
        _questKeeper = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();

        _phoneUI.SetActive(false);
        _screenMessage.text = "";
        gameFinished = false;
    }

    public void Update()
    {
        _quest = QuestChecker();

        getScene();
        getUnlocks();
        checkWayPoint();
        screenMessage();
    }

    public Quest QuestChecker()
    {
        if (_CurrentTrackedQuest == null)
        {
            _CurrentTrackedQuest = _questConnections[0].CurrentQuest;
        }

        if (_questKeeper.Quest != null)
        {
            _CurrentTrackedQuest = _questKeeper.Quest;
        }

        for (int i = 0; i < _questConnections.Length; i++)
        {
            if (_questConnections[i].CurrentQuest == _CurrentTrackedQuest)
            {
                if (_CurrentTrackedQuest.IsFinished != true)
                {
                    return _questConnections[i].CurrentQuest;
                }
                else if (_CurrentTrackedQuest.IsFinished == true)
                {
                    _CurrentTrackedQuest = _questConnections[i].NextQuest;
                    return _CurrentTrackedQuest;
                }
            }
        }
        return _CurrentTrackedQuest;
    }
    private void getScene()
    {
        for (int i = 0; i < _questConnections.Length; i++)
        {
            if (_questConnections[i].CurrentQuest == _quest)
            {
                if (_quest.IsFinished == true)
                {
                    if (_questConnections[i].NextQuest == null)
                    {
                        if(gameFinished == false)
                        {
                            SceneManager.LoadScene("ResultScreen");
                            gameFinished = true;
                        }
                    }
                }
            }
        }
    }

    private void getUnlocks()
    {
        if (_questConnections[0].CurrentQuest.Goal.IsReached())
        {
            _phoneUI.SetActive(true);
        }
    }

    void screenMessage()
    {
        if (_questKeeper.Quest != null)
        {
            if (_questKeeper.Quest.Goal.IsReached())
            {
                _screenMessage.text = QuestChecker().Title + " is completed!";
                Invoke("deleteScreenMessage", 4f);
            }
        }
    }

    public void deleteScreenMessage()
    {
        _screenMessage.text = "";
    }

    #region WayPoint
    private void checkWayPoint()
    {
        if (_quest != null)
        {
            GameObject[] Npc = GameObject.FindGameObjectsWithTag("NPC");

            if (_quest.IsActive != true)
            {
                for (int i = 0; i < Npc.Length; i++)
                {
                    for (int j = 0; j < Npc[i].GetComponent<AISystem>().NpcInformation.Quests.Length; j++)
                    {
                        if (Npc[i].GetComponent<AISystem>().NpcInformation.Quests[j] == _quest)
                        {
                            _wayPoint.SetActive(true);
                            _wayPointScript.GetWayPoint(Npc[i]);
                        }
                    }

                }
            }
            else if (_quest.IsActive == true)
            {
                if (_quest.Goal.goalType == GoalType.Talking || _quest.Goal.goalType == GoalType.TakingPicture || _quest.Goal.goalType == GoalType.Giving)
                {
                    for (int i = 0; i < Npc.Length; i++)
                    {
                        if (Npc[i].gameObject.name == _quest.Goal.NpcToInteractWith.gameObject.name)
                        {
                            _wayPoint.SetActive(true);
                            _wayPointScript.GetWayPoint(Npc[i]);
                        }
                    }
                }
                else if (_quest.Goal.goalType == GoalType.Picking)
                {
                    if (_quest.Title == "Helpende Hand")
                    {
                        GameObject[] FinalPickUps = GameObject.FindGameObjectsWithTag("FinalQuestPickup");

                        for (int j = 0; j < FinalPickUps.Length; j++)
                        {
                            if (FinalPickUps[j].activeInHierarchy == true)
                            {
                                _wayPoint.SetActive(true);
                                _wayPointScript.GetWayPoint(FinalPickUps[j]);
                            }
                        }
                    }

                }
            }
        }
        else
        {
            _wayPoint.SetActive(false);
        }
    }
    #endregion
}
