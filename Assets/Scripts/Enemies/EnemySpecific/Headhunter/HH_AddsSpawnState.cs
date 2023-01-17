using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HH_AddsSpawnState : AddsSpawnState
{
    private Headhunter enemy;

    public HH_AddsSpawnState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_AddsSpawnState stateData, Headhunter enemy) : base(etity, stateMachine, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
