using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Vector2 input;
    protected int xInput;
    protected int yInput;

    private bool JumpInput;
    private bool isGrounded;
    // private bool isTouchingWall;
    private bool dashInput;
    private bool dodgeRollInput;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = core.CollisionSenses.Ground;
        // isTouchingWall = core.CollisionSenses.WallFront;
    }

    public override void Enter()
    {
        base.Enter();

        player.JumpState.ResetAmountOfJumpsLeft();
        player.DashState.ResetCanDash();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        JumpInput = player.InputHandler.JumpInput;
        dashInput = player.InputHandler.DashInput;
        input = player.InputHandler.RawMovementInput;

        dodgeRollInput = player.InputHandler.DodgeRollInput;

        if (player.InputHandler.AttackInputs[(int)CombatInputs.primary])
        {
            stateMachine.ChangeState(player.PrimaryAttackState);
        }
        else if (player.InputHandler.AttackInputs[(int)CombatInputs.secondary])
        {
            stateMachine.ChangeState(player.SecondaryAttackState);
        }
        else if(JumpInput && player.JumpState.CanJump())
        {   
            
            stateMachine.ChangeState(player.JumpState);
        }
        else if (!isGrounded)
        {
            // player.JumpState.DecreaseAmountOfJumpsLeft();
            player.InAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.InAirState);
        }
        else if(dashInput && player.DashState.CheckIfCanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
        else if(dodgeRollInput) // && player.DodgeRollState.CheckIfCanDodgeRoll()
        {
            stateMachine.ChangeState(player.DodgeRollState);
        }


        
        // else if (JumpInput && player.JumpState.CanJump())
        // {
        //     stateMachine.ChangeState(player.JumpState);
        // }else if (!isGrounded)
        // {
        //     player.InAirState.StartCoyoteTime();
        //     stateMachine.ChangeState(player.InAirState);
        // }else if(isTouchingWall && grabInput && isTouchingLedge)
        // {
        //     stateMachine.ChangeState(player.WallGrabState);
        // }
        // else if (dashInput && player.DashState.CheckIfCanDash() && !isTouchingCeiling)
        // {
        //     stateMachine.ChangeState(player.DashState);
        // }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}