using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTestController : MonoBehaviour
{
    Vector3 Accelerometer;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        var lastReading = Accelerometer;
        Accelerometer = Input.gyro.userAcceleration;
        
        var lastReadingLargeEnough = lastReading.x > 0.02f || lastReading.y > 0.02f || lastReading.z > 0.02f || lastReading.x < -0.02f || lastReading.y < -0.02f || lastReading.z < -0.02f;
        if (Accelerometer.x < 0.013f && Accelerometer.y < 0.013f && Accelerometer.z > -0.013f && Accelerometer.z < 0.013f && Accelerometer.y > -0.013f && Accelerometer.x > -0.013f && lastReadingLargeEnough) {
            Debug.Log(Accelerometer);
            GameObject.Find("Microcontroller").GetComponent<Microcontroller>().GameBeaten();
        }
    }
}
