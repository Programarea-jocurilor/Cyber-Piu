using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThatShootsAtCertainFireRangeShoot : MonoBehaviour
{
    public GameObject objectToShoot; //cu ce trag

    public Transform firePoint;

    public Transform playerTransform;

    public float range;
    private float timer;
    private Health enemyHealth;

    private void Awake()
    {
        enemyHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>2 && enemyHealth.currentHealth > 0) //daca au trecut 2 secunde
        {
            timer=0; //resetam timerul
            EnemyShoot();//trage
        }
        
    }

    void EnemyShoot()
    {
        RaycastHit2D hit=Physics2D.Linecast(firePoint.position,playerTransform.position);
            if(hit.collider.tag=="Player")
            { 
                FindObjectOfType<SoundManager>().PlaySound("EnemyShoot");
                GameObject objectToShootClone=Instantiate(objectToShoot,firePoint.position,Quaternion.identity); //cream efectiv cu ce trage enemy-ul
                objectToShootClone.SetActive(true);
                Destroy(objectToShootClone,5f);// il distrugem dupa 5 secunde ca sa nu ramana degeaba in hierarchy
            }
    }

    //IDEEA: asta o sa fie un enemy care o sa traga la random fire rate-uri, si o sa fie util cand de pilda gaina vrea sa se urce undeva si ala trage acolo incontinuu ca sa o impidice
    //sa se urce
}
