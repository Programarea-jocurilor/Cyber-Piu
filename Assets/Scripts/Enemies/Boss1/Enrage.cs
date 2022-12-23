using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enrage : MonoBehaviour
{
    public EnemyHealth enemyHealthScript;

    public GameObject firePlace1;

    public GameObject firePlace2;

    public ObjectToShoot objectToShootScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealthScript.currentHealth<=enemyHealthScript.maxHealth/2f)
        {
            if(enemyHealthScript.currentHealth>=enemyHealthScript.maxHealth/4f)
            {
                firePlace1.SetActive(true);
                firePlace2.SetActive(true);
            }
            else
            {
                objectToShootScript.speed=3f;
            }
        }
    }
}
