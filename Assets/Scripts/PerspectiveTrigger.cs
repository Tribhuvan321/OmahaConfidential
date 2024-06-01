using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PerspectiveTrigger : MonoBehaviour
{
    //public GameObject setup;
    public GameObject xrOrigin;
    public GameObject tank;

    public InputManager im;
    //public DisableColliders dc;

    private Vector3 xrOriginOgTransform = new Vector3(0f,0f,0f);

    public InputActionProperty menuButton;
    public InputActionProperty Abutton;

    private bool inTurretMode = false;
    private bool inDrivingMode = false;
    private bool inMgMode = false;

    private void Update()
    {
        if (menuButton.action.WasPressedThisFrame() && inTurretMode == true)
        {
            im.NormalMode();
            xrOrigin.GetComponent<TurretRotationHandler>().enabled = false;
            xrOrigin.GetComponent<CharacterController>().enabled = true;
            xrOrigin.transform.localPosition = xrOriginOgTransform;
            inTurretMode = false;
            
        }
        if (menuButton.action.WasPressedThisFrame() && inDrivingMode == true)
        {
            im.NormalMode();
            xrOrigin.GetComponent<TankMovement>().enabled = false;
            xrOrigin.transform.localPosition = xrOriginOgTransform;
            xrOrigin.GetComponent<DisableColliders>().EnableCollidersRecursively(tank.transform);
            xrOrigin.GetComponent<CharacterController>().enabled = true;
            Debug.Log("teleported");
            inDrivingMode = false;

        }
        if (menuButton.action.WasPressedThisFrame() && inMgMode == true)
        {
            im.MachineGunMode();
            xrOrigin.GetComponent<MachineGunHandler>().enabled = false;
            xrOrigin.GetComponent<CharacterController>().enabled = true;
            xrOrigin.transform.localPosition = xrOriginOgTransform;
            inMgMode = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if((other.name == "Left Controller" || other.name == "Right Controller") && gameObject.name == "Turret Perspective Trigger")
        {
            xrOriginOgTransform = xrOrigin.transform.localPosition;
            Debug.Log(xrOriginOgTransform);
            xrOrigin.transform.localPosition = new Vector3(-3.4f, 4.6f, -0.9f);
            im.TurretMode();
            xrOrigin.GetComponent<TurretRotationHandler>().enabled = true;
            xrOrigin.GetComponent<CharacterController>().enabled = false;
            inTurretMode = true;
        }
        if ((other.name == "Left Controller" || other.name == "Right Controller") && gameObject.name == "Driver Perspective Trigger")
        {
            xrOriginOgTransform = xrOrigin.transform.localPosition;
            Debug.Log(xrOriginOgTransform);
            xrOrigin.transform.localPosition = new Vector3(-3.4f, 4.6f, -0.9f);
            im.DrivingMode();
            xrOrigin.GetComponent<DisableColliders>().DisableCollidersRecursively(tank.transform);
            xrOrigin.GetComponent<TankMovement>().enabled = true;
            xrOrigin.GetComponent<CharacterController>().enabled = false;
            inDrivingMode = true;
        }
        if ((other.name == "Left Controller" || other.name == "Right Controller") && gameObject.name == "MachineGun Perspective Trigger")
        {
            xrOriginOgTransform = xrOrigin.transform.localPosition;
            Debug.Log(xrOriginOgTransform);
            xrOrigin.transform.localPosition = new Vector3(0.0390000008f, 1.72000003f, 0.680000007f);
            im.MachineGunMode();
            xrOrigin.GetComponent<MachineGunHandler>().enabled = true;
            xrOrigin.GetComponent<CharacterController>().enabled = false;
            inMgMode = true;
        }

    }
}