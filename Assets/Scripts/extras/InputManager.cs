using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionAsset inputActionsAsset;
    private InputActionMap turretMap;
    private InputActionMap drivingMap;
    private InputActionMap MgMap;
    private InputActionMap xrHead;
    private InputActionMap xriLeftHand;
    private InputActionMap xriRightHand;
    private InputActionMap xriLeftHandLocomotion;
    private InputActionMap xriRightHandLocomotion;

    //private InputActionMap gameplayActionMap;
    void Awake()
    {
        turretMap = inputActionsAsset.FindActionMap("Turret Rotation Mode");
        drivingMap = inputActionsAsset.FindActionMap("Driving Mode");
        MgMap = inputActionsAsset.FindActionMap("Machine Gun Mode");
        xrHead = inputActionsAsset.FindActionMap("XRI Head");
        xriLeftHand = inputActionsAsset.FindActionMap("XRI LeftHand");
        xriRightHand = inputActionsAsset.FindActionMap("XRI RightHand");
        xriLeftHandLocomotion = inputActionsAsset.FindActionMap("XRI LeftHand Locomotion");
        xriRightHandLocomotion = inputActionsAsset.FindActionMap("XRI RightHand Locomotion");
        NormalMode();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        NormalMode();
    }
    private void OnDisable()
    {

    }

    public void NormalMode()
    {
        inputActionsAsset.Disable();
        inputActionsAsset.Enable();
        xriLeftHandLocomotion.Disable();
        xriLeftHandLocomotion.FindAction("Move").Enable();
        xriRightHandLocomotion.FindAction("Turn").Disable();
        xriRightHandLocomotion.FindAction("Move").Disable();
        xriRightHandLocomotion.FindAction("Grab Move").Disable();
        turretMap.Disable();
    }

    public void TurretMode()
    {
        inputActionsAsset.Disable();
        turretMap.Enable();
        xrHead.Enable();
        xriLeftHand.Enable();
        xriRightHand.Enable();
    }

    public void DrivingMode()
    {
        inputActionsAsset.Disable();
        drivingMap.Enable();
        xrHead.Enable();
        xriLeftHand.Enable();
        xriRightHand.Enable();
    }
    
    public void MachineGunMode()
    {
        inputActionsAsset.Disable();
        MgMap.Enable();
        xrHead.Enable();
        xriLeftHand.Enable();
        xriRightHand.Enable();
    }

}
