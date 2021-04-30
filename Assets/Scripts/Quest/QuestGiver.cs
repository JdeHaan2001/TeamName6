using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest Quest;
    public QuestGetter Player;

    public GameObject QuestWindow;
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI DescriptionText;
    public TextMeshProUGUI FollowerText;
    public TextMeshProUGUI MoneyText;

    public void OpenQuestWindow()
    {
        QuestWindow.SetActive(true);
        TitleText.text = Quest.Title;
        DescriptionText.text = Quest.Description;
        FollowerText.text = Quest.FollowersReward.ToString();
        MoneyText.text = Quest.MoneyReward.ToString();

    }
    public void AcceptQuest()
    {
        Quest.IsActive = true;
        Player.Quest = Quest;
    }
}
