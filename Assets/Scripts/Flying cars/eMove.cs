using System.Collections;
using UnityEngine;

public class eMove : MonoBehaviour
{

    public float speed = 1.0f;
    public float mDirection = 0;
    public bool parentOnTrigger = true;
    public bool boxOnTrigger = false;
    public GameObject enemyObject = null;

    private Renderer renderer = null;
    private bool isVisible = false;

    void Start()
    {

        renderer = enemyObject.GetComponent<Renderer>();

    }

    void Update()
    {

        this.transform.Translate(speed *    Time.deltaTime, 0, 0);

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

            Destroy(this.gameObject);

        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            Debug.Log("enter");

            if (parentOnTrigger)
            {

                Debug.Log("Parent me");

                other.transform.parent = this.transform;

                
            }

            if (boxOnTrigger)
            {

                Debug.Log("GotHit");

                
            }

        }

    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            if (parentOnTrigger)
            {
                Debug.Log("exit");

                other.transform.parent = null;

                

            }
        }

    }
}
