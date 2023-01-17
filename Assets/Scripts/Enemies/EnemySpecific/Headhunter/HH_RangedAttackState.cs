using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HH_RangedAttackState : RangedAttackState
{
    private Headhunter enemy;
    // private GameObject player;
    // private Quaternion ang_Left; 
    // private Quaternion ang_Right;
    // [SerializeField]
    // private Transform rangedAttackPivot;
    public HH_RangedAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData, Headhunter enemy) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
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
        // player = GameObject.FindGameObjectWithTag("Player");

        // ang_Left.y = 180;
        // if (player.position.x - rangedAttackPivot.transform.position.x <= 0)
        // { 
        //     rangedAttackPivot.transform.SetPositionAndRotation(rangedAttackPivot.transform.position , ang_Left); 
        // } 
        // else
        // { 
        //     rangedAttackPivot.transform.SetPositionAndRotation(rangedAttackPivot.transform.position , ang_Right); 
        // }
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

        if (isAnimationFinished)
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
        projectile = GameObject.Instantiate(stateData.projectile, attackPosition.position, attackPosition.rotation);
    }
}
