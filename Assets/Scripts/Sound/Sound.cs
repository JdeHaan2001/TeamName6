//Made by Jeroen de Haan
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public enum MusicType {
        Music = 1, SFX, VoiceOver
    }

    public string Name = "";

    public AudioClip Clip = null;

    //public bool PlayOnAwake = true;
    public bool Loop = false;

    [Range(0f, 1f)] public float Volume = 1f;
    [Range(-3f, 3f)] public float Pitch = 1f;
    [Range(0f, 1f)] public float SpatialBlend = 0f;
    public AudioMixerGroup MixerGroup = null;
    //public static MusicType musicType = MusicType.Music;

    [HideInInspector] public AudioSource Source = null;

    /// <summary>
    /// Static function to play a sound through script. This funciton will add an audio source to the gameobject that is given.
    /// </summary>
    public static void PlaySound(AudioClip pAudioClip, GameObject pGameObject)
    {
        AudioSource source;
        if (pGameObject.GetComponent<AudioSource>() == null)
            source = pGameObject.AddComponent<AudioSource>();
        else
            source = pGameObject.GetComponent<AudioSource>();

        if (pAudioClip != null && pGameObject != null)
        {
            source.clip = pAudioClip;

            if (!source.isPlaying)
                source.Play();
        }
    }
    
}
