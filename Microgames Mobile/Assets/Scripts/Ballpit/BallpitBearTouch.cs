using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallpitBearTouch : MonoBehaviour
{
    private float speed = 20f;
    public float distance = 1f;
    private bool isFlying = false;
    private bool touched = false;
    private bool bellPlayed = false;
    GameController gc;
    
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.state == GameController.State.FloatingResult
            && gc.result == 0) {
            if (!bellPlayed) {
                GetComponent<AudioSource>().Play();
                bellPlayed = true;
            }
            GetComponent<Rigidbody>().isKinematic = true;
            Quaternion targetRotation = Quaternion.Euler(270,180,0);
            Vector3 targetPosition = transform.position + Vector3.up * 2f;
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.5f * Time.deltaTime);
            transform.Rotate(0, 0, 1);
            return;
        }
        if (!touched && Controls.GetTouchDown() &&
            Controls.GetTouchObject3D(Input.GetTouch(0)) == gameObject) {
            //Debug.Log("Bear touched!");
            Microcontroller mc = GameObject.Find("Microcontroller").GetComponent<Microcontroller>();
            mc.GameBeaten();
            isFlying = true;
            touched = true;
            GetComponent<Rigidbody>().isKinematic = true;
            Camera.main.GetComponent<PerspectiveSwitcher>().SwitchPerspective();
        }
        // Check if the animation is active
        if (isFlying)
        {
            // Calculate the target position based on the camera's forward vector and distance
            Vector3 targetPosition = Camera.main.transform.position + Camera.main.transform.forward * distance;

            Quaternion targetRotation = Quaternion.Euler(240,180,0);
            // Move the object towards the target position at a constant speed
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);

            // Check if the object has reached the target position or close enough
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Stop the animation
                isFlying = false;
            }
        }
        if (touched) {
            transform.Rotate(0, 0, 1);
        }
    }
}
