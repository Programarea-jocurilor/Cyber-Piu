using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHitboxToWeapon : MonoBehaviour
{
    private MainWeapon weapon;

    private void Awake()
    {
        weapon = GetComponentInParent<MainWeapon>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        weapon.AddToDetected(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {               
        weapon.RemoveFromDetected(collision);
    }
}