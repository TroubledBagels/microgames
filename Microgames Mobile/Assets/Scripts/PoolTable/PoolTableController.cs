using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTableController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject tb;
    public Cue cue;
    public bool launched = false;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        tb = GameObject.Find("TargetBall");
        cue = GameObject.Find("PoolCue").GetComponent<Cue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (launched) return;

        var accel = Input.acceleration;
        var accelZ = accel.z;
        Debug.Log(accelZ);

        if (accelZ > 0.8)
        {
            cue.Launch(7f);
            launched = true;
        }
        else if (accelZ > 0.6)
        {
            cue.Launch(20f);
            launched = true;
        }
        else if (accelZ > 0.4)
        {
            cue.Launch(30f);
            cue.Launch(accelZ * 50);
            launched = true;
        }
    }

    public void SwitchCamera() {
        mainCamera.transform.parent = GameObject.Find("CameraPoint").transform;
        mainCamera.transform.localPosition = new Vector3(0, 1, -5);
    }
}
