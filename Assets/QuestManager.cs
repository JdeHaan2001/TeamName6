using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [HideInInspector] private Quest _currentTrackedQuest;
    [SerializeField] private QuestConnection[] _questConnections;

    [HideInInspector] private GameObject _wayPoint;
    [SerializeField] private Waypoint _wayPointScript;

    public void Awake()
    {
        _wayPoint = DontDestroyUI.UIInstance.UIGameObjects[4];
        _wayPointScript = DontDestroyUI.UIInstance.UIGameObjects[4].GetComponent<Waypoint>();
        _questKeeper = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();
    }

    public void Update()
    {
        getScene();
        checkWayPoint();
    }

    public Quest QuestChecker()
    {
        if (_questKeeper.Quest != null)
        {
            _currentTrackedQuest = _questKeeper.Quest;
        }

        for (int i = 0; i < _questConnections.Length; i++)
        {
            if (_questConnections[i].CurrentQuest == _currentTrackedQuest)
            {
                if (_currentTrackedQuest.IsActive == true)
                {
                    return _questConnections[i].CurrentQuest;
                }
                else if (_currentTrackedQuest.IsActive != true)
                {
                    return _questConnections[i].NextQuest;
                }
            }
        }
        return null;
    }
    private void getScene()
    {
        for (int i = 0; i < _questConnections.Length; i++)
        {
            if (_questConnections[i].CurrentQuest == _quest)
            {
                if(_quest.IsActive == false)
                {
                    if (_questConnections[i].NextQuest == null)
                    {
                        SceneManager.LoadScene("ResultScreen");
                    }
                }
            }
        }
    }

    #region WayPoint
    private void checkWayPoint()
    {
        _quest = QuestChecker();

        if (_quest != null)
        {
            if (_quest.Goal.goalType == GoalType.Talking || _quest.Goal.goalType == GoalType.TakingPicture || _quest.Goal.goalType == GoalType.Giving)
            {
                GameObject[] Npc = GameObject.FindGameObjectsWithTag("NPC");

                for (int i = 0; i < Npc.Length; i++)
                {
                    if (_quest.IsActive != true)
                    {
                        for (int j = 0; j < Npc[i].GetComponent<AISystem>().NpcInformation.Quests.Length; j++)
                        {
                            if (Npc[i].GetComponent<AISystem>().NpcInformation.Quests[j].name == _quest.name)
                            {
                                _wayPoint.SetActive(true);
                                _wayPointScript.GetWayPoint(Npc[i]);
                            }
                        }
                    }
                    else if (_quest.IsActive == true)
                    {
                        if (Npc[i].gameObject.name == _quest.Goal.NpcToInteractWith.gameObject.name)
                        {
                            _wayPoint.SetActive(true);
                            _wayPointScript.GetWayPoint(Npc[i]);
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
