using UnityEngine.Audio;
using UnityEngine;
using System;

/// <summary>
/// This class is used to manage audio effects in my game.
/// </summary>
public class AudioManager : MonoBehaviour
{


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



    // Start is called before the first frame update
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
