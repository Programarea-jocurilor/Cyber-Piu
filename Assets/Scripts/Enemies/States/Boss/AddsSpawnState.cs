using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddsSpawnState : State
{
    #region Core Components
    protected Stats Stats => stats ? stats : core.GetCoreComponent(ref stats);
    protected Stats stats;
	protected Combat Combat { get => combat ?? core.GetCoreComponent(ref combat); }
    protected Combat combat;
    #endregion

    protected bool isAnimationFinished;
    protected bool spawnEnemies;
    protected D_AddsSpawnState stateData;

    public AddsSpawnState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_AddsSpawnState stateData) : base(etity, stateMachine, animBoolName)
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
        entity.atsm.addsSpawnState = this;
        isAnimationFinished = false;
        spawnEnemies = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public virtual void FinishAnimation()
    {
        isAnimationFinished = true;
        spawnEnemies = true;
    }
}
