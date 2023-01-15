using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GameObject finishCanvas;
    public bool finish = false;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Player")
        {
            finish=true;
            Time.timeScale=0;
            FindObjectOfType<SoundManager>().PlaySound("Finishline");
            finishCanvas.SetActive(true);
        }
    }
}
