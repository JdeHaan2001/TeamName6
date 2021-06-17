using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gManager : MonoBehaviour
{
    public int levelCount = 1;
    public Levelgen  levelgen= null;


    private static gManager s_Instance;
    public static gManager Instance
    {

        get
        {

            if (s_Instance == null)
            {

                s_Instance = FindObjectOfType(typeof(gManager)) as gManager;

            }
            return s_Instance;
        }

    }

    void Start ()
    {

        for (int i = 0; i <levelCount; i++)
        {

            levelgen.RandomGen();

        }

    }




}
