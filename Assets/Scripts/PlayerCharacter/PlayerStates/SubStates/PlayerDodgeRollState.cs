using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeRollState : PlayerAbilityState
{
//    public bool CanDodgeRoll { get; private set; }
    private int dodgeRollDirection;

    private float lastDodgeRollTime;

    private Vector2 lastAIPos;
    
    protected Combat Combat { get => combat ?? core.GetCoreComponent(ref combat); }

	private Combat combat;
    public PlayerDodgeRollState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UseDodgeRollInput();
        dodgeRollDirection = Movement.FacingDirection;
        Combat.isDamageable = false;
    }

    public override void Exit()
    {
        combat.isDamageable = true;
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            Movement.SetVelocityX(playerData.dodgeRollVelocity * dodgeRollDirection);
            CheckIfShouldPlaceAfterImage();

            if(Time.time >= startTime + playerData.dodgeRollTime)
            {
                isAbilityDone = true;
                lastDodgeRollTime = Time.time;
            }
        }
    }

    public bool CheckIfCanDodgeRoll()
    {
        return Time.time >= lastDodgeRollTime + playerData.dodgeRollCooldown && CollisionSenses.Ground;
    }

    private void CheckIfShouldPlaceAfterImage()
    {
        if(Vector2.Distance(player.transform.position, lastAIPos) >= playerData.distBetweenAfterImages)
        {
            PlaceAfterImage();
        }
    }

    private void PlaceAfterImage()
    {
        PlayerAfterImagePool.Instance.GetFromPool();
        lastAIPos = player.transform.position;
    }
}
