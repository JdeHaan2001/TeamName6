using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPlayer : MonoBehaviour
{
    private static DontDestroyPlayer _playerInstance;

    public static DontDestroyPlayer PlayerInstance
    {
        get
        {
            if (_playerInstance == null)
            {
                _playerInstance = GameObject.FindObjectOfType<DontDestroyPlayer>();
            }

            return _playerInstance;
        }
    }

    private void Awake()
    {
        if (_playerInstance != null && _playerInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _playerInstance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
