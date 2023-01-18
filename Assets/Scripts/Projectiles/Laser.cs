using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float attackDamage = 1f;    

    // private float speed;
    // private float travelDistance;
    private float xStartPos;
    
    // [SerializeField]
    // private float damageRadius;

    // private Rigidbody2D rb;

    // [SerializeField]
    // private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsPlayer;
    
    // [SerializeField]
    // private Transform damagePosition;

    [SerializeField]
    private Vector2 knockbackAngle; 
    [SerializeField]
    private float knockbackStrength; 
    private int facingDirection;

    // private GameObject player;

    private void Start()
    {
        xStartPos = transform.position.x;
        // player = GameObject.FindGameObjectWithTag("Player");
        // Vector3 direction = player.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
//        TriggerAttack();
    }

    public void FireProjectile(float speed, float travelDistance, float damage)
    {
        // this.speed = speed;
        // this.travelDistance = travelDistance;
    }

    void OnTriggerEnter2D(Collider2D external)
    {
        if(external.gameObject.tag != "Enemy")
        {
            TriggerAttack(external);
        }

    }

    private void TriggerAttack(Collider2D collider)
    {
        // Collider2D[] detectedObjects = external;

        // foreach (Collider2D collider in detectedObjects)
        // {
        if(collider.transform.position.x > xStartPos)
        {
            facingDirection = 1;
        }
        else if(collider.transform.position.x < xStartPos)
        {
            facingDirection = -1;
        }

        IDamageable damageable = collider.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.Damage(attackDamage);
            // Debug.Log("damaged");
        }

        IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();
        if(knockbackable != null)
        {
            knockbackable.Knockback(knockbackAngle, knockbackStrength, facingDirection);
        }
        // }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
