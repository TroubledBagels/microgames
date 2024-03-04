using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    private bool gameFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Rigidbody>().velocity = new Vector3(0,0,25);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(Vector3 dir) {
        dir.Normalize();
        GetComponent<Rigidbody>().velocity = new Vector3(dir.x * 30, 0, dir.y * 30);
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "Pin" && !gameFinished) {
            gameFinished = true;
            GameObject.Find("Microcontroller").GetComponent<Microcontroller>().GameBeaten();
        }
        else if ((col.gameObject.name == "Gutter" || col.gameObject.name == "BackWall") && !gameFinished) {
            gameFinished = true;
            GameObject.Find("Microcontroller").GetComponent<Microcontroller>().GameLost();
        }
    }
}
