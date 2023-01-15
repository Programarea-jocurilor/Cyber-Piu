using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Mouse Click Detected");
        FindObjectOfType<SoundManager>().PlaySound("Dead");
    }
}
