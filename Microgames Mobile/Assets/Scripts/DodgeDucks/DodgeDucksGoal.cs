using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeDucksGoal : MonoBehaviour
{
    public int dirMultiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch() {
        GetComponent<Rigidbody>().AddForce(new Vector3(5 * dirMultiplier, 0, 0), ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Player TD") {
            GameObject.Find("Microcontroller").GetComponent<Microcontroller>().GameBeaten();
        }
    }
}
