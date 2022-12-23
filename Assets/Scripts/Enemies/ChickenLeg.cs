using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenLeg : MonoBehaviour
{
    public int damageAmount;
    public EnemyHealth bossHealthScript;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Boss")
        {
            bossHealthScript.TakeDamage(damageAmount);
        }
        Destroy(this.gameObject);
    }
}
