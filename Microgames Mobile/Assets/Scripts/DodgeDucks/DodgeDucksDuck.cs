using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeDucksDuck : MonoBehaviour
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
            collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            collision.gameObject.GetComponent<ParticleSystem>().Play();
            GameObject.Find("Microcontroller").GetComponent<Microcontroller>().GameLost();
        }
    }
}
