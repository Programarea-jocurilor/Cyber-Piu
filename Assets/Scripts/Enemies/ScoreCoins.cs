using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ScoreCoins : MonoBehaviour
{
   
    public TextMeshProUGUI score;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI enemies;
    public Health enemyHealth;
   
    private static float scoreValue;
    private static float coinsValue;
    private static float enemiesValue;
    private bool add=true;

    void Start()
    {
        scoreValue=0;
        score.text="Score:"+scoreValue.ToString();

        coinsValue=0;
        coins.text="x"+coinsValue.ToString();  

        enemiesValue=0;
        enemies.text="x"+enemiesValue.ToString();    

        if(this.gameObject.tag == "Enemy")
            enemyHealth = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Player" && this.gameObject.tag=="Coin")
        {
            FindObjectOfType<SoundManager>().PlaySound("PiuCollectCoins");
            scoreValue = scoreValue + 100;
            score.text="Score:"+scoreValue.ToString();
            Destroy(this.gameObject);

            coinsValue = coinsValue +1;
            coins.text="x"+coinsValue.ToString();
        }
    }

    void Update()
    {
        if(this.gameObject.tag == "Enemy")
            if(enemyHealth.currentHealth==0 && add)
            {
                scoreValue = scoreValue + 100;
                score.text="Score:"+scoreValue.ToString();
                enemiesValue = enemiesValue +1;
                enemies.text="x"+enemiesValue.ToString();
                add=false;
            }
    }


}
