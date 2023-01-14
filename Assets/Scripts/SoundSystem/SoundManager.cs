using System;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    public static SoundManager instance;

    private void Awake()
    {
        //when we change the scene we want to not interupt the music
        if(instance == null)
            instance = this; //we create a soundManager in the new scene with the same values
        else
        {
            Destroy(gameObject); //we destroy the empty soundManager that we create when entering a scene that already contains one
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    
    void Start()
    {
        PlaySound("BackgroundMusic");
    }

    public void PlaySound(string _name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == _name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + _name + " not found!");
            return;
        }
        s.source.outputAudioMixerGroup = s.group;
        s.source.Play();
    }
}
