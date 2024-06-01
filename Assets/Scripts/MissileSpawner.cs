using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missilePrefab;
    public GameObject leftController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Missile Spawner")
        {
            Debug.Log("Collision Detected.");
            GameObject SpawnedPrefab = Instantiate(missilePrefab);
            SpawnedPrefab.transform.position = leftController.transform.position;
            SpawnedPrefab.transform.rotation = leftController.transform.rotation;
        }
        
    }
}
