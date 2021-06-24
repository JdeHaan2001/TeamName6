using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

// Made By: Jorrit Bos
public class CharacterChooserScript : MonoBehaviour
{
    private static CharacterChooserScript _instance;
    public static CharacterChooserScript instance => _instance;

    [SerializeField] public PlayerVariants playerScript;

    //Used determining which and where to spawn choosing buttons
    [HideInInspector] private ChoosingButtonManager _buttonManager;
    [HideInInspector] private GameObject _buttonTemplate;

    [HideInInspector] private List<GameObject> _skinButtonsList = new List<GameObject>();
    [HideInInspector] private List<GameObject> _hairButtonsList = new List<GameObject>();

    [HideInInspector] private int _currentSkinType = 0;
    [HideInInspector] private int _currentHairType = 0;

    [HideInInspector] private SkinTypes _skinTypes;
    [HideInInspector] private HairTypes _hairTypes;

    [SerializeField] public GameObject GOSkinButtons;
    [SerializeField] public GameObject GOHairButtons;
    [SerializeField] public Color SelectedColor;

    [SerializeField] private UIButtonFunctions _uiButtonFunctions;
    [SerializeField] private TMP_InputField _inputField;

    [HideInInspector] public int playerToShow;

    private void Awake()
    {
        _buttonManager = GameObject.FindGameObjectWithTag("ChooseButtons").GetComponent<ChoosingButtonManager>();
        _buttonTemplate = GameObject.FindGameObjectWithTag("ChoosingButtonTemplate");
        playerToShow = 0;

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

    public void SetPlayerName(string pName)
    {
        PlayerPrefs.SetString("playerName", pName);
        Debug.Log(pName);
    }

    private void whenChoosingPlayer()
    {
        if (_uiButtonFunctions.playerChosen == true)
        {
            PlayerPrefs.SetInt("playerToPlay", getPlayer());
            PlayerPrefs.SetString("playerName", getPlayerName());
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
                    _buttonTemplate.GetComponentInChildren<Button>().GetComponent<Image>().color = _buttonManager.SkinTypesButton[i].ButtonColor;
                    var InstantiatedSkinButtons = Instantiate(_buttonTemplate);

                    _skinButtonsList.Add(InstantiatedSkinButtons);

                    InstantiatedSkinButtons.transform.SetParent(GOSkinButtons.transform, false);
                }

                for (int i = 0; i < _buttonManager.HairTypesButton.Length; i++)
                {
                    _buttonTemplate.GetComponentInChildren<Button>().GetComponent<Image>().color = _buttonManager.HairTypesButton[i].ButtonColor;
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
                _skinButtonsList[buttonToShow].GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                _skinButtonsList[buttonToShow].GetComponentInChildren<Button>().onClick.AddListener(() => skinButtonClicked(buttonToShow));
                _skinButtonsList[buttonToShow].GetComponentInChildren<Button>().onClick.AddListener(() => changeSkinButtonState(buttonToShow));
            }
        }

        if (_hairButtonsList.Count > 0)
        {
            for (int i = 0; i < _hairButtonsList.Count; i++)
            {
                int buttonToShow = i;
                _hairButtonsList[buttonToShow].GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                _hairButtonsList[buttonToShow].GetComponentInChildren<Button>().onClick.AddListener(() => hairButtonClicked(buttonToShow));
                _hairButtonsList[buttonToShow].GetComponentInChildren<Button>().onClick.AddListener(() => changeHairButtonState(buttonToShow));
            }
        }
    }

    private void skinButtonClicked(int skinButtonNumber)
    {
        _skinTypes = _buttonManager.SkinTypesButton[skinButtonNumber].SkinTypes;
        spawnOtherPlayer();
    }

    private void hairButtonClicked(int hairButtonNumber)
    {
        _hairTypes = _buttonManager.HairTypesButton[hairButtonNumber].HairTypes;
        spawnOtherPlayer();
    }

    private void changeSkinButtonState(int buttonNumber)
    {
        if (_currentSkinType != -1)
        {
            if (_currentSkinType != buttonNumber)
            {
                _skinButtonsList[_currentSkinType].GetComponentInChildren<Image>().color = Color.white;
            }
        }
        _skinButtonsList[buttonNumber].GetComponentInChildren<Image>().color = SelectedColor;
        _currentSkinType = buttonNumber;
    }

    private void changeHairButtonState(int buttonNumber)
    {
        if (_currentHairType != -1)
        {
            if (_currentHairType != buttonNumber)
            {
                _hairButtonsList[_currentHairType].GetComponentInChildren<Image>().color = Color.white;
            }
        }
        _hairButtonsList[buttonNumber].GetComponentInChildren<Image>().color = SelectedColor;
        _currentHairType = buttonNumber;
    }

    private int getPlayer()
    {
        for (int i = 0; i < playerScript.Players.Length; i++)
        {
            if (playerScript.Players[i].HairTypes == _hairTypes)
            {
                if (playerScript.Players[i].SkinTypes == _skinTypes)
                {
                    return i;
                }

            }
        }
        return 0;
    }

    private string getPlayerName()
    {
        if (_inputField.text == "@ Typ hier je naam")
        {
            return "Unknown";
        }
        return _inputField.text;
    }

    private void spawnOtherPlayer()
    {
        Destroy(GameObject.FindWithTag("PlayerCharacter"));
        var parentObject = Instantiate(playerScript.Players[getPlayer()].Looks, transform.position, transform.rotation);
        parentObject.transform.parent = transform;
    }
}
