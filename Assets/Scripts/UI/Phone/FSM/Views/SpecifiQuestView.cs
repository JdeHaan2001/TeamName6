using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpecifiQuestView : PhoneView
{
    [SerializeField] private TextMeshProUGUI _missionName = null;
    [SerializeField] private TextMeshProUGUI _missionDescription = null;
    [SerializeField] private TextMeshProUGUI _followerReward = null;
    [SerializeField] private TextMeshProUGUI _moneyReward = null;
    [SerializeField] private Button _backButton = null;
    [SerializeField] private Button _homeButton = null;

    public TextMeshProUGUI MissionName { get => _missionName; }
    public TextMeshProUGUI MissionDescription { get => _missionDescription; }
    public TextMeshProUGUI FollowerReward { get => _followerReward; }
    public TextMeshProUGUI MoneyReward { get => _moneyReward; }
    public Button BackButton { get => _backButton; }
    public Button HomeButton { get => _backButton; }
}
