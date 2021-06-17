using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made by: Jorrit Bos
public class QuestManager : MonoBehaviour
{
    [HideInInspector] private QuestKeeper _questKeeper;
    [HideInInspector] private Quest _quest;
    [HideInInspector] private Quest _latestQuest;
    [SerializeField] private List<Quest> _questOrder;

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
        checkWayPoint();
    }

    private Quest questChecker()
    {
        if (_questKeeper.Quest != null)
        {
            _latestQuest = _questKeeper.Quest;
        }

        for (int i = 0; i < _questOrder.Count; i++)
        {
            if (_latestQuest != null && _questKeeper.Quest != null)
            {
                if (_latestQuest.IsFinished != true)
                {
                    if (_questOrder[i] == _latestQuest)
                    {
                        return _questOrder[i];
                    }
                }
            }
            else if (_latestQuest != null && _questKeeper.Quest == null)
            {
                if (_latestQuest.IsFinished == true)
                {
                    return _questOrder[i + 1];
                }
            }
        }
        return null;
    }

    #region WayPoint
    private void checkWayPoint()
    {
        _quest = questChecker();

        if (_quest != null)
        {
            if (_quest.Goal.goalType == GoalType.Talking)
            {
                GameObject[] Npc = GameObject.FindGameObjectsWithTag("NPC");

                for (int i = 0; i < Npc.Length; i++)
                {
                    if (Npc[i].gameObject.name == _quest.Goal.npcToTalkTo.gameObject.name)
                    {
                        _wayPoint.SetActive(true);
                        _wayPointScript.GetWayPoint(Npc[i]);
                    }
                }
            }
            else if (_quest.Goal.goalType == GoalType.Picking)
            {
                GameObject[] Pickup = GameObject.FindGameObjectsWithTag("Pickup");

                for (int i = 0; i < Pickup.Length; i++)
                {
                    if (Pickup[i].gameObject.name == _quest.Goal.ItemToGet)
                    {
                        _wayPoint.SetActive(true);
                        _wayPointScript.GetWayPoint(Pickup[i]);
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
