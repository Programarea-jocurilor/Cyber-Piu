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
        if(player)
        {
            if(player.transform.position.x > entity.transform.position.x && Movement.FacingDirection == -1)
            {
                Movement.Flip();
            }
            else if(player.transform.position.x < entity.transform.position.x && Movement.FacingDirection == 1)
            {
                Movement.Flip();
            }       
        }

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Combat.damageTaken == true)
        {
            Combat.damageTaken = false;
            stateMachine.ChangeState(enemy.addsSpawnState);
        }
        else if(player)
        {
            if(Mathf.Abs(Mathf.Abs(player.transform.position.x - entity.transform.position.x)) < 5f)
            {
                stateMachine.ChangeState(enemy.wallJumpState);
            }
            else 
            {
                stateMachine.ChangeState(enemy.rangedAttackState);
            }
        }


 
    }
}
