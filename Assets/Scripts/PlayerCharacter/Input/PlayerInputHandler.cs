using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawDashDirectionInput { get; private set; }
    public Vector2Int DashDirectionInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    // public bool GrabInput { get; private set; }
    public bool DashInput { get; private set; }
    public bool DashInputStop { get; private set; }
    public bool DodgeRollInput { get; private set; }
    public bool DodgeRollInputStop { get; private set; }

    public bool[] AttackInputs { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.01f; //TODO: fix

    private float jumpInputStartTime;
    private float dashInputStartTime;
    private float dodgeRollInputStartTime;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[count];

        cam = Camera.main;
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }

    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);
        // if(Mathf.Abs(RawMovementInput.x)>0.01f)
        // {
        //     NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        // }
        // else
        // {
        //     NormInputX = 0;
        // }

        // if(Mathf.Abs(RawMovementInput.y)>0.01f)
        // {
        //     NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
        // }
        // else
        // {
        //     NormInputY = 0;
        // }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    // public void OnGrabInput(InputAction.CallbackContext context)
    // {
    //     if (context.started)
    //     {
    //         GrabInput = true;
    //     }

    //     if (context.canceled)
    //     {
    //         GrabInput = false;
    //     }
    // }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput = true;
            DashInputStop = false;
            dashInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            Debug.Log("DashInput context cancel");
            MenuState state = MenuState.Instance;
            if (state.IsRunning()) {
                DashInputStop = true;
            }
        }      
    }

    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
        if (!MenuState.Instance.IsRunning()) {
            return;
        }

        RawDashDirectionInput = context.ReadValue<Vector2>();

        if((playerInput.currentControlScheme == "Keyboard") && cam)
        {
            RawDashDirectionInput = cam.ScreenToWorldPoint((Vector3)RawDashDirectionInput) - transform.position;
        }

        DashDirectionInput = Vector2Int.RoundToInt(RawDashDirectionInput.normalized);
    }

    public void OnDodgeRollInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DodgeRollInput = true;
            DodgeRollInputStop = false;
            dodgeRollInputStartTime = Time.time;
        }
        if (context.canceled)
        {
            DodgeRollInputStop = true;
        }
    }

    public void UseJumpInput() => JumpInput = false;

    public void UseDashInput() => DashInput = false;

    public void UseDodgeRollInput() => DodgeRollInput = false;

    private void CheckJumpInputHoldTime()
    {
        if(Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    private void CheckDashInputHoldTime()
    {
        if(Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }
}

public enum CombatInputs
{
    primary,
    secondary
}