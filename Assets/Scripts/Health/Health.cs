using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    [SerializeField] Color hurtColor;
    private Renderer renderer;
    //public GameObject finishCanvas;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
    }
    public void TakeDamage(float _damage)
    {
        if(!ChickenInteractionWithCollectibles.isInvincible)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
            if(this.gameObject.tag == "Player")
            {
                renderer.material.color = new Color(0.5f, 0.2f, 0.4f, 1f);
                StartCoroutine(HurtChanceColorBack());
            }
                
        }
            

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
                //Time.timeScale=0;
                //StartCoroutine(WaitAndLoadDeathCanvas());
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

    private IEnumerator WaitAndLoadDeathCanvas()
    {
        yield return new WaitForSeconds(2f);
        //finishCanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private IEnumerator HurtChanceColorBack()
    {
        yield return new WaitForSeconds(0.5f);
        renderer.material.color = new Color(1f, 1f, 1f, 1f);
    }
}