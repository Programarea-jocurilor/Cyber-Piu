using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Ground")]
    [SerializeField] Transform groundCheck;    
    [SerializeField] LayerMask ground;
    public Rigidbody2D rb;

    [Header ("Patrol points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header ("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header ("Enemy Animator")]
    private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
                
            else
            {
                DirectionChange();
            }
        }
        else
        {
           if(enemy.position.x <= rightEdge.position.x)
           {
                MoveInDirection(1);
           }
            else
            {
                DirectionChange();
            }
        }
        
    }

    private void MoveInDirection(int _direction)
    {
        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction * (-1), initScale.y, initScale.z);

        // if (IsGrounded() == true)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x + Time.deltaTime * _direction * speed, rb.velocity.y);
        // }
        
        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
        
    }

    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }

    bool IsGrounded() {
        Debug.Log(Physics2D.OverlapCircle(groundCheck.position, 0.01f, ground));
        return Physics2D.OverlapCircle(groundCheck.position, 0.01f, ground);
    }

    // bool isFacingWall() {
    //     return Physics2D.OverlapCircle(wallCheck.position, 0.01f, ground);
    // }

}
