using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Made by: Jorrit Bos
[CreateAssetMenu(fileName = "NPC File", menuName = "NPC Files Archive")]
public class NPC : ScriptableObject
{
    public string Name;
    [TextArea(3, 15)]
    public string[] Dialogue;
    [TextArea(3, 15)]
    public string[] PlayerDialogue;

    public string[] ToBeReplaced;
    public Quest[] Quests;

}
