using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class TurretRotation : MonoBehaviour
{
    public InputActionProperty leftJoyStick;
    public InputActionProperty rightJoyStick;
    public GameObject turretMovable;
    public GameObject outerRod;
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

        float rotationVelocityY = rotationSpeed * rightJoyStickValue.x;
        Vector3 rotationVectorY = new Vector3(0, rotationVelocityY, 0);
        Quaternion deltaRotation = Quaternion.Euler(rotationVectorY * Time.deltaTime);


        if (rightJoyStickValue.x > 0.5f || rightJoyStickValue.x < -0.5f)
        {

            turretMovable.transform.rotation *= deltaRotation;
        }

        float rotationVelocityX = rotationSpeed * leftJoyStickValue.y;
        Vector3 rotationVectorX = new Vector3(rotationVelocityX, 0, 0);
        deltaRotation = Quaternion.Euler(rotationVectorX * Time.deltaTime);

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
//(leftJoyStickValue.y < -0.5f && rightJoyStickValue.y > 0.5f) || (leftJoyStickValue.y > 0.5f && rightJoyStickValue.y < -0.5f)
//(leftJoyStickValue.y > 0.5f && rightJoyStickValue.y > 0.5f) || (leftJoyStickValue.y < -0.5f && rightJoyStickValue.y < -0.5f)