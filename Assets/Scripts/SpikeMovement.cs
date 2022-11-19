using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;

    private bool moveRight;

    private bool moveLeft;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        moveLeft=false;
        moveRight=true;
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
}
