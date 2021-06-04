using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonFunctions : MonoBehaviour
{
    private string _sceneName;
    private string _methodName;

    [HideInInspector] public bool playerChosen;

    public void InvokeGameScene(string methodName)
    {
        playerChosen = true;

        Invoke(methodName, 1);        
    }

    //This is part of the Invoke.
    public void LoadGameScene()
    {
        SceneManager.LoadScene("CityGray");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void DoExitGame()
    {
        Application.Quit();
    }

}