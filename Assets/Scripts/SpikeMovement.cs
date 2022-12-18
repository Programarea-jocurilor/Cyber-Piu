using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;

    private bool moveRight;

    private bool moveLeft;

     public GameObject objectToShoot; //cu ce trag

    public Transform objectToShootTransform;

    public Transform playerTransform;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        moveLeft=false;
        moveRight=true;
    }

    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>1) //daca au trecut 2 secunde
        {
            timer=0; //resetam timerul
            EnemyShoot();//trage
        }
        
    }

    void EnemyShoot()
    {
        GameObject objectToShootClone=Instantiate(objectToShoot,objectToShootTransform.position,Quaternion.identity); //cream efectiv cu ce trage enemy-ul
        objectToShootClone.SetActive(true);
        Destroy(objectToShootClone,5f);// il distrugem dupa 5 secunde ca sa nu ramana degeaba in hierarchy
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        if(transform.position.x<=10)
            {
                if(!moveRight)
                    moveRight=true;
                if(moveRight&&!moveLeft)
                {
                    rb.velocity=Vector2.right*speed;
                }
            }
        else 
            {
            moveLeft=true;
            if(moveRight)
                moveRight=false;
            if(moveLeft&&!moveRight)
                rb.velocity=Vector2.left*speed;
            }
        if(transform.position.x<=-10)
        {
           if(!moveRight)
                    moveRight=true;
                if(moveRight&&!moveLeft)
                {
                    rb.velocity=Vector2.right*speed;
                }
        }
        */
        if(moveRight)
        {
            rb.velocity=Vector2.right*speed;
        }
        if(moveLeft)
        {
            rb.velocity=Vector2.left*speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="MarginLeft")
        {
            moveLeft=false;
            moveRight=true;
        }
         if(collider.gameObject.tag=="MarginRight")
        {
            moveLeft=true;
            moveRight=false;
        }
    }

    //IDEEA: asta e un enemy care hovers around the player si trage in el rapid
}
