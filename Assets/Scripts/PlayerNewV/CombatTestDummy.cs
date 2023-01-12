using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatTestDummy : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject hitParticles;

    private Animator anim;

    private Health enemyHealth;

    public void Damage(float amount)
    {
        Debug.Log(amount + " Damage taken");

        Instantiate(hitParticles, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));

        if( enemyHealth.currentHealth > 1)
        {
            anim.SetTrigger("damage");
            enemyHealth.TakeDamage(1);
            FindObjectOfType<SoundManager>().PlaySound("EnemyHurt");
            if(this.name == "MeleeEnemy")
            {
                GetComponentInParent<EnemyPatrol>().enabled = false;
                StartCoroutine(WaitWhileHurt());
            }
        }

        else if(enemyHealth.currentHealth == 1)
        {
            anim.SetTrigger("dead");
            enemyHealth.TakeDamage(1);
            FindObjectOfType<SoundManager>().PlaySound("EnemyDead");
            if(this.name == "MeleeEnemy")
            {
                GetComponentInParent<EnemyPatrol>().enabled = false;
            }
            StartCoroutine(WaitAndDie());
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<Health>();
    }

    IEnumerator WaitWhileHurt()
    {
        yield return new WaitForSeconds(1);
        GetComponentInParent<EnemyPatrol>().enabled = true;
    }

    IEnumerator WaitAndDie()
    {
        yield return new WaitForSeconds(1f);
        this.transform.position = new Vector2(0, -1000);
    }
}