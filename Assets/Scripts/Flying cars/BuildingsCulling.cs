using System.Collections;
using UnityEngine;

public class BuildingsCulling : MonoBehaviour
{

    public bool parentOnTrigger = true;
    public bool boxOnTrigger = false;
    public GameObject enemyObject = null;

    private Renderer renderer = null;
    private bool isVisible = false;

    void Start()
    {

        renderer = this.GetComponent<Renderer>();

    }

    void Update()
    {



        IsVisible();

    }

    void IsVisible()
    {

        if (renderer.isVisible)
        {

            isVisible = true;

        }

        if (!renderer.isVisible && isVisible)
        {

            Debug.Log("Buildings gone");

            Destroy(this.gameObject);

        }

    }
}
   
           
