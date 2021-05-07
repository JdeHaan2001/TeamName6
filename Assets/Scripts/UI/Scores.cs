using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Made By: Jorrit Bos
public class Scores : MonoBehaviour
{
    [HideInInspector] private QuestKeeper _questGetter;

    [SerializeField] private TextMeshProUGUI _followerText;
    [SerializeField] private TextMeshProUGUI _moneyText;

    private void Awake()
    {
        _questGetter = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();
    }
    void Update()
    {
        _followerText.text = "Followers: " + _questGetter.Followers;
        _moneyText.text = "Money: " + _questGetter.Money;
    }
}
