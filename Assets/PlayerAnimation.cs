using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimation : MonoBehaviour
{
    private UnityAction walkListener;
    private UnityAction idleListener;
    private UnityAction jumpListener;

    [HideInInspector] private Player _playerScript;
    [HideInInspector] private Animator _animator;

    private void Awake()
    {
        _playerScript = GameObject.FindGameObjectWithTag("PlayerCustomization").GetComponent<Player>();
        _animator = _playerScript.Players[PlayerPrefs.GetInt("playerToPlay")].Looks.GetComponent<Animator>();

        walkListener = new UnityAction(Walk);
        idleListener = new UnityAction(Idle);
        jumpListener = new UnityAction(Jump);
    }
    private void OnEnable()
    {
        EventManager.StartListening("walk", walkListener);
        EventManager.StartListening("idle", idleListener);
        EventManager.StartListening("jump", jumpListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening("walk", walkListener);
        EventManager.StopListening("idle", idleListener);
        EventManager.StopListening("jump", jumpListener);
    }

    void Walk()
    {
        _animator.SetBool("isWalking", true);
        Debug.Log("EventManager enabled walking.");
    }

    void Idle()
    {
        _animator.SetBool("isIdle", true);
        Debug.Log("EventManager enabled idle.");
    }

    void Jump()
    {
        _animator.SetBool("isJumping", true);
        Debug.Log("EventManager enabled jumping.");
    }
}
