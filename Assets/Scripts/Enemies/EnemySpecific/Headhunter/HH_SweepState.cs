using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HH_SweepState : SweepState
{   
    private Headhunter enemy;
    private Transform[] teleport;
    private Rigidbody2D rb;
    private float gravityScaleSet;
    private Transform workSpace;

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
        rb = enemy.GetComponent<Rigidbody2D>();
        gravityScaleSet = rb.gravityScale;
        rb.gravityScale = 0f;
        Movement.SetVelocityZero();
        enemy.transform.position = stateData.teleportLocations[0].transform.position;
    }

    public override void Exit()
    {
        base.Exit();
        rb.gravityScale = gravityScaleSet;
        enemy.transform.position = stateData.teleportLocations[1].transform.position;
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
        workSpace = attackPosition;

        workSpace.transform.eulerAngles = new Vector3(
        workSpace.transform.eulerAngles.x + 180,
        workSpace.transform.eulerAngles.y + 180,
        workSpace.transform.eulerAngles.z);
        projectile = GameObject.Instantiate(stateData.projectile, attackPosition.position, workSpace.rotation);
        projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.FireProjectile(stateData.projectileSpeed, stateData.projectileTravelDistance, stateData.projectileDamage);
    }
}
