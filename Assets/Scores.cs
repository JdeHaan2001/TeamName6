using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Made By: Jorrit Bos
public class Scores : MonoBehaviour
{
    [HideInInspector] public int Followers = 0;
    [HideInInspector] public int Money = 0;

    [SerializeField] private TextMeshProUGUI _followerText;
    [SerializeField] private TextMeshProUGUI _moneyText;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _followerText.text = "Followers:" + Followers;
        _moneyText.text = "Money" + Money;

        Followers++;
    }
}
