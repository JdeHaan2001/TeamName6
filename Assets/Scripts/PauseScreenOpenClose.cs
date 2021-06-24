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
            if (pauseMenu.activeInHierarchy)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
        }
    }
}
