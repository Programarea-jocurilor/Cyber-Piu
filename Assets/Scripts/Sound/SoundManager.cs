using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SoundManager
{
    private static List<String> menuScenes = new List<String>( new [] {
        "Menu",
        "LoadSave",
        "Highscores"
    });

    private static List<String> headhunterScenes = new List<String>( new [] {
        "BossArena"
    });

    private static SoundManager _instance = null;

    public static SoundManager Instance { get { 
        if (_instance == null)
            _instance = new SoundManager();
        
        return _instance;
    } }

    private String currentSoundName = "menu";

    private bool running = false;

    private float volume = 1f;

    private AudioSource factoryAudio;
    
    private AudioSource menuAudio;
    
    private AudioSource headhunterAudio;

    public void setAudioSources(AudioSource f, AudioSource m, AudioSource h)
    {
        if (factoryAudio == null) {
            factoryAudio = f;
            menuAudio = m;
            headhunterAudio = h;
        }
    }

    public void setVolume(float vol)
    {
        volume = vol;
    }

    public String currentSound()
    {
        return currentSoundName;
    } 

    public void setCurrentSound(String newSoundName)
    {
        currentSoundName = newSoundName;
    }

    private void stopSong()
    {
        AudioSource audio = getChosenSource();

        Debug.Log("Stopping: " + audio.name);
        
        audio.Stop();
    }

    private AudioSource getChosenSource()
    {
        switch(currentSoundName) 
        {
            case "factory":
                return factoryAudio;
            case "menu":
                return menuAudio;
            case "headhunter":
                return headhunterAudio;
            default:
                // code block
                break;
        }
        return null;
    }

    private void startSong()
    {
        Debug.Log("Starting song ----");

        AudioSource audio = getChosenSource();

        audio.volume = volume;
        audio.Play();

        Debug.Log("Starting: " + audio.name);
    }

    public void handleSceneChange()
    {
        if (!running) {
            running = true;
            startSong();
            return ;
        }

        String oldSoundName = currentSoundName;
        String newSoundName = null;

        String activeScene = SceneManager.GetActiveScene().name; 
        
        if (menuScenes.Exists(s => s.Equals(activeScene)))
            newSoundName = "menu";
    
        else if (headhunterScenes.Contains(activeScene))
            newSoundName = "headhunter";
        
        else 
            newSoundName = "factory";

        if (oldSoundName != newSoundName)
            updatePlayingSound(newSoundName);
    }

    private void updatePlayingSound(String newSoundName)
    {
        if (newSoundName.Equals(currentSoundName))
            return;

        Debug.Log("Actual UPDATE");
        
        stopSong();

        currentSoundName = newSoundName;
        startSong();
    }
}
