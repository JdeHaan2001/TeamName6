using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PhoneActivation : MonoBehaviour
{
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
                animator.Play("phoneActivation");
            }
            else
            {
                // Play de-activate animation
            }
        }
    }
}
