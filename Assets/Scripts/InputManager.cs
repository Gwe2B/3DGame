using System;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Inputs
{
    public class InputManager : MonoBehaviour, StandardControls.IGameplayActions
    {
        private static string jsonInputMapFile = "Assets/Resources/Config/Controls.json";

        [SerializeField, Tooltip("Input Action Map asset for mouse/keyboard and game pad inputs")]
        private StandardControls standardControls;

        [SerializeField, Tooltip("Toggle the Cursor Lock Mode? Press ESCAPE during play mode to unlock")]
        private bool cursorLocked = true;

        public event Action JumpPressed;

        public Vector2 moveInput { get; private set; }

        public bool hasJumpInput { get; private set; }

        /*private void Start()
        {
            LoadControls();
        }*/

        /// <summary>
        /// Enable the controls
        /// </summary>
        protected void OnEnable()
        {
            string rebinds = PlayerPrefs.GetString("rebinds");
            Debug.Log(rebinds);

            if (standardControls == null)
            {
                standardControls = new StandardControls();
                standardControls.Gameplay.SetCallbacks(this);
            }
            standardControls.Gameplay.Enable();

            standardControls.asset.LoadFromJson(rebinds);

            //HandleCursorLock();
        }

        /// <summary>
        /// Disable the controls
        /// </summary>
        protected void OnDisable()
        {
            standardControls.Disable();
        }

        /// <summary>
        /// Save the control map to a JSON file
        /// </summary>
        /*public void SaveControls()
        {
            string JSONDatas = standardControls.asset.ToJson();

            if (File.Exists(jsonInputMapFile))
            { File.Delete(jsonInputMapFile); }

            var file = File.CreateText(jsonInputMapFile);
            file.WriteLine(JSONDatas);
            file.Close();
        }

        /// <summary>
        /// Load the previously saved control map from a JSON file.
        /// </summary>
        public void LoadControls()
        {
            if(File.Exists(jsonInputMapFile))
            {
                string JSONDatas;
                var file = File.OpenText(jsonInputMapFile);
                JSONDatas = file.ReadToEnd();
                file.Close();

                standardControls.asset.LoadFromJson(JSONDatas);
            } else
            {
                Debug.LogError($"Unable to find the Config file at {jsonInputMapFile}");
            }
        }*/

        /// <summary>
        /// Called when the player move the mouse.
        /// </summary>
        /// <param name="context">Required</param>
        /// <remarks>TODO</remarks>
        public void OnMouseLook(InputAction.CallbackContext context)
        {
            Debug.Log("Mouse move");
        }

        /// <summary>
        /// Called when the player hit the jump button.
        /// </summary>
        /// <param name="context">Required</param>
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

        /// <summary>
        /// Called when the player hit one of the moving buttons.
        /// </summary>
        /// <param name="context">Required</param>
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

        /// <summary>
        /// Called when the player hit pause button.
        /// </summary>
        /// <param name="context">Required</param>
        public void OnPause(InputAction.CallbackContext context)
        {
            PauseManager.PM.TogglePause();
        }
    }
}