using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestsView : PhoneView
{
    [SerializeField] private TextMeshProUGUI _missionName = null;
    [SerializeField] private TextMeshProUGUI _followerReward = null;
    [SerializeField] private TextMeshProUGUI _moneyReward = null;
    [SerializeField] private Button _selectButton = null;
    [SerializeField] private Button _homeButton = null;

    public TextMeshProUGUI MissionName { get => _missionName; }
    public TextMeshProUGUI FollowerReward { get => _followerReward; }
    public TextMeshProUGUI MoneyReward { get => _moneyReward; }
    public Button SelectButton { get => _selectButton; }
    public Button HomeButton { get => _homeButton; }
}
