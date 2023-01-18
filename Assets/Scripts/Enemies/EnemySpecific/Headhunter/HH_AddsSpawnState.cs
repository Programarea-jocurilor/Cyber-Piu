using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HH_AddsSpawnState : AddsSpawnState
{
    private Headhunter enemy;
    private GameObject enemy1;
    private GameObject enemy2;

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
        Combat.isDamageable = false;
    }

    public override void Exit()
    {
        base.Exit();
        Combat.isDamageable = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Stats.currentHealth == 5 && spawnEnemies == true)
        {
            GameObject.Instantiate(stateData.enemies[0], enemy.transform.position, Quaternion.Euler(0f, 0f, 0f)).name = "Enemy adds";
            spawnEnemies = false;
        }
        else if(Stats.currentHealth == 4 && spawnEnemies == true)
        {
            GameObject.Instantiate(stateData.enemies[1], enemy.transform.position, Quaternion.Euler(0f, 0f, 0f)).name = "Enemy adds";
            spawnEnemies = false;
        }
        else if(Stats.currentHealth == 2 && spawnEnemies == true)
        {
            GameObject.Instantiate(stateData.enemies[1], enemy.transform.position, Quaternion.Euler(0f, 0f, 0f)).name = "Enemy adds";
            GameObject.Instantiate(stateData.enemies[0], enemy.transform.position, Quaternion.Euler(0f, 0f, 0f)).name = "Enemy adds";
            spawnEnemies = false;
        }
        else if((Stats.currentHealth == 3 || Stats.currentHealth == 1) && spawnEnemies == true)
        {
            spawnEnemies = false;
        }
        else if(spawnEnemies == false && isAnimationFinished == true)
        {
            enemy1 = GameObject.Find("Enemy adds");
            // enemy2 = GameObject.Find("Enemy2(Clone)");
            if(enemy1 == null)
            {
                enemy.stateMachine.ChangeState(enemy.emptyState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void FinishAnimation()
    {
        base.FinishAnimation();
    }
}
