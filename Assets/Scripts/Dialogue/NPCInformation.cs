using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Made by: Jorrit Bos
[CreateAssetMenu(fileName = "NPC File", menuName = "NPC Files Archive")]
public class NPCInformation : ScriptableObject
{
    [Header("Name of the NPC")]
    public string Name;
    [TextArea(3, 15)]

    [Header("Dialogue")]
    public string[] Dialogue;
    [TextArea(3, 15)]
    public string[] PlayerDialogue;

    [Header("Quests")]
    public Quest[] Quests;
    public string[] ToBeReplaced;

}
