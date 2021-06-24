using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LeaderBoard : MonoBehaviour
{
    private QuestKeeper _questGetter = null;

    private int _score = 0;

    private List<string> line = new List<string>();

    private void Awake()
    {
        //_questGetter = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();
        //_score = _questGetter.Moral;
        readFile();
    }

    private void readFile()
    {
        int counter = 0;
        StreamReader sr = new StreamReader("D:/Documents/GitHub/TeamName6/LeaderBoard.txt");
        line.Add(sr.ReadLine());

        while (line != null)
        {
            Debug.Log(line[counter]);

            line.Add(sr.ReadLine());
            counter++;
        }

        sr.Close();
    }

}
