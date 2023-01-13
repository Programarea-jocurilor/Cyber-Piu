using System.IO;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    public GameObject finishCanvas;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        if(!ChickenInteractionWithCollectibles.isInvincible)
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        // if (currentHealth > 0)
        // {
        //     anim.SetTrigger("hurt");
        //     //iframes
        // }
        // else
        // {
        //     if (!dead)
        //     {
        //         anim.SetTrigger("die");
        //         GetComponent<PlayerMovement>().enabled = false;
        //         dead = true;
        //     }
        // }
        if(this.gameObject.tag == "Player")
            if (currentHealth == 0)
            {
                dead = true;
                Time.timeScale=0;
                this.gameObject.SetActive(false);
                finishCanvas.SetActive(true);
            }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E))
        //     TakeDamage(1);
    }
}