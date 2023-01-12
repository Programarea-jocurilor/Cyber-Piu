using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header ("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("PlayerLayer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    // [Header ("Health")]
    // [SerializeField] public int maxHealth;
    // public int currentHealth;

    //References
    private Animator anim;
    private Health playerHealth;
    private EnemyPatrol enemyPatrol;

    bool inSight = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    void Start()
    {
        // currentHealth = maxHealth;         
    }

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
                GetComponentInParent<EnemyPatrol>().enabled = false;
                StartCoroutine(WaitAndFight());
            }
        } 
    }

    private bool PlayerInSight()
    {
        inSight = false;
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * (-transform.localScale.x) * colliderDistance, 
                new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
                0, Vector2.left, 0, playerLayer);


        if(hit.collider != null)
        if (hit.collider.gameObject.tag == "Player")
        {
            playerHealth = hit.transform.GetComponent<Health>();
            inSight = true;
        }
        
        // return hit.collider != null;
        return inSight;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * (-transform.localScale.x) * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    IEnumerator WaitAndFight()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponentInParent<EnemyPatrol>().enabled = true;
    }

    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(1);
        this.transform.position = new Vector2(0, -1000);
    }

    IEnumerator WaitWhileHurt()
    {
        yield return new WaitForSeconds(1);
        GetComponentInParent<EnemyPatrol>().enabled = true;
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
            playerHealth.TakeDamage(damage);
            FindObjectOfType<SoundManager>().PlaySound("PatrollingEnemyAttack");
    }

}
