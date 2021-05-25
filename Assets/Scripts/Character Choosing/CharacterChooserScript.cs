using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterChooserScript : MonoBehaviour
{
    private static CharacterChooserScript _instance;
    public static CharacterChooserScript instance => _instance;

    public Player playerScript;
    [SerializeField] private UIButtonFunctions _uiButtonFunctions;

    [HideInInspector] private bool _chooseNextPlayer;
    [HideInInspector] private bool _playerCanSpawn;

    [HideInInspector]
    public int playerToShow;

    private void Awake()
    {

        playerToShow = PlayerPrefs.GetInt("playerToPlay");
    }

    void Start()
    {
        var parentObject = Instantiate(playerScript.Players[playerToShow].Looks, transform.position, transform.rotation);
        parentObject.transform.parent = transform;
    }

    void Update()
    {
        whenChoosingPlayer();
        scrollTroughPlayers();
    }

    private void whenChoosingPlayer()
    {
        if (_uiButtonFunctions.playerChosen == true)
        {
            PlayerPrefs.SetInt("playerToPlay", playerToShow);
            _playerCanSpawn = true;
            _uiButtonFunctions.playerChosen = false;
        }
    }

    private void scrollTroughPlayers()
    {
        if (_chooseNextPlayer == true && _playerCanSpawn == false)
        {
            Destroy(GameObject.FindWithTag("PlayerCharacter"));
            var parentObject = Instantiate(playerScript.Players[playerToShow].Looks, transform.position, transform.rotation);
            parentObject.transform.parent = transform;
            _chooseNextPlayer = false;
        }

        if (Input.GetKeyUp(KeyCode.A) && playerToShow != -1)
        {
            playerToShow--;
            _chooseNextPlayer = true;

            if (playerToShow == -1)
            {
                playerToShow = playerScript.Players.Length - 1;
            }

        }

        if (Input.GetKeyUp(KeyCode.D) && playerToShow != playerScript.Players.Length)
        {
            playerToShow++;
            _chooseNextPlayer = true;

            if (playerToShow == playerScript.Players.Length)
            {
                playerToShow = 0;
            }
        }
    }
}
