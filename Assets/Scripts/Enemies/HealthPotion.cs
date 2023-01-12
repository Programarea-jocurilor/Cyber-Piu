using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public float healValue;
    public Health playerHealthScript;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Player")
        {
            if(playerHealthScript.currentHealth<playerHealthScript.startingHealth)
                playerHealthScript.AddHealth(healValue);
            else
                playerHealthScript.TakeDamage(healValue);
            FindObjectOfType<SoundManager>().PlaySound("PiuCollectHearts");
            Destroy(this.gameObject);
        }
    }
}
