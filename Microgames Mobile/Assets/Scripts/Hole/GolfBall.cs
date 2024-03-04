using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour
{
    float neutralPitch = 45f;

    // Update is called once per frame
    void Update()
    {
        Quaternion accelerometerAdjustment = Quaternion.Euler(neutralPitch, 0f, 0f);
        Vector3 adjustedAcceleration = accelerometerAdjustment * Input.acceleration;
        
        GetComponent<Rigidbody>().AddForce(adjustedAcceleration.x * 10, 0, adjustedAcceleration.y * 10);
    }
}
