using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PhoneActivation : MonoBehaviour
{
    [SerializeField] private PhoneFSM _PFSM = null;

    private bool _isActive = false;
    private Animator animator = null;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!_isActive)
            {
                // Play activate animation
                animator.Play("OpenPhone");
                _isActive = true;
            }
            else
            {
                // Play de-activate animation
                animator.Play("ClosePhone");
                _isActive = false;
            }
        }
    }
}
