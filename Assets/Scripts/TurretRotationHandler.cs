using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretRotationHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public InputManager inputManager;
    public GameObject turretMovable;
    public GameObject outerRod;
    public float rotationSpeed = 5f;

    void Start()
    {

    }

    // Update is called once per frame

    private void OnEnable()
    {
        inputManager.inputActionsAsset.FindActionMap("Turret Rotation Mode").FindAction("Left Axis").performed += TurretVertical;
        inputManager.inputActionsAsset.FindActionMap("Turret Rotation Mode").FindAction("Right Axis").performed += TurretHorizontal;
    }
    private void OnDisable()
    {
        inputManager.inputActionsAsset.FindActionMap("Turret Rotation Mode").FindAction("Left Axis").performed -= TurretVertical;
        inputManager.inputActionsAsset.FindActionMap("Turret Rotation Mode").FindAction("Right Axis").performed -= TurretHorizontal;
    }
    void Update()
    {
        
    }
    void TurretHorizontal(InputAction.CallbackContext context)
    {
        Vector2 rightJoyStickValue = context.ReadValue<Vector2>();
        float rotationVelocityY = rotationSpeed * rightJoyStickValue.x;
        Vector3 rotationVectorY = new Vector3(0, rotationVelocityY, 0);
        Quaternion deltaRotation = Quaternion.Euler(rotationVectorY * Time.deltaTime);


        if (rightJoyStickValue.x > 0.5f || rightJoyStickValue.x < -0.5f)
        {

            turretMovable.transform.rotation *= deltaRotation;
        }
    }
    void TurretVertical(InputAction.CallbackContext context)
    {
        Vector2 leftJoyStickValue = context.ReadValue<Vector2>();

        float rotationVelocityX = rotationSpeed * leftJoyStickValue.y;
        Vector3 rotationVectorX = new Vector3(rotationVelocityX, 0, 0);
        Quaternion deltaRotation = Quaternion.Euler(rotationVectorX * Time.deltaTime);

        float currentRotationX = outerRod.transform.localEulerAngles.x;

        // Adjust currentRotationX to be in the range of -180 to 180 degrees
        if (currentRotationX > 180)
        {
            currentRotationX -= 360;
        }

        // Calculate the new rotation and clamp it
        float newRotationX = currentRotationX + (rotationVelocityX * Time.deltaTime);
        newRotationX = Mathf.Clamp(newRotationX, -20f, 10f);

        // Apply the clamped rotation
        if (leftJoyStickValue.y > 0.5f || leftJoyStickValue.y < -0.5f)
        {

            outerRod.transform.localEulerAngles = new Vector3(newRotationX, outerRod.transform.localEulerAngles.y, outerRod.transform.localEulerAngles.z);
        }
    }
}
