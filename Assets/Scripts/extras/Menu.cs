using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionProperty menuButton;
    public GameObject oldOrigin;
    public GameObject newOrigin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menuButton.action.WasPressedThisFrame())
        {
            oldOrigin.SetActive(false);
            newOrigin.SetActive(true);
        }
    }
}
