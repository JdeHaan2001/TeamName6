using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyQuestManager : MonoBehaviour
{
    private static DontDestroyQuestManager _questInstance;

    public GameObject QuestManager;

    public static DontDestroyQuestManager PlayerInstance
    {
        get
        {
            return _questInstance;
        }
    }

    private void Awake()
    {
        if (_questInstance == null)
        {
            _questInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
