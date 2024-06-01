using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjecEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Manager;
    public InputActionProperty leftTrigger;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (leftTrigger.action.WasPressedThisFrame())
        {
            Manager.SetActive(!Manager.activeSelf);
        }
    }
}
