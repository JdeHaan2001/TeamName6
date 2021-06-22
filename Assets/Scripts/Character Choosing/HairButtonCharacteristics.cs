using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By: Jorrit Bos
[System.Serializable]
public class HairButtonCharacteristics
{
    public HairTypes HairTypes;

    public Color ButtonColor;
}

public enum HairTypes
{
    Wit,
    Blond, 
    Bruin,
    Oranje,
    Donker
}
