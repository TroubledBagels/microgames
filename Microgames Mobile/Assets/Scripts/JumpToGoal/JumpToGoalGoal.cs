using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToGoalGoal : MonoBehaviour
{
    public BoxCollider bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            GameObject.Find("Microcontroller").GetComponent<Microcontroller>().GameBeaten();
        }
    }
}
