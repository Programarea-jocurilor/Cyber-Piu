using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headhunter : Entity
{
    #region State References
    public HH_RangedAttackState rangedAttackState { get; private set; }
    public HH_EmptyState emptyState { get; private set; }
    public HH_AddsSpawnState addsSpawnState { get; private set; }
    public HH_WallJumpState wallJumpState { get; private set; }
    #endregion

    #region State Data
    [SerializeField]
    private D_RangedAttackState rangedAttackStateData;
    [SerializeField]
    private D_EmptyState emptyStateData;
    [SerializeField]
    private D_AddsSpawnState addsSpawnStateData;
    [SerializeField]
    private D_WallJumpState wallJumpStateData;
    #endregion

    // #region Core Components
    // private Combat Combat { get => combat ?? core.GetCoreComponent(ref combat); }
	// private Combat combat;
    // #endregion
    [SerializeField]
    private Transform rangedAttackPosition;

    public override void Awake()
    {
        base.Awake();
        rangedAttackState = new HH_RangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, rangedAttackStateData, this);
        emptyState = new HH_EmptyState(this, stateMachine, "empty", emptyStateData, this);
        addsSpawnState = new HH_AddsSpawnState(this, stateMachine, "addsSpawn", addsSpawnStateData, this);
        wallJumpState = new HH_WallJumpState(this, stateMachine, "wallJump", wallJumpStateData, this);
    }

    private void Start()
    {
        stateMachine.Initialize(emptyState);
    }

    // public override void OnDrawGizmos()
    // {
    //     base.OnDrawGizmos();
    //     Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    // }
}
