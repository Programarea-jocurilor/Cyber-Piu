using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWeapon : Weapon
{
    protected SO_MainWeaponData mainWeaponData; 

    private List<IDamageable> detectedDamageables = new List<IDamageable>();
    // private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();

    protected override void Awake()
    {
        base.Awake();

        if(weaponData.GetType() == typeof(SO_MainWeaponData)) 
        {
            mainWeaponData = (SO_MainWeaponData)weaponData; 
        }
        else
        {
            Debug.LogError("Wrong data for the weapon");
        }
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = mainWeaponData.AttackDetails[attackCounter]; //!!!
        // Debug.Log(details.damageAmount);
        foreach (IDamageable item in detectedDamageables)
        {
            item.Damage(details.damageAmount);

        }

        // foreach (IKnockbackable item in detectedKnockbackables.ToList())
        // {
        //     item.Knockback(details.knockbackAngle, details.knockbackStrength, core.Movement.FacingDirection);
        // }
    }

    public void AddToDetected(Collider2D collision)
    {

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if(damageable != null)
        {
            detectedDamageables.Add(damageable);
        }

        // IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        // if(knockbackable != null)
        // {
        //     detectedKnockbackables.Add(knockbackable);
        // }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
               
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageables.Remove(damageable);
        }

        // IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        // if (knockbackable != null)
        // {
        //     detectedKnockbackables.Remove(knockbackable);
        // }
    }
   
}
