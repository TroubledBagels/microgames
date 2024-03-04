using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerTD : MonoBehaviour
{
    public Joystick js;
    public Rigidbody rb;
    public BoxCollider bc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        js = GameObject.Find("Movement Stick").GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(90, Rotate(), Rotate()), 0.1f);
    }

    void Move() {
        rb.velocity = new Vector3(js.Horizontal * 10, js.Vertical * 10, 0);
    }

    float Rotate() {
        float rotation = 0;
        if (js.Horizontal != 0) rotation = Mathf.Atan(js.Vertical/js.Horizontal) * (180/Mathf.PI);
        else if (js.Vertical > 0) return 0;
        else if (js.Vertical < 0) return 180;
        else if (js.Vertical == 0) return rb.rotation.z;
        if (js.Horizontal > 0 && js.Vertical > 0) {
            rotation = 90 - rotation;
        }
        else if (js.Horizontal > 0 && js.Vertical < 0) {
            rotation = 90 + rotation;
        }
        else if (js.Horizontal < 0 && js.Vertical > 0) {
            rotation = 270 - rotation;
        }
        else if (js.Horizontal < 0 && js.Vertical < 0) {
            rotation = 270 + rotation;
        }
        else if (js.Vertical == 0 && js.Horizontal > 0) {
            rotation = 90;
        }
        else if (js.Vertical == 0 && js.Horizontal < 0) {
            rotation = 270;
        }
        //Debug.Log(rotation);
        return rotation;
    }
}
