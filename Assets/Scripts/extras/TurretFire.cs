using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class TurretFire : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;

    public XRLever lever;

    public float speed = 15000f;

    //public GameObject parti;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lever.value == true)
        {
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = bulletTransform.position;
            spawnedBullet.transform.rotation = bulletTransform.rotation;

            spawnedBullet.GetComponent<Rigidbody>().AddForce(speed * bulletTransform.transform.forward * Time.deltaTime, ForceMode.Impulse);
        }
    }

}
