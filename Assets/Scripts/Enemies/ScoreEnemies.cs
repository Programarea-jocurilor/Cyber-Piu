using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class ScoreEnemies : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI enemies;
    public Health enemyHealth;

    private static float scoreValue;
    private static float enemiesValue;
    private bool add=true;

    void Start()
    {
        scoreValue=0;
        score.text="Score:"+scoreValue.ToString();

        enemiesValue=0;
        enemies.text="x"+enemiesValue.ToString();

        enemyHealth = GetComponent<Health>();
    }

    void Update()
    {
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
