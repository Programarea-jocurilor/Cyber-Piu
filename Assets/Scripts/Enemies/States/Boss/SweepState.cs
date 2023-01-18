using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepState : AttackState
{
    protected D_SweepState stateData;
    #region Core Components
	protected Combat Combat { get => combat ?? core.GetCoreComponent(ref combat); }
    protected Combat combat;
	protected Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    protected Movement movement;
    #endregion
    protected GameObject projectile;
    protected Projectile projectileScript;

    public SweepState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_SweepState stateData) : base(etity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
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

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
}
