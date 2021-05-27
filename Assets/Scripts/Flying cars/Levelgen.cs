using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levelgen : MonoBehaviour
{

    public List<GameObject> levelGround = new List<GameObject>();
    public List<float> height = new List<float>();

    private int randomRange = 0;
    private float lastPos = 0;
    private float lastScale = 0;

    public void RandomGen ()
    {

        randomRange = Random.Range(0, levelGround.Count);

        for (int i = 0; i < levelGround.Count; i++)
        {

            CreateLevelGround(levelGround[i], height[i], i);

        }

    }

    public void CreateLevelGround (GameObject obj, float height, int value)
    {

        if (randomRange == value)
        {

            GameObject go = Instantiate(obj) as GameObject;

            float offset = lastPos + (lastScale * 0.5f);
            offset += (go.transform.localScale.z) * 0.5f;
            Vector3 pos = new Vector3(0, height, offset);

            go.transform.position = pos;

            lastPos = go.transform.position.z;
            lastScale = go.transform.localScale.z;

            go.transform.parent = this.transform;

        }

    }

}
