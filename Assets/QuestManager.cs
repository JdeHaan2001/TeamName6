using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [HideInInspector] private AISystem _npcInfo;
    [HideInInspector] private AISystem _aiSystem;
    [HideInInspector] private QuestKeeper _questKeeper;
    [HideInInspector] private DialogueManager _dialogueManager;

    [HideInInspector] private Quest _quest;

    [HideInInspector] private GameObject _wayPoint;
    [SerializeField] private Waypoint _wayPointScript;

    public void Awake()
    {
        _wayPoint = DontDestroyUI.UIInstance.UIGameObjects[4];
        _wayPointScript = DontDestroyUI.UIInstance.UIGameObjects[4].GetComponent<Waypoint>();
        _questKeeper = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();

        _wayPoint.SetActive(false);
    }

    public void Update()
    {
        if (_questKeeper.Quest != null)
        {
            _quest = _questKeeper.Quest;
        }

        if (_quest != null)
        {
            if (_quest.Goal.goalType == GoalType.Talking)
            {
                GameObject[] Npc = GameObject.FindGameObjectsWithTag("NPC");

                for (int i = 0; i < Npc.Length; i++)
                {
                    if (Npc[i] == _quest.Goal.npcToTalkTo)
                    {
                        getWayPoint(Npc[i]);
                        Debug.Log("It works");
                    }
                }
            }
        }
    }

    private void getWayPoint(GameObject target)
    {
        _wayPoint.SetActive(true);
        _wayPointScript.Target = target;
    }
}
