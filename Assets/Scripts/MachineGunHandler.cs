using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class MachineGunHandler : MonoBehaviour
{
    public InputActionProperty leftJoyStick;
    public InputActionProperty rightJoyStick;
    public GameObject mg;
    public float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 leftJoyStickValue = leftJoyStick.action.ReadValue<Vector2>();
        Vector2 rightJoyStickValue = rightJoyStick.action.ReadValue<Vector2>();

        Debug.Log(leftJoyStickValue);

        // Calculate Y-axis rotation
        float rotationVelocityY = rotationSpeed * rightJoyStickValue.x;
        float currentRotationY = mg.transform.localEulerAngles.y;

        // Adjust currentRotationY to be in the range of -180 to 180 degrees
        if (currentRotationY > 180)
        {
            currentRotationY -= 360;
        }

        // Calculate the new rotation
        float newRotationY = currentRotationY + (rotationVelocityY * Time.deltaTime);

        // Clamp the new rotation between -70 and 70 degrees
        newRotationY = Mathf.Clamp(newRotationY, -70f, 70f);

        // Apply the clamped rotation
        if (Mathf.Abs(rightJoyStickValue.x) > 0.5f)
        {
            mg.transform.localEulerAngles = new Vector3(mg.transform.localEulerAngles.x, newRotationY, mg.transform.localEulerAngles.z);
        }

        // Calculate X-axis rotation
        float rotationVelocityX = rotationSpeed * leftJoyStickValue.y;
        float currentRotationX = mg.transform.localEulerAngles.x;

        // Adjust currentRotationX to be in the range of -180 to 180 degrees
        if (currentRotationX > 180)
        {
            currentRotationX -= 360;
        }

        // Calculate the new rotation and clamp it
        float newRotationX = currentRotationX + (rotationVelocityX * Time.deltaTime);
        newRotationX = Mathf.Clamp(newRotationX, -20f, 10f);

        // Apply the clamped rotation
        if (Mathf.Abs(leftJoyStickValue.y) > 0.5f)
        {
            mg.transform.localEulerAngles = new Vector3(newRotationX, mg.transform.localEulerAngles.y, mg.transform.localEulerAngles.z);
        }
    }
}
