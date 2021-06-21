using Assets.Scripts.Managers;
using Assets.Scripts.Player.InventorySystem;
using System;
using UnityEngine;

namespace Assets.Scripts.Player {
    public class PlayerScript : MonoBehaviour {
        [SerializeField] private InventoryUI inventoryUI;

        public float moveSpeed = 5f;

        [Range(1, 10)] public float jumpVelocity = 2f;
        [Range(1, 10)] public float fallMultiplier = 2.5f;

        private InputManager inputManager;
        private Animator animator;
        private new Rigidbody rigidbody;

        private Inventory inventory;

        private void Awake()
        {
            // Initializing the required components

            // Get all necessary components
            inputManager = GetComponent<InputManager>();
            rigidbody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();

            // Create the player inventory and attach it the UI
            inventory = new Inventory();
            //inventoryUI.SetInventory(inventory);
        }

        // Called once per frame
        void Update() {
            // --- JUMP ---
            if (inputManager.hasJumpInput && Mathf.Approximately(0, rigidbody.velocity.y))
            { rigidbody.velocity = Vector3.up * jumpVelocity; }
            else if (rigidbody.velocity.y < -0.1)
            { rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime; }
            // --- JUMP ---

            // Movement Manager (using animations)
            if (inputManager.moveInput.x == 0 && inputManager.moveInput.y == 0) {
                // No movements
                animator.SetBool("Walk", false);
                animator.SetBool("Sprint", false);
            } else {
                Debug.Log("Hello");
                double playerOrientation = (180 / Math.PI) * 
                    Mathf.Atan(inputManager.moveInput.x / inputManager.moveInput.y);

                if (inputManager.moveInput.y < 0) playerOrientation += 180f;
                
                transform.rotation = Quaternion.Euler(new Vector3(0, (float)playerOrientation, 0));

                animator.SetBool("Walk", true);
                if (animator.GetBool("Sprint") != inputManager.hasSprintInput) {
                    animator.SetBool("Sprint", inputManager.hasSprintInput);
                }
            }
        }
    }
}