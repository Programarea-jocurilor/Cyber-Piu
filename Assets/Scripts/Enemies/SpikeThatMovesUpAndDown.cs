using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeThatMovesUpAndDown : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed;

    private bool moveUp;

    private bool moveDown;

    private Animator spikeAnimator;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        moveDown=false;
        moveUp=true;
        spikeAnimator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveUp)
        {
            rb.velocity=Vector2.up*speed;
        }
        if(moveDown)
        {
            rb.velocity=Vector2.down*speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="MarginLeft")
        {
            moveDown=true;
            moveUp=false;
            spikeAnimator.SetBool("switchAnimation",false);
        }
         if(collider.gameObject.tag=="MarginRight")
        {
            moveDown=false;
            moveUp=true;
            spikeAnimator.SetBool("switchAnimation",true);
        }
    }
}