using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
   
    public TextMeshProUGUI score;
   
    private static float scoreValue;
    void Start()
    {
        scoreValue=0;
        score.text="Score:"+scoreValue.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Player")
        {
            scoreValue = scoreValue + 100;
            score.text="Score:"+scoreValue.ToString();
            Destroy(this.gameObject);
        }
    }
}
