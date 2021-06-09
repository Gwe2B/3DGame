using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class PlayerScript : MonoBehaviour
{
    public float horizontalSensitivity = 30f;
    public float verticalSensitivity = 30f;
    public float moveSpeed = 5f;

    [Range(1, 10)] public float jumpVelocity = 2f;
    [Range(1, 10)] public float fallMultiplier = 2.5f;
    [Range(1, 10)] public float lowJumpMultiplier = 2f;

    private InputManager inputManager;
    private new Rigidbody rigidbody;

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (inputManager.jump && Mathf.Approximately(0, rigidbody.velocity.y))
        { rigidbody.velocity = Vector3.up * jumpVelocity; }
        else if (rigidbody.velocity.y < -0.1)
        { rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime; }

        transform.Translate(new Vector3(inputManager.moveValue.x, 0, inputManager.moveValue.y) * moveSpeed * Time.deltaTime);
    }
}
