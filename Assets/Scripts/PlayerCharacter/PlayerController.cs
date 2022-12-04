using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Health")]
    public int maxHealth;
    public int currentHealth;
    
    [Header ("Core")]
    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpVelocity;
    [SerializeField] Transform groundCheck;    
    [SerializeField] LayerMask ground;
    private bool isFacingRight = true;
    private float movementDirection;

    [Header ("Wall Jump")]
    [SerializeField] Transform wallCheck;
    bool wallSliding;
    public float wallSlidingSpeed;
    bool wallJumping;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;
    private float initialDirection;
    private bool jumpAgain;

    [Header ("Dash")]
    public float dashSpeed;
    private int dashDirection;
    bool dashing;
    public float dashTime;

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

        if(Input.GetButtonDown("Jump") && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }     

        if(isFacingWall() && IsGrounded()==false && Input.GetAxis("Horizontal") != 0) { // 
            WallGrab();
        }else if(IsGrounded()==true || !isFacingWall()){ //
            wallSliding = false;
        }

        // if(wallSliding==true) {
        //     if(IsGrounded()){
        //         wallSliding=false;
        //     }
        // }

        if(Input.GetButtonDown("Jump") && wallSliding) {
            // rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            wallJumping = true;
            // initialDirection = -movementDirection;
            if(isFacingRight) {
                initialDirection = -1;
            }else {
                initialDirection = 1;
            }
            Flip();            
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if(wallJumping==true && isFacingWall()) {
            WallGrab();
        }

        if(wallJumping==true) {
            rb.velocity = new Vector2(xWallForce * initialDirection, yWallForce);

        } else if(isFacingRight && movementDirection < 0) {
            Flip();
        }else if(!isFacingRight && movementDirection > 0) {
            Flip();
        }

        if(wallJumping==true && isFacingWall() && Input.GetButtonDown("Jump")) {
            jumpAgain=true;
        }

        if(wallSliding) {
            rb.velocity = new Vector2(rb.velocity.x, -wallSlidingSpeed);
            // if(Input.GetButtonDown("Jump"))
            // {
            //     rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            // }
            //Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue)
        }
        
        if(Input.GetMouseButtonDown(0)) {
            attack.SetTrigger("onAttack");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashing = true;
            Invoke("SetDashingToFalse", dashTime);            
        }

        if(dashing == true) {
            rb.velocity = new Vector2(dashSpeed * movementDirection, rb.velocity.y);
            Physics2D.IgnoreLayerCollision(6, 7, true);
        }

    }

    bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.01f, ground);
    }

    bool isFacingWall() {
        return Physics2D.OverlapCircle(wallCheck.position, 0.01f, ground);
    }

    void Flip() {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180.0f, 0);
    }

    void SetWallJumpingToFalse() {

        if(isFacingWall() && jumpAgain==true) {
            if(isFacingRight) {
                initialDirection = -1;
            }else {
                initialDirection = 1;
            }
            Flip();            
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }
        else
            wallJumping = false;
        // if(isFacingWall() && IsGrounded()==false) { // 
        //     wallSliding = true;
        // }
    }

    void SetDashingToFalse() {
        dashing = false;
        Physics2D.IgnoreLayerCollision(6, 7, false);        
    }

    void WallGrab(){
        wallSliding = true;

    }
}
