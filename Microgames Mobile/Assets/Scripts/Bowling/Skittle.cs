using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skittle: MonoBehaviour
{
    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.name == "Pin" && !done){
            done = true;
            GetComponent<Renderer>().enabled = false;
            GetComponent<ParticleSystem>().Play();
        }
        else if (col.gameObject.name == "Bowling Ball" && !done) {
            done = true;
            GetComponent<Renderer>().enabled = false;
            GetComponent<ParticleSystem>().Play();
        }
    }
}
