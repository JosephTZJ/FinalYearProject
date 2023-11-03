using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceControlCameraScript : MonoBehaviour
{
    private Quaternion baseRotation = new Quaternion(1, 1, -1, -1);
    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            transform.rotation = GyroToUnity(Input.gyro.attitude) * baseRotation;
            // transform.rotation = Quaternion.Euler(180, 0, 0);
        }
            
    }

    private Quaternion GyroToUnity (Quaternion q)
    {
        // return new Quaternion.Euler(180, 0, 0);
        return new Quaternion(q.x, -q.y, q.z, q.w);
    }
}
