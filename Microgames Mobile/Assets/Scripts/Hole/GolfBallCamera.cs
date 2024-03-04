using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform ball;
    public Vector3 offset;
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = ball.position + offset;
    }
}
