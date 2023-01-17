using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpState : State
{
    protected D_WallJumpState stateData;

    protected bool isGrounded;
    protected bool isWallJumpOver;
    protected bool isAnimationFinished;

    #region Core Components
	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
	private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

	private Movement movement;
	private CollisionSenses collisionSenses;    
    #endregion
    public WallJumpState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_WallJumpState stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = CollisionSenses.Ground;
    }

    public override void Enter()
    {
        base.Enter();

        isWallJumpOver = false;

        Movement.SetVelocity(stateData.wallJumpSpeed, stateData.wallJumpAngle, -Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(isAnimationFinished && isGrounded)
        {
            isWallJumpOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public virtual void FinishAttack()
    {
        isAnimationFinished = true;
    }
}
