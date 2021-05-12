using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//Made by: Jorrit Bos
[CreateAssetMenu(fileName = "NPC File", menuName = "NPC Files Archive")]
public class NPCInformation : ScriptableObject
{
    [Header("Name of the NPC")]
    public string Name;
    public Sprite Picture;
    [TextArea(3, 15)]

    [Header("Dialogue")]
    public string[] Dialogue;

    [TextArea(3, 15)]
    public string[] PlayerDialogue;

    [Header("Extra Dialogue")]
    [TextArea(3, 15)]
    public string[] NewQuestion;
    public int WhenToShowNewDialogue;
    public bool ChoosingDialogue;

    [Header("Quests")]
    public Quest[] Quests;
    public string[] ToBeReplaced;
    public bool ConversationFinished;

}
