using UnityEngine.Audio;
using UnityEngine;
using System;

/// <summary>
/// This class is used to manage audio effects in my game.
/// </summary>
public class AudioManager : MonoBehaviour
{

    /// <summary>
    /// This is where the source of the audio file and values such as volume etc are assigned
    /// </summary>
    [System.Serializable]
    public struct Sound
    {

        public string name;

        public AudioClip clip;
        [Range(0f, 1f)]
        public float volume;
        [Range(.1f, 3f)]
        public float pitch;

        [HideInInspector]
        public AudioSource source;

    }

    public Sound[] sounds;



    // This plays the sound when Play is called on the audio manager with the name of the sound
    void Awake()
    { 
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source = gameObject.AddComponent<AudioSource>();
            sounds[i].source.clip = sounds[i].clip;

            sounds[i].source.volume = sounds[i].volume;
            sounds[i].source.pitch = sounds[i].pitch;
        }

    }

    
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }


}
