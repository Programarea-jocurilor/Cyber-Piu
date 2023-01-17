using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HH_WallJumpState : WallJumpState
{
    private Headhunter enemy;

    public HH_WallJumpState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_WallJumpState stateData, Headhunter enemy) : base(etity, stateMachine, animBoolName, stateData)
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
            //state transitions
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
