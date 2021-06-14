using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariants : MonoBehaviour
{
    private static PlayerVariants _instance;
    public static PlayerVariants Instance { get { return _instance; } }
    public PlayerStats[] Players;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(_instance);
    }
}
