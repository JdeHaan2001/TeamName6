using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By: Jorrit Bos
[System.Serializable]
public class HairButtonCharacteristics
{
    public string Title;

    public HairTypes HairTypes;

    public Color ButtonColor;
}

public enum HairTypes
{
    Straight, 
    Curly,
    Wavy
}
