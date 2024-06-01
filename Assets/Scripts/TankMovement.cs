using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class TankMovement : MonoBehaviour
{
    public InputActionProperty leftJoyStick;
    public InputActionProperty rightJoyStick;
    public GameObject tank;
    public float speed = 15f;
    public float rotationSpeed = 2f;
    private RaycastHit hit;
    public GameObject moveDirection;
    public bool? forward;
    private bool leftMotor;
    private bool rightMotor;
    private GameObject parent;
    //public GameObject child;
    private GameObject childMotor;
    void Start()
    {
        forward = null;
    }
    void FixedUpdate()
    {
        Vector2 leftJoyStickValue = leftJoyStick.action.ReadValue<Vector2>();
        Vector2 rightJoyStickValue = rightJoyStick.action.ReadValue<Vector2>();
        float leftRotationVelocityY = rotationSpeed * leftJoyStickValue.y;
        float rightRotationVelocityY = rotationSpeed * -rightJoyStickValue.y;
        float middleRotationVelocityY = rotationSpeed * leftJoyStickValue.y;
        Vector3 leftRotationVectorY = new Vector3(0, leftRotationVelocityY, 0);
        Vector3 middleRotationVectorY = new Vector3(0, middleRotationVelocityY, 0);
        Vector3 rightRotationVectorY = new Vector3(0, rightRotationVelocityY, 0);
        Quaternion leftDeltaRotation = Quaternion.Euler(leftRotationVectorY * Time.deltaTime);
        Quaternion rightDeltaRotation = Quaternion.Euler(rightRotationVectorY * Time.deltaTime);
        Quaternion middleDeltaRotation = Quaternion.Euler(middleRotationVectorY * Time.deltaTime);


        LeftMotorActive(leftJoyStickValue, rightJoyStickValue);
        RightMotorActive(leftJoyStickValue, rightJoyStickValue);

        if(leftJoyStickValue.y == 0 && rightJoyStickValue.y == 0)
        {
            MiddleMotorActive(leftJoyStickValue, rightJoyStickValue);
            
        }
       
        if (rightJoyStickValue.y > 0.5f && leftJoyStickValue.y > 0.5f)
        {
            MiddleMotorActive(leftJoyStickValue, rightJoyStickValue);
            //Debug.Log("if entered!");
            MoveTankForward(leftJoyStickValue, rightJoyStickValue);
            forward = true;
        }

        if (rightJoyStickValue.y < -0.5f && leftJoyStickValue.y < -0.5f)
        {
            MiddleMotorActive(leftJoyStickValue, rightJoyStickValue);
            MoveTankBackward(leftJoyStickValue, rightJoyStickValue);
            forward = false;
        }
        
        if ((leftJoyStickValue.y > 0.5f && rightJoyStickValue.y < -0.5f) || (leftJoyStickValue.y < -0.5f && rightJoyStickValue.y > 0.5f))
        {
            MiddleMotorActive(leftJoyStickValue, rightJoyStickValue);
            tank.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            parent.transform.localRotation *= middleDeltaRotation;
        }

        if (leftMotor)
        {
            MakeParent("Middle Motor");
            childMotor = GameObject.FindWithTag("Right Motor");
            childMotor.transform.SetParent(parent.transform);
            MakeParent("Right Motor");
            childMotor = GameObject.FindWithTag("Left Motor");
            childMotor.transform.SetParent(parent.transform);
            parent.transform.localRotation *= leftDeltaRotation;
        }
        if (rightMotor)
        {
            MakeParent("Middle Motor");
            childMotor = GameObject.FindWithTag("Left Motor");
            childMotor.transform.SetParent(parent.transform);
            MakeParent("Left Motor");
            childMotor = GameObject.FindWithTag("Right Motor");
            childMotor.transform.SetParent(parent.transform);
            parent.transform.localRotation *= rightDeltaRotation;

        }

        //CheckTerrainCollision();
    }

    void MoveTankForward(Vector2 leftJoyStickValue, Vector2 rightJoyStickValue)
    {
        //tank.GetComponent<Rigidbody>().AddForce(moveDirection.transform.forward * Time.deltaTime * speed, ForceMode.Impulse);
        //tank.transform.Translate(tank.transform.forward * Time.deltaTime * speed);
        RemoveConstraints("Middle Motor");
        tank.GetComponent<Rigidbody>().velocity = moveDirection.transform.forward * speed * (leftJoyStickValue.y+ rightJoyStickValue.y)/2;
        //tank.GetComponent<Rigidbody>().AddForce(moveDirection.transform.forward * Time.deltaTime * speed,ForceMode.Force);
    }

    void MoveTankBackward(Vector2 leftJoyStickValue, Vector2 rightJoyStickValue)
    {
        //tank.GetComponent<Rigidbody>().AddForce(-moveDirection.transform.forward * Time.deltaTime * speed, ForceMode.Impulse);
        RemoveConstraints("Middle Motor");
        tank.GetComponent<Rigidbody>().velocity = moveDirection.transform.forward * speed * (leftJoyStickValue.y + rightJoyStickValue.y)/2;
        //tank.transform.Translate(-moveDirection.transform.forward * Time.deltaTime * speed);
    }

    void LeftMotorActive(Vector2 leftJoyStickValue, Vector2 rightJoyStickValue)
    {
        if (rightJoyStickValue.y == 0 && leftJoyStickValue.y != 0)
        {
            leftMotor = true;
            rightMotor = false;
            RemoveConstraints("Left Motor");
        }
       
    }
    void RightMotorActive(Vector2 leftJoyStickValue, Vector2 rightJoyStickValue)
    {
        if (rightJoyStickValue.y != 0 && leftJoyStickValue.y == 0)
        {
            leftMotor = false;
            rightMotor = true;
            RemoveConstraints("Right Motor");
        }
        
    }
    void MiddleMotorActive(Vector2 leftJoyStickValue, Vector2 rightJoyStickValue)
    {
        leftMotor = false;
        rightMotor = false;
        MakeParent("Middle Motor");
        childMotor = GameObject.FindWithTag("Left Motor");
        childMotor.transform.SetParent(parent.transform);
        childMotor = GameObject.FindWithTag("Right Motor");
        childMotor.transform.SetParent(parent.transform);
        //RemoveConstraints("Middle Motor");

    }
    public void MakeParent(string tag)
    {
        
        parent = GameObject.FindWithTag(tag);
       
        Transform parentTransform = parent.transform;
        Transform childTransform = moveDirection.transform;

        childTransform.SetParent(parentTransform);

        
        // Call the function to make the childObject a child of parentObject recursively

        //if (tag != "Middle Motor")
        //{
        //    parent.transform.rotation *= deltaRotation;
        //}

    }
    public void RemoveConstraints(string tag)
    {
        //if(tag == "Middle Motor")
        //{
        //    //tank.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX| RigidbodyConstraints.FreezeRotationZ;
        //    //tank.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        //    //tank.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
        //    //tank.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        //    //tank.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        //}
        //else
        //{
            tank.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        //}
    }
    //public void MakeChildRecursive(Transform parent, Transform child)
    //{

    //    // Set the parent of the child
    //    child.SetParent(parent);

    //    // Recursively set the parent for all children of the child
    //    foreach (Transform grandchild in child)
    //    {
    //        MakeChildRecursive(child, grandchild);
    //    }
    //}

    //void CheckTerrainCollision()
    //{
    //    if (Physics.Raycast(tank.transform.position, Vector3.down, out hit, 50f))
    //    {
    //        float terrainHeight = hit.point.y;
    //        float tankHeight = tank.transform.position.y;

    //        if (tankHeight < terrainHeight + 0.5f)
    //        {
    //            Vector3 newPosition = new Vector3(tank.transform.position.x, terrainHeight + 0.5f, tank.transform.position.z);
    //            tank.transform.position = Vector3.Lerp(tank.transform.position, newPosition, 0.5f);
    //        }
    //    }
    //}
}