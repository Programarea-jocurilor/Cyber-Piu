using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStatemachine : MonoBehaviour
{
    public AddsSpawnState addsSpawnState;
    public AttackState attackState;
    private void TriggerAttack()
    {
        attackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        attackState.FinishAttack();
    }

    private void FinishAnimation()
    {
        addsSpawnState.FinishAnimation();
    }
    
}
