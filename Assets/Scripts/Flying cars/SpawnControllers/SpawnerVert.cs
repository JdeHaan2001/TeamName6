using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVert : MonoBehaviour
{

    [SerializeField] public GameObject Cars;

    public Transform startPos = null;
    public float delayMin = 1.5f;
    public float delayMax = 5f;
    public float speedMin = 1;
    public float speedMax = 4;

    public bool spawnPlace = false;
    public int spawnCountMin = 4;
    public int spawnCountMax = 20;

    private float lastTime = 0;
    private float delayTime = 0;
    private float speed = 0;

    [HideInInspector] public GameObject item = null;
    [HideInInspector] public bool goL = false;
    [HideInInspector] public bool goUp = false;
    [HideInInspector] public bool goDown = false;
    [HideInInspector] public float spawnLPos = 10;
    [HideInInspector] public float spawnRPos = 10;
    [HideInInspector] public float spawnUpPos = 10;
    [HideInInspector] public float spawnDownPos = 10;


    void Awake()
    {
        Cars = GameObject.FindGameObjectWithTag("Cars");
    }


    void Start()
    {

        //if (spawnPlace)
        //{

         int spawnCount = Random.Range(spawnCountMin, spawnCountMax);

        //    for (int i = 0; i < spawnCount; i++)
        //    {

        //        SpawnItem();

        //    }
        //}
        //else
        //{

        //    speed = Random.Range(speedMin, speedMax);

        //}
    }

    void Update()
    {

        if (spawnPlace) return;

        if (Time.time > lastTime + delayTime)
        {

            lastTime = Time.time;

            delayTime = Random.Range(delayMin, delayMax);

            SpawnItem();

        }

    }

    void SpawnItem()
    {

        Debug.Log("spawned");

        GameObject obj = Instantiate(item) as GameObject;

        obj.transform.position = GetSpawnPos();

        float direction = 0; if (goL) direction = 180;

        if (!spawnPlace)
        {
            obj.GetComponent<eMove>().speed = speed;

            obj.transform.rotation = obj.transform.rotation * Quaternion.Euler(0, direction, 0);
        }

        obj.transform.SetParent(Cars.transform, false);
    }

    Vector3 GetSpawnPos()
    {

        if (spawnPlace)
        {
            int x = (int)Random.Range(spawnLPos, spawnRPos);

            Vector3 pos = new Vector3(x, startPos.position.y, startPos.position.z);


            return pos;
        }
        else
        {

            return startPos.position;

        }

    }

}
