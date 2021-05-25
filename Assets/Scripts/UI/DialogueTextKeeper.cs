using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueTextKeeper : MonoBehaviour
{
    [Header("Dialogue Panel")]
    [SerializeField] public Image NPCPicture;
    [SerializeField] public TextMeshProUGUI NPCNameText;
    [SerializeField] public TextMeshProUGUI NPCDialogueText;

    [Header("Quest Panel")]
    [SerializeField] public TextMeshProUGUI QuestName;
    [SerializeField] public TextMeshProUGUI QuestDescription;
    [SerializeField] public TextMeshProUGUI RewardsFollowers;
    [SerializeField] public TextMeshProUGUI RewardsMoney;

    [Header("Player Response Panel")]
    [SerializeField] public TextMeshProUGUI PlayerDialogueText;

    [Header("Colors")]
    [SerializeField] public Color PlayerResponseSelectColor;
}
