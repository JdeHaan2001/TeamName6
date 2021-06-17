using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    [HideInInspector] bool goL = false;
    public bool goR = false;

    public List<GameObject> items = new List<GameObject>();

    public List<Spawner> spawnersR = new List<Spawner>();


    void Start()
    {

        int itemId = Random.Range(0, items.Count);
        GameObject item = items[itemId];

        int direction = Random.Range(0, 2);


        if (direction > 0)
        {

            goL = false;
            goR = false;

        }
        else 
        {
            goL = true;
            goR = false;

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
