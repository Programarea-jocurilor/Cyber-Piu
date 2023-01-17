using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HH_WallJumpState : WallJumpState
{
    private Headhunter enemy;
    private bool isTouchingWallBack;
    public HH_WallJumpState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_WallJumpState stateData, Headhunter enemy) : base(etity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isTouchingWallBack = CollisionSenses.WallBack;
    }

    public override void Enter()
    {
        base.Enter();
        isTouchingWallBack = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isWallJumpOver)
        {
            stateMachine.ChangeState(enemy.emptyState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if(isTouchingWallBack)
        {
            Movement.SetVelocity(stateData.wallJumpSpeed, stateData.wallJumpAngle, Movement.FacingDirection);
        }
    }
}
