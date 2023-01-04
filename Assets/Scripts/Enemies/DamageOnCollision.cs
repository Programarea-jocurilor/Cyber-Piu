using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    [SerializeField] private float damage;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Checks collision for damaging player
        if (collider.tag == "Player")
        {
            collider.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
