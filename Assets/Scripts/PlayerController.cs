using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] public float moveSpeed;
    [SerializeField] private float jumpVelocity;

    [SerializeField] public int maxHealth;
    [SerializeField] public int currentHealth;

    [SerializeField] Transform groundCheck;    
    [SerializeField] LayerMask ground;
    private bool isFacingRight = true;
    private float movementDirection;

    [SerializeField] Transform frontCheck;
    bool wallSliding;
    [SerializeField] public float wallSlidingSpeed;    

    public Animator attack;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHealth = PlayerPrefs.GetInt("CurrentHealth");
    }

    void Update()
    {
        currentHealth = PlayerPrefs.GetInt("CurrentHealth");

        movementDirection = Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }

        if(isFacingRight && movementDirection < 0)
        {
            Flip();
        }else if(!isFacingRight && movementDirection > 0)
        {
            Flip();
        }

        if(Input.GetMouseButtonDown(0))
        {
            attack.SetTrigger("onAttack");
        }

        // if (Input.GetKeyDown(KeyCode.LeftShift))
        // {
        //     float dashDistance = 20f;
        //     rb.AddForce(new Vector2(dashDistance*movementDirection, 0));
        // }

    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180.0f, 0);
    }
}
