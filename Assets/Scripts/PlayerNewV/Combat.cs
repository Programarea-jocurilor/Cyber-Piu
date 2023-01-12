using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent
{
    private bool isKnockbackActive;
    private float knockbackStartTime;

    private Movement Movement { get => movement ; }
    private CollisionSenses CollisionSenses { get => collisionSenses ; }
    private Movement movement;
    private CollisionSenses collisionSenses;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Knockback(Vector2 angle, float strength, int direction)
    {
        Movement.SetVelocity(strength, angle, direction);
        Movement.CanSetVelocity = false;
        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        //if(isKnockbackActive && ((Movement.CurrentVelocity.y <= 0.01f && (CollisionSenses.Ground) || Time.time >= knockbackStartTime + maxKnockbackTime))
        if(isKnockbackActive && Movement.CurrentVelocity.y <= 0.01f && CollisionSenses.Ground)
        {
            isKnockbackActive = false;
            Movement.CanSetVelocity = true;
        }
    }
}
