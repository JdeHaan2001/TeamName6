using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By: Jorrit Bos
[System.Serializable]
public class SkinButtonCharacteristics
{
    public string Title;

    public SkinTypes SkinTypes;

    public Color ButtonColor;
}

public enum SkinTypes
{
    Pale,
    Fair,
    Tan,
}

