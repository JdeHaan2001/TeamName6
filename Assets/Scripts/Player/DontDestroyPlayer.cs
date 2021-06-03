using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPlayer : MonoBehaviour
{
    private static DontDestroyPlayer _playerInstance;

    public GameObject Player;

    public static DontDestroyPlayer PlayerInstance
    {
        get
        {
            return _playerInstance;
        }
    }

    private void Awake()
    {
        if (_playerInstance == null)
        {
            _playerInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
