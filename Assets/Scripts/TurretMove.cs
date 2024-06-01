using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TurretMove : MonoBehaviour
{
    public XRKnob knob;

    public GameObject turretPrefab;

    public InputActionProperty leftSelectValue;
    public InputActionProperty rightSelectValue;

    public XRDirectInteractor LeftDirectInteractor;
    public XRDirectInteractor RightDirectInteractor;

    public float rotationSpeed;

    void Update()
    {
        // Calculate rotation velocity based on knob value
        float rotationVelocity = rotationSpeed * Mathf.Lerp(-1, 1, knob.value);
        Vector3 rotationVector = new Vector3(0, rotationVelocity, 0);
        Quaternion deltaRotation = Quaternion.Euler(rotationVector * Time.deltaTime);

        var leftDirectHit = LeftDirectInteractor.GetOldestInteractableSelected();
        var rightDirectHit = RightDirectInteractor.GetOldestInteractableSelected();

        // Check if the left select value is valid and the leftDirectInteractor hits the Turret Steer or right slect value action is valid and rightDirectInteractor hits the Turret Steer 
        if ((leftSelectValue.action.ReadValue<float>() > 0 && leftDirectHit.transform.name == "Turret Steer") || (rightSelectValue.action.ReadValue<float>() > 0 && rightDirectHit.transform.name == "Turret Steer"))
        {
            // Apply rotation if the action is triggered
            turretPrefab.transform.rotation *= deltaRotation;
        }
    }
}
