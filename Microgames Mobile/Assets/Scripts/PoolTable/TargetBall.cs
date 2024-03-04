using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBall : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateCameraAngle();
    }

    void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "Goal") {
            GameObject.Find("Microcontroller").GetComponent<Microcontroller>().GameBeaten();
        }
    }

    void CalculateCameraAngle() {
        float CameraAngle = 0;
        Vector2 planeVel = new Vector2(rb.velocity.x, rb.velocity.z);
        Vector2 planeVelN = planeVel.normalized;
        if (planeVelN.x > 0) {
            if (planeVelN.y > 0) {
                CameraAngle = (Mathf.PI / 2) - Mathf.Atan(planeVelN.y / planeVelN.x);
            }
            else if (planeVelN.y < 0) {
                CameraAngle = (Mathf.PI / 2) - Mathf.Atan(planeVelN.y / planeVelN.x);
            }
            else {
                CameraAngle = Mathf.PI / 2;
            }
        }
        else if (planeVelN.x < 0) {
            if (planeVelN.y > 0) {
                CameraAngle = Mathf.Atan(planeVelN.y / planeVelN.x) + ((3 * Mathf.PI) / 2);
            }
            else if (planeVelN.y < 0) {
                CameraAngle = ((3 * Mathf.PI) / 2) - Mathf.Atan(planeVelN.y / planeVelN.x);
            }
            else {
                CameraAngle = 3 * Mathf.PI / 2;
            }
        }
        else {
            if (planeVelN.y > 0) {
                CameraAngle = 0;
            }
            else if (planeVelN.y < 0) {
                CameraAngle = Mathf.PI;
            }
            else {
                CameraAngle = 0;
            }
        }

        GameObject.Find("CameraPoint").transform.rotation = Quaternion.Euler(0, CameraAngle * Mathf.Rad2Deg, 0);
    }
}
