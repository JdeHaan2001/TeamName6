using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenOpenClose : MonoBehaviour
{
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeInHierarchy)
            {
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0.0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
