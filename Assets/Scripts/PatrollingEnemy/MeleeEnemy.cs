using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private int playerHealth;
    private EnemyPatrol enemyPatrol;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    // Update is called once per frame
    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        
        //Attack only when the player is in sight
        if (PlayerInSight())
        {
            //Attack after attackCooldown seconds
            if(cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("fighting");
            }
        } 

        // if (enemyPatrol != null)  
        // enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * (-transform.localScale.x) * colliderDistance, 
                new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
                0, Vector2.left, 0, playerLayer);
        if(hit.collider != null)
            playerHealth = PlayerPrefs.GetInt("currentHealth");

        return hit.collider != null;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * (-transform.localScale.x) * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if(PlayerInSight())
        {
            playerHealth = playerHealth - damage;
        }
    }
}
