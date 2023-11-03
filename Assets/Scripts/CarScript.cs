using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    // public WheelCollider wheelFrontLeft;
    // public WheelCollider wheelFrontRight;
    // public WheelCollider wheelBackLeft;
    // public WheelCollider wheelBackRight;
    // public Transform wheelFrontLeftTransform;
    // public Transform wheelFrontRightTransform;
    // public Transform wheelBackLeftTransform;
    // public Transform wheelBackRightTransform;
    // public float speed = 2000.0f;
    // public float wheelRadius;
    // float distancePerRevolution; 

    //// Let camera follow the moving car
    public Transform target; // Reference to the object you want the camera to follow
    public float smoothSpeed = 0.125f; // Adjust the smoothness of camera movement
    public Vector3 offset; // Adjust the camera's offset from the target object


    void LateUpdate()
    {
        offset = new Vector3(-3f,2f,-3f);
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }


    // Update is called once per frame
    // void Update()
    // {
    //     // // Calculate the distance traveled per wheel revolution
    //     // wheelRadius = 0.174f;
    //     // distancePerRevolution = 2 * Mathf.PI * wheelRadius;
    //     // // Apply motor torque to the back wheels
    //     // wheelBackLeft.motorTorque = Input.GetAxis("Vertical")*speed;
    //     // wheelBackRight.motorTorque = Input.GetAxis("Vertical")*speed;

    //     // // Rotate the wheels based on the distance traveled
    //     // float rotationAmount = (distancePerRevolution * Mathf.Rad2Deg) * (wheelBackLeft.rpm / 60) * Time.deltaTime;

    //     // wheelFrontLeftTransform.Rotate(0.0f,rotationAmount, 0.0f);
    //     // wheelFrontRightTransform.Rotate(0.0f,rotationAmount, 0.0f);
    //     // wheelBackLeftTransform.Rotate(0.0f,rotationAmount, 0.0f);
    //     // wheelBackRightTransform.Rotate(0.0f,rotationAmount, 0.0f);
    // }
}
