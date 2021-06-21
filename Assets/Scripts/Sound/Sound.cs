//Made by Jeroen de Haan
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string Name = "";

    public AudioClip Clip = null;

    //public bool PlayOnAwake = true;
    public bool Loop = false;

    [Range(0f, 1f)] public float Volume = 1f;
    [Range(-3f, 3f)] public float Pitch = 1f;
    [Range(0f, 1f)] public float SpatialBlend = 0f;

    [HideInInspector] public AudioSource Source = null;
    
}
