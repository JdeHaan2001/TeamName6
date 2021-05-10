//Made by Jeroen de haan

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameManager _instance;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayHit;
            if (Physics.Raycast(ray, out rayHit))
            {
                
                //rayHit.transform.gameObject.
                Debug.Log(rayHit.transform.gameObject.name);
            }
            //TODO: Add screen to change building
        }
    }
}
