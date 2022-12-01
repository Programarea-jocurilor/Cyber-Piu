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
    private float cooldownTimer = Mathf.Infinity;

    [Header ("PlayerLayer")]
    [SerializeField] private LayerMask playerLayer;

    [Header ("Health")]
    [SerializeField] public int maxHealth;
    public int currentHealth;

    //References
    private Animator anim;
    private int playerHealth;
    private EnemyPatrol enemyPatrol;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    void Start()
    {
        currentHealth = maxHealth;         
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
        // if(hit.collider != null)
        //     playerHealth = PlayerPrefs.GetInt("currentHealth");

        return hit.collider != null;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * (-transform.localScale.x) * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    // private void DamagePlayer()
    // {
    //     if(PlayerInSight())
    //     {
    //         playerHealth = playerHealth - damage;
    //     }
    // }


    //functia lui corrado dar nu cred ca mai trebuie
    // public void DealDamage(int dmg) 
    // {
    //     currentHealth -= dmg;
    // }

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

    private void OnTriggerEnter2D(Collider2D external)
    {
        if(external.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("CurrentHealth", PlayerPrefs.GetInt("CurrentHealth")-damage); 
        }

        if(external.gameObject.CompareTag("Weapon"))
        {
            currentHealth -= 1;
            
            if(currentHealth<=0)
            {
                anim.SetTrigger("dead");
                GetComponentInParent<EnemyPatrol>().enabled = false;
                StartCoroutine(WaitAndDie());
            }
            else
            {
                anim.SetTrigger("hurt2");
                GetComponentInParent<EnemyPatrol>().enabled = false;
                StartCoroutine(WaitWhileHurt());
            }
            
        }
    }
}
