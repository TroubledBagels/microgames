using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperCarController : MonoBehaviour
{
    // Start is called before the first frame update

    public WheelCollider front;
    public WheelCollider left;
    public WheelCollider right;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    private List<GameObject> bumpedCars = new List<GameObject>();
    private int bumps;

    private GameController gc;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if (gc.result == -1 && bumps >= 2)
        {
            Debug.Log("Game beaten!");
            gc.result = 1;
            gc.state = GameController.State.FloatingResult;
        }
    }

    void FixedUpdate()
    {
        //currentAcceleration = acceleration * Input.GetAxis("Vertical");
        
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    currentBreakForce = breakingForce;
        //}
        //else
        //{
        //    currentBreakForce = 0f;
        //}

        front.motorTorque = acceleration;

        float tiltX = Mathf.Clamp(Input.acceleration.x * 4f, -1f, 1f);
        float tiltY = Mathf.Clamp(Input.acceleration.y * 4f, -1f, 1f);

        currentTurnAngle = maxTurnAngle * tiltX;
        front.steerAngle = currentTurnAngle;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BumperCarAI") && !bumpedCars.Contains(collision.gameObject))
        {
            bumpedCars.Add(collision.gameObject);
            bumps++;
        }
    }
}
