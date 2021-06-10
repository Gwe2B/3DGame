using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, StandardControls.IGameplayActions
{
    [SerializeField, Tooltip("Input Action Map asset for mouse/keyboard and game pad inputs")]
    private StandardControls standardControls;

    [SerializeField, Tooltip("Toggle the Cursor Lock Mode? Press ESCAPE during play mode to unlock")]
    private bool cursorLocked = true;

    public event Action JumpPressed;

    public Vector2 moveInput { get; private set; }

    public bool hasJumpInput { get; private set; }

    protected void OnEnable()
    {

        if (standardControls == null)
        {
            standardControls = new StandardControls();
            standardControls.Gameplay.SetCallbacks(this);
        }
        standardControls.Gameplay.Enable();

        //HandleCursorLock();
    }

    protected void OnDisable()
    {
        standardControls.Disable();
    }

    public void OnMouseLook(InputAction.CallbackContext context)
    {
        Debug.Log("Mouse move");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            hasJumpInput = true;
            if (JumpPressed != null)
            {
                JumpPressed();
            }
        }
        else if (context.canceled)
        {
            hasJumpInput = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveInput = Vector2.zero;
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        PauseManager.PM.TogglePause();
    }
}
