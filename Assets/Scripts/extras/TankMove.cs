using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float speed = 10f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(this.transform.forward * speed, ForceMode.Force);
    }
}
