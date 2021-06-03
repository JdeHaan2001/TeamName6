using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCVert : MonoBehaviour
{

    [HideInInspector] bool goUp = false;
    public bool goDown = false;

    public List<GameObject> items = new List<GameObject>();
    public List<SpawnerVert> spawnerUp = new List<SpawnerVert>();



    void Start()
    {

        int itemId = Random.Range(0, items.Count);
        GameObject item = items[itemId];

        int direction = Random.Range(0, 2);


        if (direction > 0)
        {

            goUp = true;


        }



        for (int i = 0; i < spawnerUp.Count; i++)
        {

            spawnerUp[i].item = item;
            spawnerUp[i].goUp = goUp;
            spawnerUp[i].gameObject.SetActive(goUp);
            spawnerUp[i].spawnLPos = spawnerUp[i].transform.position.x;

        }


    }
}
