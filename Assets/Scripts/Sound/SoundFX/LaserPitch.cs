using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPitch : MonoBehaviour
{
    [SerializeField]
    private AudioSource laserAudio;

    private void updatePitch()
    {
        laserAudio.pitch = Time.timeScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        updatePitch();
    }

    // Update is called once per frame
    void Update()
    {
        updatePitch();
    }
}
