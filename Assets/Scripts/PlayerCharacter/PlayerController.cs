// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController : MonoBehaviour
// {
//     [Header ("Health")]
//     public int maxHealth;
//     public int currentHealth;
    
//     [Header ("Core")]
//     public Rigidbody2D rb;
//     public float moveSpeed;
//     public float jumpVelocity;
//     [SerializeField] Transform groundCheck;    
//     [SerializeField] LayerMask ground;
//     private bool isFacingRight = true;
//     private float movementDirection;

//     [Header ("Wall Jump")]
//     [SerializeField] Transform wallCheck;
//     bool wallSliding;
//     public float wallSlidingSpeed;
//     bool wallJumping;
//     public float xWallForce;
//     public float yWallForce; 
//     public float wallJumpTime;
//     private float initialDirection;
//     private bool jumpAgain;
//     // private bool recentlyTouchedAWall;

//     [Header ("Dash")]
//     public float dashSpeed;
//     private int dashDirection;
//     bool dashing;
//     public float dashTime;

//     [Header ("Slide")]
//     public int slopeLimit;
//     private bool isSliding;
//     private Vector2 slopeSlideVelocity;

//     public Animator attack;


//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         maxHealth = PlayerPrefs.GetInt("CurrentHealth");
//     }

//     void Update()
//     {
//         currentHealth = PlayerPrefs.GetInt("CurrentHealth");

//         movementDirection = Input.GetAxisRaw("Horizontal");
        
//         rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);

//         if(Input.GetButtonDown("Jump") && IsGrounded()) {
//             rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
//         }     

//         if(isFacingWall() && IsGrounded()==false && Input.GetAxis("Horizontal") != 0) { // 
//             WallGrab();
//         }else if(IsGrounded()==true || !isFacingWall()){ //
//             wallSliding = false;
//         }

//         // if(wallSliding==true) {
//         //     if(IsGrounded()){
//         //         wallSliding=false;
//         //     }
//         // }

//         if(Input.GetButtonDown("Jump") && wallSliding) {
//             // rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
//             wallJumping = true;
//             // initialDirection = -movementDirection;
//             if(isFacingRight) {
//                 initialDirection = -1;
//             }else {
//                 initialDirection = 1;
//             }
//             Flip();            
//             Invoke("SetWallJumpingToFalse", wallJumpTime);
//             // Invoke("SetRecentlyTouchedAWallToFalse", wallJumpTime);
//         }

//         if(wallJumping==true && isFacingWall()) {
//             WallGrab();
//             if(Input.GetButtonDown("Jump")) {
//                 jumpAgain=true;
//             }
//         }

//         if(wallJumping==true) {
//             rb.velocity = new Vector2(xWallForce * initialDirection, yWallForce);
//             // recentlyTouchedAWall = true;
//         } else if(isFacingRight && movementDirection < 0) {
//             Flip();
//         }else if(!isFacingRight && movementDirection > 0) {
//             Flip();
//         }

//         // if(wallJumping==true && isFacingWall() && Input.GetButtonDown("Jump")) {
//         //     jumpAgain=true;
//         // }

//         if(wallSliding) {
//             rb.velocity = new Vector2(rb.velocity.x, -wallSlidingSpeed);
//             // if(Input.GetButtonDown("Jump"))
//             // {
//             //     rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
//             // }
//             //Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue)
//         }
        
//         if(Input.GetMouseButtonDown(0)) {
//             attack.SetTrigger("onAttack");
//         }

//         if (Input.GetKeyDown(KeyCode.LeftShift))
//         {
//             dashing = true;
//             Invoke("SetDashingToFalse", dashTime);            
//         }

//         if(dashing == true) {
//             rb.velocity = new Vector2(dashSpeed * movementDirection, rb.velocity.y);
//             Physics2D.IgnoreLayerCollision(6, 7, true);
//         }

//         // SetSlopeSlideVelocity();

//         // if(slopeSlideVelocity == Vector2.zero) {
//         //     isSliding = false;
//         // }

//         // if(IsGrounded() && slopeSlideVelocity != Vector2.zero) {
//         //     isSliding = true;
//         // }

//         // if(isSliding) {
//         //     Vector2 velocity = slopeSlideVelocity;
//         //     velocity.y = ySpeed;

//         //     characterController.Move(velocity);
//         // }

//     }

//     bool IsGrounded() {
//         return Physics2D.OverlapCircle(groundCheck.position, 0.01f, ground);
//     }

//     bool isFacingWall() {
//         return Physics2D.OverlapCircle(wallCheck.position, 0.01f, ground);
//     }

//     void Flip() {
//         isFacingRight = !isFacingRight;
//         transform.Rotate(0, 180.0f, 0);
//     }

//     void SetWallJumpingToFalse() {

//         if(jumpAgain==true) {
//             if(isFacingRight) {
//                 initialDirection = -1;
//             }else {
//                 initialDirection = 1;
//             }
//             Flip();  
//             jumpAgain=false;          
//         }
//         else //if(recentlyTouchedAWall==false)
//             wallJumping = false;
//         // if(isFacingWall() && IsGrounded()==false) { // 
//         //     wallSliding = true;
//         // }
//     }

//     // void SetRecentlyTouchedAWallToFalse() {
//     //     recentlyTouchedAWall = false;
//     // }

//     void SetDashingToFalse() {
//         dashing = false;
//         Physics2D.IgnoreLayerCollision(6, 7, false);        
//     }

//     void WallGrab() {
//         wallSliding = true;
//     }

//     // private void SetSlopeSlideVelocity() {
//     //     if(Physics2D.Raycast(transform.position + Vector2.up, Vector2.down, out RaycastHit hitInfo, 5)) {
//     //         float angle = Vector2.Angle(hitInfo.normal, Vector2.up);
//     //         if(angle >= characterController.slopeLimit) {
//     //             slopeSlideVelocity = Vector2.ProjectOnPlane(new Vector2(0, ySpeed), hitInfo.normal);
//     //             return;
//     //         }
//     //     }
//     //     slopeSlideVelocity = Vector2.zero;
//     // }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementInputDirection;
    private bool isFacingRight = true;
    private bool isWalking;
    private bool isGrounded;
    private bool canJump;
    
    private Rigidbody2D rb;
    private Animator anim;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    public float movementSpeed;
    public float jumpForce;
    public float groundCheckRadius;

    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }

    private void CheckMovementDirection() 
    {
        if(isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }
        else if(!isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }

        if(rb.velocity.x != 0) 
        {
            isWalking = true;
        }
        else 
        {
            isWalking = false;
        } 
    }

    private void CheckSurroundings() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void CheckIfCanJump()
    {
        if(isGrounded && rb.velocity.y <= 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if(canJump) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void ApplyMovement()
    {
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
    }

    private void Flip() {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
//test