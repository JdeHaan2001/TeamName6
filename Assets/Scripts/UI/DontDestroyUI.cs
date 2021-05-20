using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUI : MonoBehaviour
{
    private static DontDestroyUI _uiInstance;

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
        //if (_uiInstance != null && _uiInstance != this)
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //    _uiInstance = this;
        //}
        //DontDestroyOnLoad(this.gameObject);
    }
}

