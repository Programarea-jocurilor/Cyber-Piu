using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenInteractionWithCollectibles : MonoBehaviour
{
    
   private float collectedDrowsyPotion;

   public float drowsyDuration;

   public static bool isInvincible;

   public float invincibilityTime;

   private float collectedInvincibilityPotion;

   public static bool canAttack;

   public float cantAttackTime;

   public Transform positionToSpawnChickenLeg;

   public GameObject chickenLeg;

   private float collectedCantAttackPotion;
    void Start()
    {
        collectedDrowsyPotion=0;
        isInvincible=false;
        collectedInvincibilityPotion=0;
        canAttack=true;
        collectedCantAttackPotion=0;
    }
   void Update()
   {
    if((Time.time>=collectedDrowsyPotion+drowsyDuration)&&collectedDrowsyPotion!=0)
    {
        if(PlayerController.isDrowsy)
            PlayerController.isDrowsy=false;
    }
    if((Time.time>=collectedInvincibilityPotion+invincibilityTime)&&collectedInvincibilityPotion!=0)
    {
        if(isInvincible)
            isInvincible=false;
    }
    if((Time.time>=collectedCantAttackPotion+cantAttackTime)&&collectedCantAttackPotion!=0)
    {
        if(!canAttack)
            canAttack=true;
    }
   }
   private void OnTriggerEnter2D(Collider2D collider)
   {
    if(collider.gameObject.tag=="DrowsyPotion")
    {
        PlayerController.isDrowsy=true;
        collectedDrowsyPotion=Time.time;
        Destroy(collider.gameObject);
    }
    if(collider.gameObject.tag=="InvincibilityPotion")
    {
        isInvincible=true;
        collectedInvincibilityPotion=Time.time;
        Destroy(collider.gameObject);
    }
     if(collider.gameObject.tag=="CantAttackPotion")
    {
        canAttack=false;
        collectedCantAttackPotion=Time.time;
        Destroy(collider.gameObject);
    }
     if(collider.gameObject.tag=="ChickenLeg")
     {
        GameObject chickenLegClone=Instantiate(chickenLeg);
        chickenLegClone.GetComponent<CapsuleCollider2D>().enabled=true;
        chickenLegClone.transform.position=positionToSpawnChickenLeg.position+new Vector3(0,7,0);
        chickenLegClone.AddComponent<Rigidbody2D>();
        chickenLegClone.GetComponent<Rigidbody2D>().collisionDetectionMode=CollisionDetectionMode2D.Continuous;
        chickenLegClone.GetComponent<Rigidbody2D>().interpolation=RigidbodyInterpolation2D.Interpolate;
        if(!chickenLegClone.activeInHierarchy)
            chickenLegClone.SetActive(true);
        Destroy(collider.gameObject);
     }
   }
}
