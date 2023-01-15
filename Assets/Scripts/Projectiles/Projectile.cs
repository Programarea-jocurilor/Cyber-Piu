using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // // private AttackDetails attackDetails;
    // protected Core core;
    [SerializeField]
    private float attackDamage = 1f;    

    private float speed;
    private float travelDistance;
    private float xStartPos;
    
    // [SerializeField]
    // private float gravity;
    [SerializeField]
    private float damageRadius;

    private Rigidbody2D rb;

    //private bool isGravityOn;
    //private bool hasHitGround;

    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsPlayer;
    
    [SerializeField]
    private Transform damagePosition;

    [SerializeField]
    private Vector2 knockbackAngle; 
    [SerializeField]
    private float knockbackStrength; 
    private int facingDirection;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.gravityScale = 0.0f;
        rb.velocity = transform.right * speed;

        xStartPos = transform.position.x;
        if(rb.velocity.x > 0)
        {
            facingDirection = 1;
        } else
        {
            facingDirection = -1;
        }
        //isGravityOn = false;
    }

    // private void Update()
    // {
    //     if(!hasHitGround)
    //     {
    //         attackDetails.position = transform.position;
            
    //         if(isGravityOn)
    //         {
    //             float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
    //             transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //         }
    //     }
    // }

    private void FixedUpdate()
    {
        Collider2D damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsPlayer);
        Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);

        if(damageHit)
        {
            //damageHit.transform.SendMessage("Damage", 1f);
            TriggerAttack();
            Destroy(gameObject);
        }
        if(groundHit)
        {
            // hasHitGround = true;
            // rb.gravityScale = 0f;
            // rb.velocity = Vector2.zero;
            Destroy(gameObject);
        }
        
        if(Mathf.Abs(xStartPos - transform.position.x) >= travelDistance/* && !isGravityOn*/)
        {
            //isGravityOn = true;
            //rb.gravityScale = gravity;
            Destroy(gameObject);
        }
    }

    public void FireProjectile(float speed, float travelDistance, float damage)
    {
        this.speed = speed;
        this.travelDistance = travelDistance;
        // attackDetails.damageAmount = damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
    }

    private void TriggerAttack()
    {
        // base.TriggerAttack();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(damagePosition.position, damageRadius+1, whatIsPlayer);

        foreach (Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.Damage(attackDamage);
            }

            IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();
            if(knockbackable != null)
            {
                knockbackable.Knockback(knockbackAngle, knockbackStrength, facingDirection);
            }
        }
    }
}
