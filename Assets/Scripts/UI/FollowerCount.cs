//Made by Jeroen de Haan

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class FollowerCount : MonoBehaviour
{
    [SerializeField] private List<Sprite> _statusIcons = null;
    [SerializeField] private List<string> _statusNames = null;
    [SerializeField] private List<int> _statusReachFollowersAmounts = null;

    [SerializeField] private TextMeshProUGUI _status = null;
    [SerializeField] private TextMeshProUGUI _followerAmountText = null;
    [Space()]

    [SerializeField] private Image _statusImage = null;

    [SerializeField] private Slider _slider = null;

    private readonly string helpText = "Status Icons and Status Names need to have the same amount of elements and they need to be in the same order. ";
    
    private int _followerAmount = 0;

    private Animator _animator = null;

    private CurrentStatus _currentStatus;

    public string HelpText => helpText;

    private enum CurrentStatus
    {
        EEENZAAM = 0, BEKEND = 1, BEROEMD = 2, INTERNET_STER = 3
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        updateFollowersAmount();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.J)) _animator.Play("New Animation");
        if (Input.GetKey(KeyCode.F)) AddFollowers(1000);
    }

    private void handleProgressBar()
    {
        int statusIndex = (int)_currentStatus;
        int followerReachAmount = _statusReachFollowersAmounts[statusIndex];
        float followerPercentage = ((float)_followerAmount / (float)followerReachAmount) * 100f;
        Debug.Log($"Status Index: {statusIndex}      Follower reach amount: {followerReachAmount}");
        _slider.value = followerPercentage;
    }

    private void handleStatus()
    {
        if (_followerAmount < _statusReachFollowersAmounts[0])
        {
            changeStatus(_statusIcons[0], _statusNames[0]);
            _currentStatus = CurrentStatus.EEENZAAM;
        }
        else if (_followerAmount < _statusReachFollowersAmounts[1] && _followerAmount > _statusReachFollowersAmounts[0])
        {
            changeStatus(_statusIcons[1], _statusNames[1]);
            _currentStatus = CurrentStatus.BEKEND;
        }
        else if (_followerAmount < _statusReachFollowersAmounts[2] && _followerAmount > _statusReachFollowersAmounts[1])
        {
            changeStatus(_statusIcons[2], _statusNames[2]);
            _currentStatus = CurrentStatus.BEROEMD;
        }
        else if (_followerAmount > _statusReachFollowersAmounts[2])
        {
            changeStatus(_statusIcons[3], _statusNames[3]);
            _currentStatus = CurrentStatus.INTERNET_STER;
        }
    }

    private void updateFollowersAmount()
    {
        _followerAmountText.text = _followerAmount.ToString();
        if (_followerAmount >= 1000000)
        {
            double followerMilAmount = _followerAmount / 1000000f;
            Debug.Log(followerMilAmount + "Before Rounding");
            followerMilAmount = Math.Round(followerMilAmount, 2);
            Debug.Log(followerMilAmount + "After Rounding");
            _followerAmountText.text = $"{followerMilAmount} Miljoen";
        }
        else
            _followerAmountText.text = _followerAmount.ToString();

        handleProgressBar();
        handleStatus();
    }

    private void changeStatus(Sprite pIcon, string pStatusText)
    {
        _statusImage.sprite = pIcon;
        _status.text = pStatusText;
    }

    public void AddFollowers(int pAmount)
    {
        _followerAmount += pAmount;
        updateFollowersAmount();
    }

    public void RemoveFollowers(int pAmount)
    {
        _followerAmount -= pAmount;
        updateFollowersAmount();
    }
}
