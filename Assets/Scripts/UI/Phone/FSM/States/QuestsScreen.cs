using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsScreen : PhoneScreenWithView<QuestsView>
{
    [SerializeField] QuestKeeper _questKeeper = null;

    public override void EnterScreen()
    {
        base.EnterScreen();
        //phoneView.SelectButton.onClick.AddListener(_PFSM.ChangeScreen<>);
        setActiveQuestValues();
    }

    private void setActiveQuestValues()
    {
        phoneView.MissionName.text = _questKeeper.Quest.Title;
        phoneView.FollowerReward.text = _questKeeper.Quest.FollowersReward.ToString();
        phoneView.MoneyReward.text = _questKeeper.Quest.MoneyReward.ToString();
    }
}
