using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private GameObject _player;

    public void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    public void ChangeDialogueMessage()
    {
        Debug.Log(_dialogueManager.InstantiatedPrefab.Count);
    }
}
