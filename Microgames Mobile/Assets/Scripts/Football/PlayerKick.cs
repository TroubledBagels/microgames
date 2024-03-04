using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Bouncy") {
            Vector3 Force = new Vector3(transform.forward.x, 0.4f, transform.forward.z);
            col.gameObject.GetComponent<Rigidbody>().AddForce(Force * 1000);
        }
    }
}
