using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAim : MonoBehaviour
{
    // Start is called before the first frame update
    private Ray ray;
    private RaycastHit hit;

    public float rayMaxDist = 6f;
    
    public GameObject aimPrefab;
    private GameObject spawnedAimPrefab;
    //private GameObject spawnedAimPrefab;
    
    void Start()
    {
        spawnedAimPrefab = Instantiate(aimPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(this.transform.position, this.transform.forward, out hit, rayMaxDist);

        if(hit.transform != null && !hit.transform.CompareTag("Missile Variant"))
        {
            
            spawnedAimPrefab.transform.position = new Vector3(hit.point.x,hit.point.y+0.1f,hit.point.z);
            //spawnedAimPrefab.transform.rotation = hit.transform.rotation;
        }

    }
}
