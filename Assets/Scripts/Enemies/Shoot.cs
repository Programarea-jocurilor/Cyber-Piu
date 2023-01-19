using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject objectToShoot; //cu ce trag

    public Transform objectToShootTransform;

    public Transform playerTransform;

    public Transform firePoint;

    public float range;
    private float timer;

    private float distance;
    
    private Animator anim;
    private Health enemyHealth;
  
    void Awake()
    {
        if(this.gameObject.tag!="Boss") //pentru ca bossul nu are animatie momentan
            anim = GetComponent<Animator>();
        enemyHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
    
        distance=Vector2.Distance(transform.position,playerTransform.position);
        if(this.gameObject.tag!="Boss")
            {if(distance<20)// trage doar daca suntem la o distanta mai mica de 20
        {
            timer+=Time.deltaTime;
            if(timer>2 && enemyHealth.currentHealth > 0) //daca au trecut 2 secunde
            {
                timer=0; //resetam timerul
                
                EnemyShoot();//trage
            }
        }
        }
        else
        {
            timer+=Time.deltaTime;
            if(timer>2) //daca au trecut 2 secunde
            {
                timer=0; //resetam timerul
                EnemyShoot();//trage
                //FindObjectOfType<SoundManager>().PlaySound("EnemyShoot");
                // anim.SetTrigger("shoot");
            }
        }
    }

    public void EnemyShoot()
    {
        RaycastHit2D hit=Physics2D.Linecast(firePoint.position,playerTransform.position);
        if(hit.collider.tag=="Player")
        {   
            FindObjectOfType<SoundManager>().PlaySound("EnemyShoot2");
        if(this.gameObject.tag!="Boss")
            anim.SetTrigger("shoot");    
        GameObject objectToShootClone=Instantiate(objectToShoot,objectToShootTransform.position,Quaternion.identity); //cream efectiv cu ce trage enemy-ul
        objectToShootClone.SetActive(true);
        Destroy(objectToShootClone,5f);// il distrugem dupa 5 secunde ca sa nu ramana degeaba in hierarchy
        }
    }

    //IDEEA: asta o sa fie un enemy care trage doar daca gaina e la un certain distance de el, cum ar fi de exemplu vrea sa treaca gaina undeva si asta o sa fie ceva deasupra ei 
    //si cand se apropie gaina se apuca sa traga in ea

}
