using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificQuestScreen : PhoneScreenWithView<SpecifiQuestView>
{
    [SerializeField] QuestKeeper _questKeeper = null;

    public override void EnterScreen()
    {
        base.EnterScreen();
        phoneView.BackButton.onClick.AddListener(_PFSM.ChangeScreen<QuestsScreen>);
        phoneView.HomeButton.onClick.AddListener(_PFSM.ChangeScreen<QuestsScreen>);
        setQuestValues();
    }

    private void setQuestValues()
    {
        if (_questKeeper != null)
        {
            phoneView.MissionName.text = _questKeeper.Quest.Title;
            phoneView.MissionDescription.text = _questKeeper.Quest.Description;
            phoneView.FollowerReward.text = _questKeeper.Quest.FollowersReward.ToString();
            phoneView.MoneyReward.text = _questKeeper.Quest.MoneyReward.ToString();
        }
    }
}
