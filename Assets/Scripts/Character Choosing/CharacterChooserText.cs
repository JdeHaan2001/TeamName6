using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChooserText : MonoBehaviour
{
    public Player playerScript;
    public CharacterChooserScript characterChooserScript;

    public Text MyTextPlayerName;

    void Start()
    {
        MyTextPlayerName.text = "";
    }

    void Update()
    {
        MyTextPlayerName.text = "Name: " + playerScript.Players[characterChooserScript.playerToShow].Name;
    }
}
