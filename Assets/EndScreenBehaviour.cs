using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenBehaviour : MonoBehaviour
{
    [HideInInspector] private GameObject _inGameCanvas;
    [HideInInspector] private QuestKeeper _questKeeper;

    [Header("Follower Panel")]
    [SerializeField] private TextMeshProUGUI _followerStatus;
    [SerializeField] private TextMeshProUGUI _followerAmount;

    [SerializeField] private GameObject _eenzaamIcon;
    [SerializeField] private GameObject _bekendIcon;
    [SerializeField] private GameObject _beroemdIcon;
    [SerializeField] private GameObject _internetSterIcon;

    [Header("Moral Panel")]
    [SerializeField] private GameObject _goodBackground;
    [SerializeField] private GameObject _badBackground;
    [SerializeField] private TextMeshProUGUI _moralStatus;
    [SerializeField] private TextMeshProUGUI _moralPoints;

    [Header("Outro VoiceOvers")]
    [SerializeField] private AudioClip _generalOutro;
    [SerializeField] private AudioClip _goodVoice;
    [SerializeField] private AudioClip _badVoice;



    public void Awake()
    {
        _questKeeper = GameObject.FindGameObjectWithTag("Player").GetComponent<QuestKeeper>();

        //Follower Panel
        _followerAmount.text = _questKeeper.Followers.ToString();

        _eenzaamIcon.SetActive(false);
        _bekendIcon.SetActive(false);
        _beroemdIcon.SetActive(false);
        _internetSterIcon.SetActive(false);

        getIcon(_questKeeper.Followers);

        //Moral Panel
        _goodBackground.SetActive(false);
        _badBackground.SetActive(true);
        _moralPoints.text = _questKeeper.Moral.ToString();
        getMoralFeedback(_questKeeper.Moral);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void getIcon(int followerAmount)
    {
        if (followerAmount < 5000)
        {
            _eenzaamIcon.SetActive(true);
        }
        else if (followerAmount > 5000 && followerAmount < 10000)
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

    private void getMoralFeedback(int moralPoints)
    {
        if (moralPoints >= 0)
        {
            _goodBackground.SetActive(true);
            Sound.PlaySound(_goodVoice, this.gameObject);
        }
        else if (moralPoints < 0)
        {
            _goodBackground.SetActive(false);
            Sound.PlaySound(_badVoice, this.gameObject);
        }
        StartCoroutine(generalOutro(_goodVoice.length));
    }

    IEnumerator generalOutro(float delay)
    {
        yield return new WaitForSeconds(delay + 0.5f);
        Sound.PlaySound(_generalOutro, this.gameObject);
    }
}
