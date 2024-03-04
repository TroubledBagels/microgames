using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count5Button : MonoBehaviour
{
    public bool pressed = false;

    public void Sink() {
        Debug.Log("Button pressed!");
        pressed = true;
    }

    void Update() {
        if (pressed) {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.01f);
        }
    }
}
