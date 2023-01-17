using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HH_EmptyState : EmptyState
{
    private Headhunter enemy;
    private GameObject player;
    public HH_EmptyState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_EmptyState stateData, Headhunter enemy) : base(etity, stateMachine, animBoolName, stateData)
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
        player = GameObject.FindGameObjectWithTag("Player");
        // if(player.transform.position.x > entity.transform.position.x)
        // {

        // }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Mathf.Abs(Mathf.Abs(player.transform.position.x - entity.transform.position.x)) < 8f)
        {
            stateMachine.ChangeState(enemy.wallJumpState);
        }

        stateMachine.ChangeState(enemy.rangedAttackState);
    }
}
