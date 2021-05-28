using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimation : MonoBehaviour
{
    private UnityAction walkListener;
    private UnityAction idleListener;
    private UnityAction jumpListener;
    private UnityAction sprintListener;

    [HideInInspector] private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        if(EventManager.Instance != null)
        {
            walkListener = new UnityAction(Walk);
            idleListener = new UnityAction(Idle);
            jumpListener = new UnityAction(Jump);
            sprintListener = new UnityAction(Sprint);
        }
    }
    private void OnEnable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.StartListening("walk", walkListener);
            EventManager.StartListening("idle", idleListener);
            EventManager.StartListening("jump", jumpListener);
            EventManager.StartListening("sprint", sprintListener);
        }
    }

    private void OnDisable()
    {
        EventManager.StopListening("walk", walkListener);
        EventManager.StopListening("idle", idleListener);
        EventManager.StopListening("jump", jumpListener);
        EventManager.StopListening("sprint", sprintListener);
    }

    void Walk()
    {
        if (_animator.GetBool("isWalking") == false)
        {
            Debug.Log("EventManager enabled walking.");
            _animator.SetBool("isWalking", true);
        }

        if (_animator.GetBool("isJumping") == true)
        {
            _animator.SetBool("isJumping", false);
        }
        else if (_animator.GetBool("isIdle") == true)
        {
            _animator.SetBool("isIdle", false);
        }
        else if(_animator.GetBool("isSprinting") == true)
        {
            _animator.SetBool("isSprinting", false);
        }
    }

    void Sprint()
    {
        if (_animator.GetBool("isSprinting") == false)
        {
            Debug.Log("EventManager enabled running.");
            _animator.SetBool("isSprinting", true);
        }

        if (_animator.GetBool("isWalking") == true)
        {
            _animator.SetBool("isWalking", false);
        }

    }

    void Idle()
    {
        if (_animator.GetBool("isIdle") == false)
        {
            Debug.Log("EventManager enabled idle.");
            _animator.SetBool("isIdle", true);
        }

        if (_animator.GetBool("isJumping") == true)
        {
            _animator.SetBool("isJumping", false);
        }
        else if (_animator.GetBool("isWalking") == true)
        {
            _animator.SetBool("isWalking", false);
        }
    }

    void Jump()
    {
        if (_animator.GetBool("isJumping") == false)
        {
            Debug.Log("EventManager enabled jumping.");
            _animator.SetBool("isJumping", true);
        }

        else if (_animator.GetBool("isIdle") == true)
        {
            _animator.SetBool("isIdle", false);
        }

        if (_animator.GetBool("isWalking") == true)
        {
            _animator.SetBool("isWalking", false);
        }
    }

}
