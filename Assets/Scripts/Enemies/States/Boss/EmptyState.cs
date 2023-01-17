using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyState : State
{
    #region Core Components
    protected Stats Stats => stats ? stats : core.GetCoreComponent(ref stats);
    protected Stats stats;
	private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private Movement movement;
    #endregion

    protected D_EmptyState stateData;
    protected bool isPlayerInCloseRangeAction;
    protected bool isPlayerInMinAgroRange;
    protected bool isPlayerInMaxAgroRange;

    public EmptyState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_EmptyState stateData) : base(etity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
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

    }
}
