using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliders : MonoBehaviour
{
    public GameObject tank;
    private bool rbAdded = false;
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        //tank.AddComponent<Rigidbody>();
        //tank.AddComponent<BoxCollider>();
    }
    public void DisableCollidersRecursively(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Collider childCollider = child.GetComponent<Collider>();

            if (childCollider != null && childCollider.gameObject.tag != "Tracks")
            {
                childCollider.enabled = false;
            }

            // Recursively disable colliders in children
            DisableCollidersRecursively(child);
        }
        if(rbAdded == false)
        {
            tank.AddComponent<Rigidbody>();
            rbAdded = true;
        }
        
    }
    public void EnableCollidersRecursively(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Collider childCollider = child.GetComponent<Collider>();

            if (childCollider != null && childCollider.gameObject.tag != "Tracks")
            {
                childCollider.enabled = true;
            }

            // Recursively disable colliders in children
            EnableCollidersRecursively(child);
        }
        if (rbAdded == true)
        {
            Destroy(tank.GetComponent<Rigidbody>());
            rbAdded = false;
        }
        
    }

}
