using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HH_SweepState : SweepState
{   
    private Headhunter enemy;
    private Transform teleport;
    private Rigidbody2D rb;
    private float gravityScaleSet;
    private Transform currentTransform;
    public HH_SweepState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_SweepState stateData, Headhunter enemy) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        isAnimationFinished = false;
        currentTransform.position = enemy.transform.position;
        rb = enemy.GetComponent<Rigidbody2D>();
        gravityScaleSet = rb.gravityScale;
        teleport = GameObject.FindWithTag("TeleportLocation").transform;
        // Debug.Log(teleport);
        rb.gravityScale = 0f;
        Movement.SetVelocityZero();
        enemy.transform.position = teleport.transform.position;
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void FinishAttack()
    {
        base.FinishAttack();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isAnimationFinished)
        {
            rb.gravityScale = gravityScaleSet;
            enemy.transform.position = currentTransform.position;
            stateMachine.ChangeState(enemy.emptyState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        // projectile = GameObject.Instantiate(stateData.projectile, attackPosition.position, attackPosition.rotation);
    }
}
