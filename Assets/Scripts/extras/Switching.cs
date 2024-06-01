using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEngine.InputSystem;

public class Switching : MonoBehaviour
{
    public XROrigin xrOrigin1;
    public XROrigin xrOrigin2;

    void Start()
    {
        // Initialize by setting only one XR Origin active
        xrOrigin1.gameObject.SetActive(true);
        xrOrigin2.gameObject.SetActive(false);
        
        ResetCamera(xrOrigin1);
        ConfigureCamera(xrOrigin1);
    }

    void Update()
    {
        // Example input handling for switching XR Origins
        // You can replace this with your actual input handling code
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchToOrigin1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchToOrigin2();
        }
    }

    void SwitchToOrigin1()
    {
        Debug.Log("Switching to XR Origin 1");
        xrOrigin1.gameObject.SetActive(true);
        xrOrigin2.gameObject.SetActive(false);
        ResetCamera(xrOrigin1);
        ConfigureCamera(xrOrigin1);
    }

    void SwitchToOrigin2()
    {
        Debug.Log("Switching to XR Origin 2");
        xrOrigin1.gameObject.SetActive(false);
        xrOrigin2.gameObject.SetActive(true);
        ResetCamera(xrOrigin2);
        ConfigureCamera(xrOrigin2);
    }

    void ResetCamera(XROrigin xrOrigin)
    {
        // Reset camera offset
        xrOrigin.CameraYOffset = 0; // Or set to a default value
        xrOrigin.transform.localPosition = Vector3.zero;
        xrOrigin.transform.localRotation = Quaternion.identity;
    }

    void ConfigureCamera(XROrigin xrOrigin)
    {
        Camera xrCamera = xrOrigin.GetComponentInChildren<Camera>();
        if (xrCamera != null)
        {
            // Set camera properties if needed
            xrCamera.clearFlags = CameraClearFlags.Skybox;
            xrCamera.backgroundColor = Color.black;
        }
    }
}
