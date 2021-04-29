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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        Color objectColor;
        if (Physics.Raycast(ray, out rayHit))
        {
            objectColor = rayHit.transform.GetComponent<Renderer>().material.color;
            rayHit.transform.GetComponent<Renderer>().material.color = new Color(objectColor.r, objectColor.g, objectColor.b, 255);
            Debug.Log(rayHit.transform.parent.gameObject.name);
        }

        if (Input.GetMouseButtonDown(0))
        {
            //TODO: Add screen to change building
        }
    }
}
