using System;
using UnityEngine.Audio;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{
    public Sound[] sounds;


    private void Awake()
    {

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
