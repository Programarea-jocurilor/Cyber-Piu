using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgeRollState : PlayerAbilityState
{
//    public bool CanDodgeRoll { get; private set; }
    private int dodgeRollDirection;

    private float lastDodgeRollTime;

    private Vector2 lastAIPos;
    
    public PlayerDodgeRollState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UseDodgeRollInput();
        dodgeRollDirection = core.Movement.FacingDirection;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!isExitingState)
        {
            core.Movement.SetVelocityX(playerData.dodgeRollVelocity * dodgeRollDirection);
            CheckIfShouldPlaceAfterImage();

            if(Time.time >= startTime + playerData.dodgeRollTime)
            {
                isAbilityDone = true;
                lastDodgeRollTime = Time.time;
            }
        }
        //TODO: Ignore damage
    }

    public bool CheckIfCanDodgeRoll()
    {
        return Time.time >= lastDodgeRollTime + playerData.dodgeRollCooldown && core.CollisionSenses.Ground;
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
