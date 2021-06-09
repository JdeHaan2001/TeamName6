using UnityEngine;

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
                animator.Play("OpenPhone");
                _isActive = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                // Play de-activate animation
                animator.Play("ClosePhone");
                _isActive = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
