using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBallTrigger : MonoBehaviour
{
    public Collider GolfBall;
    private Microcontroller mc;

    void Start()
    {
        mc = GameObject.Find("Microcontroller").GetComponent<Microcontroller>();
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other == GolfBall) {
            mc.GameBeaten();
        }
    }
}
