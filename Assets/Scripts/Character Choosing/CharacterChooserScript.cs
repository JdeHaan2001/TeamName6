using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class CharacterChooserScript : MonoBehaviour
{
    private static CharacterChooserScript _instance;
    public static CharacterChooserScript instance => _instance;

    [SerializeField] public Player playerScript;

    //Used determining which and where to spawn choosing buttons
    [HideInInspector] private ChoosingButtonManager _buttonManager;
    [HideInInspector] private GameObject _buttonTemplate;
    [SerializeField] public TextMeshProUGUI ButtonTitle;

    [HideInInspector] private List<GameObject> _skinButtonsList = new List<GameObject>();
    [HideInInspector] private List<GameObject> _hairButtonsList = new List<GameObject>();

    [HideInInspector] private int _currentSkinType = -1;
    [HideInInspector] private int _currentHairType = -1;

    [HideInInspector] private SkinTypes _skinTypes;
    [HideInInspector] private HairTypes _hairTypes;

    [SerializeField] public GameObject GOSkinButtons;
    [SerializeField] public GameObject GOHairButtons;

    [SerializeField] private UIButtonFunctions _uiButtonFunctions;

    [HideInInspector] public int playerToShow;

    private void Awake()
    {
        _buttonManager = GameObject.FindGameObjectWithTag("ChooseButtons").GetComponent<ChoosingButtonManager>();
        _buttonTemplate = GameObject.FindGameObjectWithTag("ChoosingButtonTemplate");
        playerToShow = PlayerPrefs.GetInt("playerToPlay");

        SpawnButtons();
    }

    void Start()
    {
        var parentObject = Instantiate(playerScript.Players[playerToShow].Looks, transform.position, transform.rotation);
        parentObject.transform.parent = transform;
    }

    void Update()
    {
        buttonEvents();
        whenChoosingPlayer();
    }

    private void whenChoosingPlayer()
    {
        if (_uiButtonFunctions.playerChosen == true)
        {
            PlayerPrefs.SetInt("playerToPlay", playerToShow);
            _uiButtonFunctions.playerChosen = false;
        }
    }

    public void SpawnButtons()
    {
        if (_buttonManager != null)
        {
            if (_buttonManager.SkinTypesButton.Length != 0)
            {
                for (int i = 0; i < _buttonManager.SkinTypesButton.Length; i++)
                {
                    ButtonTitle.text = _buttonManager.SkinTypesButton[i].Title;
                    var InstantiatedSkinButtons = Instantiate(_buttonTemplate);

                    _skinButtonsList.Add(InstantiatedSkinButtons);

                    InstantiatedSkinButtons.transform.SetParent(GOSkinButtons.transform, false);
                }

                for (int i = 0; i < _buttonManager.HairTypesButton.Length; i++)
                {
                    ButtonTitle.text = _buttonManager.HairTypesButton[i].Title;
                    var InstantiatedHairButtons = Instantiate(_buttonTemplate);

                    _hairButtonsList.Add(InstantiatedHairButtons);

                    InstantiatedHairButtons.transform.SetParent(GOHairButtons.transform, false);
                }
            }
        }
        _buttonTemplate.SetActive(false);
    }

    private void buttonEvents()
    {
        if (_skinButtonsList.Count > 0)
        {
            for (int i = 0; i < _skinButtonsList.Count; i++)
            {
                int buttonToShow = i;
                _skinButtonsList[buttonToShow].GetComponent<Button>().onClick.RemoveAllListeners();
                _skinButtonsList[buttonToShow].GetComponent<Button>().onClick.AddListener(() => buttonClicked(buttonToShow));
                _skinButtonsList[buttonToShow].GetComponent<Button>().onClick.AddListener(() => changeSkinButtonState(buttonToShow));
            }
        }

        if (_hairButtonsList.Count > 0)
        {
            for (int i = 0; i < _hairButtonsList.Count; i++)
            {
                int buttonToShow = i;
                _hairButtonsList[buttonToShow].GetComponent<Button>().onClick.RemoveAllListeners();
                _hairButtonsList[buttonToShow].GetComponent<Button>().onClick.AddListener(() => buttonClicked(buttonToShow));
                _hairButtonsList[buttonToShow].GetComponent<Button>().onClick.AddListener(() => changeHairButtonState(buttonToShow));
            }
        }
    }

    private void buttonClicked(int buttonNumber)
    {
        _skinTypes = _buttonManager.SkinTypesButton[buttonNumber].SkinTypes;
        _hairTypes = _buttonManager.HairTypesButton[buttonNumber].HairTypes;
        spawnOtherPlayer();
    }

    private void changeSkinButtonState(int buttonNumber)
    {
        if (_currentSkinType != -1)
        {
            if (_currentSkinType != buttonNumber)
            {
                _skinButtonsList[_currentSkinType].GetComponent<Image>().color = Color.white;
            }
        }
        _skinButtonsList[buttonNumber].GetComponent<Image>().color = Color.red;
        _currentSkinType = buttonNumber;
    }

    private void changeHairButtonState(int buttonNumber)
    {
        if (_currentHairType != -1)
        {
            if (_currentHairType != buttonNumber)
            {
                _hairButtonsList[_currentHairType].GetComponent<Image>().color = Color.white;
            }
        }
        _hairButtonsList[buttonNumber].GetComponent<Image>().color = Color.red;
        _currentHairType = buttonNumber;
    }

    private GameObject getPlayer()
    {
        for (int i = 0; i < playerScript.Players.Length; i++)
        {
            if (playerScript.Players[i].SkinTypes == _skinTypes)
            {
                if (playerScript.Players[i].HairTypes == _hairTypes)
                {
                    return playerScript.Players[i].Looks;
                }
            }
        }
        return null;
    }

    private void spawnOtherPlayer()
    {
        Destroy(GameObject.FindWithTag("PlayerCharacter"));
        var parentObject = Instantiate(getPlayer(), transform.position, transform.rotation);
        parentObject.transform.parent = transform;
    }
}
