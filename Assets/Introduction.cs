using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    [SerializeField] private AudioClip _introductionVoice;

    public void Start()
    {
        Sound.PlaySound(_introductionVoice, this.gameObject);
    }
}
