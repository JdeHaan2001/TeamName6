using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUI : MonoBehaviour
{
    private static DontDestroyUI _uiInstance;
    
    public List<GameObject> UIGameObjects = new List<GameObject>();
    public static DontDestroyUI UIInstance
    {
        get
        {
            return _uiInstance;
        }
    }

    private void Awake()
    {
        if (_uiInstance == null)
        {
            _uiInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

