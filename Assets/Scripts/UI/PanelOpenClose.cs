using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpenClose : MonoBehaviour {

    public void OpenPanel(GameObject Panel)
    {
        if (Panel != null)
        {
            if (!Panel.activeInHierarchy)
                Panel.SetActive(true);
        }
    }

    public void ClosePanel(GameObject Panel)
    {
        if (Panel != null)
        {
            if (Panel.activeInHierarchy)
            {
                Panel.SetActive(false);
                Time.timeScale = 1;
            }               
        }
    }
}