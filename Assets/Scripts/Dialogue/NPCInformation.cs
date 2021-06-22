using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//Made by: Jorrit Bos
[CreateAssetMenu(fileName = "NPC File", menuName = "NPC Files Archive")]
public class NpcInformation : ScriptableObject
{
    [Header("Name of the NPC")]
    public Sprite Picture;
    public TextAsset NpcDialogue;

    [Header("VoiceOvers")]
    public VoiceOvers voiceOvers;

    [Header("Quests")]
    public Quest[] Quests;

    public bool ConversationFinished;

}
