using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerDashState : PlayerAbilityState
{
    private AudioSource dash_sound;

    public bool CanDash { get; private set; }
    private bool isHolding;
    private bool dashInputStop;

    private float lastDashTime;

    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;
    private Vector2 lastAIPos;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, AudioSource srcDashSound) : base(player, stateMachine, playerData, animBoolName)
    {
        dash_sound = srcDashSound;
    }

    public override void Enter()
    {
        base.Enter();
        player.JumpState.DecreaseAmountOfJumpsLeft();
        CanDash = false;
        player.InputHandler.UseDashInput();

        isHolding = true;
        dashDirection = Vector2.right * Movement.FacingDirection;

        Debug.Log("Player set Timescale: " + playerData.holdTimeScale);
        Time.timeScale = playerData.holdTimeScale;
        startTime = Time.time;

        player.DashDirectionIndicator.gameObject.SetActive(true);
        player.CollisionDamage.gameObject.SetActive(true);

    }

    public override void Exit()
    {
        base.Exit();
        player.CollisionDamage.gameObject.SetActive(false);
        if(Movement.CurrentVelocity.y > 0)
        {
            Movement.SetVelocityY(Movement.CurrentVelocity.y * playerData.dashEndYMultiplier);
        }


    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {

            // player.Anim.SetFloat("yVelocity", Movement.CurrentVelocity.y);
            // player.Anim.SetFloat("xVelocity", Mathf.Abs(Movement.CurrentVelocity.x));


            if (isHolding)
            {
                // dashDirectionInput = player.InputHandler.DashDirectionInput;
                dashDirectionInput = player.InputHandler.RawDashDirectionInput;
                dashInputStop = player.InputHandler.DashInputStop;

                if(dashDirectionInput != Vector2.zero)
                {
                    dashDirection = dashDirectionInput;
                    dashDirection.Normalize();
                }

                float angle = Vector2.SignedAngle(Vector2.right, dashDirection);
                player.DashDirectionIndicator.rotation = Quaternion.Euler(0f, 0f, angle - 45f);

                if(dashInputStop || Time.time >= startTime + playerData.maxHoldTime * playerData.holdTimeScale)
                {
                    isHolding = false;
                    
                    Debug.Log("Finish hold time");
                    Time.timeScale = 1f;
                    
                    startTime = Time.time;
                    Movement.CheckIfShouldFlip(Mathf.RoundToInt(dashDirection.x));
                    player.RB.drag = playerData.drag;
                    Movement.SetVelocity(playerData.dashVelocity, dashDirection);
                    player.DashDirectionIndicator.gameObject.SetActive(false);
                    PlaceAfterImage();
                    dash_sound.Play();
                }
            }
            else
            {
                //Movement.CheckIfShouldFlip(Mathf.RoundToInt(dashDirection.x));
                Movement.SetVelocity(playerData.dashVelocity, dashDirection);
                CheckIfShouldPlaceAfterImage();

                if (Time.time >= startTime + playerData.dashTime)
                {
                    player.RB.drag = 0f;
                    isAbilityDone = true;
                    lastDashTime = Time.time;
                }
            }
        }
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

    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }

    public void ResetCanDash() => CanDash = true;

}