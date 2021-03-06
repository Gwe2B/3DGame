using Assets.Scripts.Managers;
using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class OldPlayerScript : MonoBehaviour
    {
        public float horizontalSensitivity = 30f;
        public float verticalSensitivity = 30f;
        public float moveSpeed = 5f;

        [Range(1, 10)] public float jumpVelocity = 2f;
        [Range(1, 10)] public float fallMultiplier = 2.5f;

        private InputManager inputManager;
        private new Rigidbody rigidbody;

        private void Start()
        {
            inputManager = GetComponent<InputManager>();
            rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {

            if (inputManager.hasJumpInput && Mathf.Approximately(0, rigidbody.velocity.y))
            { rigidbody.velocity = Vector3.up * jumpVelocity; }
            else if (rigidbody.velocity.y < -0.1) {
                rigidbody.velocity += Vector3.up * Physics.gravity.y *
                    (fallMultiplier - 1) * Time.deltaTime;
            }

            transform.Translate(new Vector3(
                inputManager.moveInput.x, 
                0, 
                inputManager.moveInput.y
            ) * moveSpeed * Time.deltaTime);
        }
    }
}