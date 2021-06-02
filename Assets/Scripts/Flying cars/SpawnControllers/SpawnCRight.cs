using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCRight : MonoBehaviour
{
    [HideInInspector] bool goL = false;
    public bool goR = false;

    public List<GameObject> items = new List<GameObject>();
    public List<Spawner> spawnersL = new List<Spawner>();


    void Start()
    {

        int itemId = Random.Range(0, items.Count);
        GameObject item = items[itemId];

        int direction = Random.Range(0, 2);


        if (direction > 0)
        {

            goR = true;

        }


        for (int i = 0; i < spawnersL.Count; i++)
        {

            spawnersL[i].item = item;
            spawnersL[i].goL = goL;
            spawnersL[i].gameObject.SetActive(goR);
            spawnersL[i].spawnLPos = spawnersL[i].transform.position.x;

        }

    }

}
