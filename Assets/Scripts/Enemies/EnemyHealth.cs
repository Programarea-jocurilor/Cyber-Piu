using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;

    public int currentHealth;

    public Image fillImage;

    public Slider slider;

    public int playerDamageValue;

    public Transform targetToFollow;

    public Vector3 healthBarOffset;

    private float fillValue;
    void Start()
    {
        currentHealth=maxHealth;
        fillValue=(float)currentHealth/maxHealth;
        slider.value=fillValue;
    }
    // Update is called once per frame
    void Update()
    {
        if(slider.value<=slider.minValue)
        {
            fillImage.enabled=false;
        }
        if(slider.value>slider.minValue&&!(fillImage.enabled))
        {
            fillImage.enabled=true;
        }
        fillValue=(float)currentHealth/maxHealth;
        slider.value=fillValue;

        if(targetToFollow)
        {
            if(Camera.main.WorldToScreenPoint(targetToFollow.position).z>0) //daca e in view-ul camerei, ii schimb scale-ul, ca sa se vada, si-l pun deasupra zombieului.
            {   
                slider.transform.position=Camera.main.WorldToScreenPoint(targetToFollow.position+healthBarOffset);//targetToFollow e in World Space, dar healthBarul e in Screen Space si, deci, facem conversie la un punct din Screen Space
            }
        }
        if(currentHealth<=0)
        {
            if(targetToFollow!=null)
                {
                Destroy(targetToFollow.gameObject);
                Destroy(this.gameObject);
                }
        }
         if(Input.GetKeyDown(KeyCode.F))
        {
            currentHealth-=1;
            fillValue=(float)currentHealth/maxHealth;
            slider.value=fillValue;
        }
    }

    public void TakeDamage(int amount)
    {
        if(currentHealth>0)
            currentHealth-=amount;
        if(currentHealth<=0)
        {
            currentHealth=0;
            //die animation
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            currentHealth-=playerDamageValue;
        }
    }

    
}
