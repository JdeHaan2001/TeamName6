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

    [SerializeField] private Image _statusImage = null;

    private readonly string helpText = "Status Icons and Status Names need to have the same amount of elements and they need to be in the same order. ";

    private Dictionary<Sprite, string> _statusDict = new Dictionary<Sprite, string>();


    private int _followerAmount = 2653800;

    private Animator _animator = null;

    public string HelpText => helpText;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        handleStatusDictionary();
    }

    private void Start()
    {
        updateFollowersAmount();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.J)) _animator.Play("New Animation");
    }

    private void handleStatusDictionary()
    {
        int iconCount = _statusIcons.Count;
        int statusNamesCount = _statusNames.Count;

        if (iconCount != statusNamesCount)
            Debug.LogError("Icon count and names count are not equal. They need to be equal to be added to a dictionary");
        else
        {
            for (int i = 0; i < iconCount; i++)
            {
                _statusDict.Add(_statusIcons[i], _statusNames[i]);
            }
        }
    }

    private void handleStatus()
    {
        //TODO: Test this pls thank you
        if (_followerAmount < _statusReachFollowersAmounts[0])
        {
            changeStatus(_statusIcons[0], _statusNames[0]);
        }
        else if (_followerAmount < _statusReachFollowersAmounts[1] && _followerAmount > _statusReachFollowersAmounts[0])
        {
            changeStatus(_statusIcons[1], _statusNames[1]);
        }
        else if (_followerAmount < _statusReachFollowersAmounts[2] && _followerAmount > _statusReachFollowersAmounts[1])
        {
            changeStatus(_statusIcons[2], _statusNames[2]);
        }
    }

    private void updateFollowersAmount()
    {
        _followerAmountText.text = _followerAmount.ToString();
        if (_followerAmount >= 1000000)
        {
            double followerMilAmount = _followerAmount / 1000000f;
            Debug.Log(followerMilAmount + "Before Rounding");
            followerMilAmount = Math.Round(followerMilAmount, 1);
            Debug.Log(followerMilAmount + "After Rounding");
            _followerAmountText.text = $"{followerMilAmount} Miljoen";
        }
        else
            _followerAmountText.text = _followerAmount.ToString();
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
