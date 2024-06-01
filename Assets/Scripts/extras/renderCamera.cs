using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderCamera : MonoBehaviour
{
    public GameObject canvas;
    public Camera cam;
    private bool check = true;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        cam.projectionMatrix = Matrix4x4.Perspective(60f, Screen.width / Screen.height, 0.001f, 1000f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (check)
        {
            canvas.SetActive(true);
            check = false;
        }
        else
        {
            canvas.SetActive(false);
            check = true;
        }
    }
}
