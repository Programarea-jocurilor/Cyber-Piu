using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall1 : MonoBehaviour
{
    [Header ("Ground")]
    [SerializeField] Transform groundCheck;    
    [SerializeField] LayerMask ground;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    bool IsGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.01f, ground);
    }

    void Update()
    {
        if (IsGrounded())
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
            
    }
}
