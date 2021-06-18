using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenBehaviour : MonoBehaviour
{
    [HideInInspector] private GameObject _inGameCanvas;
    [HideInInspector] private QuestKeeper _questKeeper;

    [SerializeField] private TextMeshProUGUI _status;
    [SerializeField] private TextMeshProUGUI _followerAmount;

    [SerializeField] private GameObject _eenzaamIcon;
    [SerializeField] private GameObject _bekendIcon;
    [SerializeField] private GameObject _beroemdIcon;
    [SerializeField] private GameObject _internetSterIcon;

    public void Awake()
    {
        _questKeeper = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();

        _followerAmount.text = _questKeeper.Followers.ToString();

        _eenzaamIcon.SetActive(false);
        _bekendIcon.SetActive(false);
        _beroemdIcon.SetActive(false);
        _internetSterIcon.SetActive(false);

        getIcon(_questKeeper.Followers);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void getIcon(int followerAmount)
    {
        if (followerAmount < 5000)
        {
            _eenzaamIcon.SetActive(true);
        }
        else if(followerAmount > 5000 && followerAmount < 10000)
        {
            _bekendIcon.SetActive(true);
        }
        else if (followerAmount > 10000 && followerAmount < 20000)
        {
            _beroemdIcon.SetActive(true);
        }
        else if (followerAmount > 20000)
        {
            _internetSterIcon.SetActive(true);
        }
    }
}
