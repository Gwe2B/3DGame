using Assets.Scripts.Managers;
using Assets.Scripts.Player.InventorySystem;
using System;
using UnityEngine;

namespace Assets.Scripts.Player {
    public class PlayerScript : MonoBehaviour {
        [SerializeField] private InventoryUI inventoryUI;

        /*public float horizontalSensitivity = 30f;
        public float verticalSensitivity = 30f;*/
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
            inputManager = GetComponent<InputManager>();
            rigidbody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();

            inventory = new Inventory();
            inventoryUI.SetInventory(inventory);
        }

        void Update() {
            if (inputManager.hasJumpInput && Mathf.Approximately(0, rigidbody.velocity.y))
            { rigidbody.velocity = Vector3.up * jumpVelocity; }
            else if (rigidbody.velocity.y < -0.1)
            { rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime; }

            if (inputManager.moveInput.x == 0 && inputManager.moveInput.y == 0) {
                animator.SetBool("Walk", false);
            } else {
                double alphaAngle = (180 / Math.PI) * 
                    Mathf.Atan(inputManager.moveInput.x / inputManager.moveInput.y);

                if (inputManager.moveInput.y < 0) alphaAngle += 180f;
                
                transform.rotation = Quaternion.Euler(new Vector3(0, (float)alphaAngle, 0));
                animator.SetBool("Walk", true);
            }
        }
    }
}