using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToShoot : MonoBehaviour
{
    public GameObject player;

    public Health playerHealthScript;

    public float damageValue;

    public GameObject friedEgg;
    private Rigidbody2D rb;

    public float speed;

    void Awake()
    {
        //FindObjectOfType<SoundManager>().PlaySound("EnemyShoot");
    }
    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.tag!="BossEgg")
            speed=Random.Range(2,4);
        else
            speed=2.5f;
        rb=GetComponent<Rigidbody2D>();
        Vector3 direction=player.transform.position-transform.position; //directia in care o sa o ia objectToShoot
        rb.velocity=new Vector2(direction.x,direction.y) * speed;
        float objectToShootRotation=Mathf.Atan2(-direction.y,-direction.x)* Mathf.Rad2Deg; //util pentru cand o sa avem efectiv cu ceea ce trage, adica varful a ceea ce trage va fi indreptat spre player, apoi convertim in grade,ca sa putem folosi Quaternion.Euler
        transform.rotation=Quaternion.Euler(0,0,objectToShootRotation+90); //orientam efectiv varful a ceea ce trage spre player
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Player")
    {
        playerHealthScript.TakeDamage(damageValue);
    }
        if(collider.gameObject.tag!="Weapon")
         {
            if(this.gameObject.tag!="BossEgg")
                Destroy(this.gameObject);
            else
            {
                if(collider.gameObject.tag!="Player")
                {
                    GameObject friedEggClone=Instantiate(friedEgg,this.transform.position,Quaternion.identity);
                    friedEggClone.SetActive(true);
                    Destroy(friedEggClone,2f);
                }
                Destroy(this.gameObject);
            }
         }
    }
}
