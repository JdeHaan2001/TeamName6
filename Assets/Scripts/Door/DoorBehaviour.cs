using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehaviour : MonoBehaviour
{
    public string SceneToGo;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneToGo);
            //LoadPlayer();
            //SavePlayer();
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonCharacterController>());
    }

    public void LoadPlayer()
    {
        if(SaveSystem.path != null)
        {
            PlayerData data = SaveSystem.LoadPlayer();

            Vector3 position;
            position.x = data.Position[0];
            position.y = data.Position[1];
            position.z = data.Position[2];
            transform.position = position;
        }       
    }
}
