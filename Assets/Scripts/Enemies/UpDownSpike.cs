using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownSpike : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float seconds;
    private Health playerHealth;
    [Header ("Collider Parameters")]
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(WaitAnimation());
    }

    private bool PlayerInSight()
    {
        
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.up * range * (transform.localScale.y) * colliderDistance, 
                new Vector3(boxCollider.bounds.size.x, boxCollider.bounds.size.y * range, boxCollider.bounds.size.z),
                0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.up * range * (transform.localScale.y) * colliderDistance,
        new Vector3(boxCollider.bounds.size.x , boxCollider.bounds.size.y * range, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
            playerHealth.TakeDamage(damage);
    }

    IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(seconds);
        anim.SetTrigger("move");
    }    

}
