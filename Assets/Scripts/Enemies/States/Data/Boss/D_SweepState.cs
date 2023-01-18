using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newSweepStateData", menuName = "Data/State Data/Sweep State")]
public class D_SweepState : ScriptableObject
{
    public GameObject[] teleportLocations;

    public GameObject projectile;
    public float projectileDamage = 1f;
    public float projectileSpeed = 30f;
    public float projectileTravelDistance = 50f;
}
