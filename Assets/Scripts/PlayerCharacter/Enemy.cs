using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    public int currentHealth;
    [SerializeField] public int damage;

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(int dmg) 
    {
        currentHealth -= dmg;
        // if(currentHealth <= 0)
        // {
        //     Destroy(gameObject);
        // }
    }

    private void OnTriggerEnter2D(Collider2D external)
    {
        if(external.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("CurrentHealth", PlayerPrefs.GetInt("CurrentHealth")-damage);
        }

        if(external.gameObject.CompareTag("Weapon"))
        {
            currentHealth -= 1;
            if(currentHealth<=0)
            {
                this.transform.position = new Vector2(0, -1000);
            }
        }
    }


}
