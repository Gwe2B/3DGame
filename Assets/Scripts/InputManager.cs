using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    [HideInInspector] public float MouseX;
    [HideInInspector] public float MouseY;
    [HideInInspector] public Vector2 moveValue;
    [HideInInspector] public bool jump = false;

    /*private InputAction mouseInput;
    
    public void OnEnable()
    {
        mouseInput.Enable();
    }

    public void OnDisable()
    {
        mouseInput.Disable();
    }

    private void Awake()
    {
        mouseInput = GetComponent<PlayerInput>().currentActionMap.FindAction("MouseDelta");

        Debug.Log(mouseInput);
        Debug.Log(mouseInput.enabled);
        Debug.Log(mouseInput.performed);

        mouseInput.performed += _ =>
        {
            Vector2 value = _.ReadValue<Vector2>();
            MouseX = value.x;
            MouseY = value.y;
        };
    }*/

    public void OnMouseDelta(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        Debug.Log("Mouse movement");
    }

    public void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if(value.isPressed) { jump = true; }
        else { jump = false; }
    }

    public void OnPause() { PauseManager.PM.TogglePause(); }
}
