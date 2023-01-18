using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    private float volume;

    [SerializeField]
    private AudioSource factoryAudio;
    
    [SerializeField]
    private AudioSource menuAudio;
    
    [SerializeField]
    private AudioSource headhunterAudio;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Instantiate Background Music");
        SoundManager.Instance.setAudioSources(factoryAudio, menuAudio, headhunterAudio);
        SoundManager.Instance.setVolume(volume);

        SoundManager.Instance.handleSceneChange();
    }

    // Update is called once per frame
    void Update()
    {
        SoundManager.Instance.handleSceneChange();
    }
}
