using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCanvas : MonoBehaviour
{

    void Awake()
    {
        Time.timeScale=0f;
    }

    public void Close()
    {
        FindObjectOfType<SoundManager>().PlaySound("ButtonPress");
        Time.timeScale=1f;
        this.gameObject.SetActive(false);
    }

}
