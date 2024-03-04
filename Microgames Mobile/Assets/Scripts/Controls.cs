using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public static float GetAccelX() {
        return Input.acceleration.x;
    }

    public static float GetAccelY() {
        return Input.acceleration.y;
    }

    public static float GetAccelZ() {
        return Input.acceleration.z;
    }

    public static Vector3 GetAccel() {
        return Input.acceleration;
    }

    public static GameObject GetTouchObject3D(Touch touch) {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;
        //Debug.Log("Ray casted");
        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider != null) {
                //Debug.Log("Ray hit");
                Debug.Log(hit.collider.gameObject.name);
                return hit.collider.gameObject;
            }
            else {
                return null;
            }
        }
        return null;
    }

    public static GameObject GetTouchObject2D(Touch touch) {
        Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
        if (hit.collider != null) {
            Debug.Log(hit.collider.gameObject.name);
            return hit.collider.gameObject;
        }
        else {
            return null;
        }
    }

    public static bool IsTouching() {
        return Input.touchCount > 0;
    }

    public static bool GetTouchDown() {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }

    public static float GetGyroX() {
        return Input.gyro.rotationRate.x;
    }

    public static float GetGyroY() {
        return Input.gyro.rotationRate.y;
    }

    public static float GetGyroZ() {
        return Input.gyro.rotationRate.z;
    }

    public static Vector3 GetGyro() {
        return Input.gyro.rotationRate;
    }
}
