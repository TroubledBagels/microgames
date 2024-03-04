using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CueBall : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 direction;
    
    void Start()
    {
        //Launch(10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Launch(float magnitude) {
        GetComponent<Rigidbody>().AddRelativeForce(transform.forward * magnitude, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision col)
    {
        var obj = col.gameObject;

        if (col.gameObject.name == "PoolCue")
        {
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            direction = obj.transform.forward;
            Launch(obj.GetComponent<Cue>().velocity * 0.5f);
            var rb = col.gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.velocity = Vector3.zero; 
        }
    }
}
