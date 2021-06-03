using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCUp : MonoBehaviour
{
    public bool goUp = false;
    [HideInInspector] bool goDown = false;

    public List<GameObject> items = new List<GameObject>();
    public List<SpawnerVert> spawnerDown = new List<SpawnerVert>();



    void Start()
    {

        int itemId = Random.Range(0, items.Count);
        GameObject item = items[itemId];

        int direction = Random.Range(0, 2);


        if (direction < 2)
        {

            goUp = false;
            goDown = true;

        }




        for (int i = 0; i < spawnerDown.Count; i++)
        {

            spawnerDown[i].item = item;
            spawnerDown[i].goUp = goUp;
            spawnerDown[i].gameObject.SetActive(goDown);
            spawnerDown[i].spawnLPos = spawnerDown[i].transform.position.x;

        }


    }
}
