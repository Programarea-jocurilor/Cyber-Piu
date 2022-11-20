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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when the player is in sight
        if (PlayerInSight())
        {
            if(cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("fighting");
            }
        }    
    }

    private bool PlayerInSight()
    {
        
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * (-transform.localScale.x) * colliderDistance, 
                new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
                0, Vector2.left, 0, playerLayer);

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
        //damage player
    }
}
