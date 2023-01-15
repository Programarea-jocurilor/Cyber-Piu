using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DashDamage : MonoBehaviour
{
    private List<IDamageable> detectedDamageables = new List<IDamageable>();
    private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();

    void FixedUpdate()
    {
        TriggerAttack(); 
    }

    private void TriggerAttack()
    {
        // base.TriggerAttack();

        foreach (IDamageable item in detectedDamageables.ToList())
        {
            item.Damage(1f);
            detectedDamageables.Remove(item);
        }

        // foreach (IKnockbackable item in detectedKnockbackables.ToList())
        // {
        //     item.Knockback(details.knockbackAngle, details.knockbackStrength, Movement.FacingDirection);
        //     detectedKnockbackables.Remove(knockbackable);
        // }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if(damageable != null)
        {
            detectedDamageables.Add(damageable);
            Debug.Log("added");
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if(knockbackable != null)
        {
            detectedKnockbackables.Add(knockbackable);
        }
    }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     IDamageable damageable = collision.GetComponent<IDamageable>();

    //     if (damageable != null)
    //     {
    //         detectedDamageables.Remove(damageable);
    //     }

    //     IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

    //     if (knockbackable != null)
    //     {
    //         detectedKnockbackables.Remove(knockbackable);
    //     }
    // }
}
