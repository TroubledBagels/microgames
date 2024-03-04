using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController3D : MonoBehaviour
{
    // Start is called before the first frame update
    public Joystick lookJS;
    public Joystick moveJS;
    public Button jumpButton;
    public Rigidbody rb;
    public BoxCollider bc;
    public GameObject camera;
    private bool isGrounded;
    public float groundDrag;
    public float playerHeight;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        camera = GameObject.Find("Main Camera");
        lookJS = GameObject.Find("Look Joystick").GetComponent<Joystick>();
        moveJS = GameObject.Find("Movement Joystick").GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f);
        
        Rotate(lookJS.Horizontal, lookJS.Vertical);
        Move();

        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void Rotate(float x, float y) {
        float xRot = x;
        float yRot = y;
        if (camera.transform.rotation.x > -0.7 && camera.transform.rotation.x < 0.7) {
            camera.transform.Rotate(-yRot, 0, 0);
        }
        transform.Rotate(0, xRot, 0);
    }

    void Move() {
        float x = moveJS.Horizontal;
        float y = moveJS.Vertical;
        Vector3 movement = new Vector3(x, 0, y);
        Vector3 cameraForward = camera.transform.forward;
        Vector3 cameraRight = camera.transform.right;
        movement = cameraForward * y + cameraRight * x;
        rb.AddForce(movement * 10, ForceMode.Force);
        if (rb.velocity.magnitude > 10) {
            rb.velocity = rb.velocity.normalized * 10;
        }
    }
}
