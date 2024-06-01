using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaling : MonoBehaviour
{
     public GameObject XRSetup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "trigger")
        {
            XRSetup.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "trigger")
        {
            XRSetup.transform.localScale = new Vector3(0.18f, 0.18f, 0.18f);
        }

    }
}
