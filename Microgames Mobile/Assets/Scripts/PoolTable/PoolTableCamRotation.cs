    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTableCamRotation : MonoBehaviour
{
    private float x;
    private float y;

    const float sensitivity = 50.0f;

    private Gyroscope gyro;
    public GameObject cb;

    void Start()
    {
        cb = GameObject.Find("CueBall");
        Input.gyro.enabled = true;
    }

    public void RotateUpDown(float axis)
    {
        transform.RotateAround(cb.transform.position, transform.right, -axis * Time.deltaTime);
    }

    //rotate the camera rigt and left (y rotation)
    public void RotateRightLeft(float axis)
    {
        transform.RotateAround(cb.transform.position, Vector3.up, -axis * Time.deltaTime);
    }

    void Update()
    {
        GyroRotation();
    }
    void GyroRotation()
    {
        Debug.Log(Controls.GetGyro());
        x = Controls.GetGyroX();
        y = Controls.GetGyroY();

        //float xFiltered = FilterGyroValues(x);
       // RotateUpDown(xFiltered * sensitivity);

        float yFiltered = FilterGyroValues(y);
        RotateRightLeft(yFiltered * sensitivity);
    }

    float FilterGyroValues(float axis)
    {
        if (axis < -0.1 || axis > 0.1)
        {
            return axis;
        }
        else
        {
            return 0;
        }
    }
}