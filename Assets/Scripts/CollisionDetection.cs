using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem ps;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        ps.Play();
        StartCoroutine(Destroyer());
       
    }
    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
       
    }
}
