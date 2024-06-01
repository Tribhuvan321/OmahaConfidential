using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class TankFireController : MonoBehaviour
{
    // Start is called before the first frame update

    public InputActionProperty leftTrigger;
    public InputActionProperty rightTrigger;
    private bool shooted = false;
    private float speed = 200f;
    public GameObject shell;
    public GameObject socket;
    public Transform bulletSpawnPoint;
    public ParticleSystem explosion;
    void Start()
    {
        //var spawnPoint = bulletSpawnPoint.gameObject;
        //spawnPoint.GetComponent<TankFireController>().enabled = true;

    }
    // Update is called once per frame
    void Update()
    {
        bool check = socket.GetComponent<SocketEntryCheck>().check;
        if (leftTrigger.action.ReadValue<float>() > 0.5f && rightTrigger.action.ReadValue<float>() > 0.5f && !shooted && check)
        {
            Debug.Log(leftTrigger.action.ReadValue<float>() + rightTrigger.action.ReadValue<float>());
            GameObject spawnedShell = Instantiate(shell);

            spawnedShell.transform.rotation = bulletSpawnPoint.rotation;
            //spawnedShell.transform.rotation = Quaternion.identity;
            //Vector3 eulerAngles = spawnedShell.transform.rotation.eulerAngles;
            Vector3 eulerAngles = new Vector3(90f, 0f, 0f);
            spawnedShell.transform.Rotate(eulerAngles);
            spawnedShell.transform.position = bulletSpawnPoint.position;

            Rigidbody shellRigidbody = spawnedShell.GetComponent<Rigidbody>();
            shellRigidbody.AddForce(bulletSpawnPoint.transform.forward * speed, ForceMode.Impulse);
            explosion.Play();
            shooted = true;
            StartCoroutine(ReloadTime());
        }
    }

    IEnumerator ReloadTime()
    {
        yield return new WaitForSeconds(3f);
        shooted = false;
    }

}