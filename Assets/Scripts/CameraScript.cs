using Assets.Scripts.Managers;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public float horizontalSensitivity = 30f;
    public float verticalSensitivity   = 30f;

    //private Camera camera;
    private InputManager inputManager;

    private void Start()
    {
        inputManager = player.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*float rotationX = horizontalSensitivity * inputManager.MouseX * Time.deltaTime;
        float rotationY = horizontalSensitivity * inputManager.MouseY * Time.deltaTime;

        inputManager.MouseX = 0;
        inputManager.MouseY = 0;

        Vector3 cameraRotation = transform.rotation.eulerAngles;
        cameraRotation.x -= rotationY;
        cameraRotation.y -= rotationX;

        transform.rotation = Quaternion.Euler(cameraRotation);
        transform.position = player.position + offset;*/
    }
}
