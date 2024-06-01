using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float speed = 15000f;
    public GameObject bullet;
    public Transform bulletTransform;
    //public GameObject parti;

    void Start()
    {
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator wait()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(5);

            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = bulletTransform.position;
            spawnedBullet.transform.rotation = bulletTransform.rotation;
            spawnedBullet.GetComponent<Rigidbody>().AddForce(bulletTransform.forward * speed * Time.deltaTime, ForceMode.Impulse);
            //parti.SetActive(true);
            Destroy(spawnedBullet, 5);
            //parti.SetActive(false);
        }
    }
}
