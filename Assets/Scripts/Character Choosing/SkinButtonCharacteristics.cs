using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By: Jorrit Bos
[System.Serializable]
public class SkinButtonCharacteristics
{
    public SkinTypes SkinTypes;

    public Color ButtonColor;
}

public enum SkinTypes
{
    Wit,
    LichtWit,
    Getint,
    Bruin,
    Zwart
}

