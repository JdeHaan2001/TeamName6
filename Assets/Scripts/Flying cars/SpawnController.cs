using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public bool goL = false;
    public bool goR = false;

    public List<GameObject> items = new List<GameObject>();
    public List<Spawner> spawnersL = new List<Spawner>();
    public List<Spawner> spawnersR = new List<Spawner>();


    void Start()
    {

        int itemId = Random.Range(0, items.Count);
        GameObject item = items[itemId];

        int direction = Random.Range(0, 2);


        if (direction > 0)
        {

                goL = false;
                goR = true;

        }
        else 
        {
            goL = true;
            goR = false;

        }


        for (int i = 0; i < spawnersL.Count; i++)
        {

            spawnersL[i].item = item;
            spawnersL[i].goL = goL;
            spawnersL[i].gameObject.SetActive(goR);
            spawnersL[i].spawnLPos = spawnersL[i].transform.position.x;

        }

        for (int i = 0; i < spawnersR.Count; i++)
        {

            spawnersR[i].item = item;
            spawnersR[i].goL = goL;
            spawnersR[i].gameObject.SetActive(goL);
            spawnersR[i].spawnRPos = spawnersR[i].transform.position.x;

        }

    }
}
