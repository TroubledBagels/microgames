using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScore : MonoBehaviour
{
    public SphereCollider sc;
    // Start is called before the first frame update
    void Start()
    {
        var rng = Random.Range(-4, 4);
        transform.position = new Vector3(rng, 2, 4);

        sc = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Goal") {
            GameObject.Find("Microcontroller").GetComponent<Microcontroller>().GameBeaten();
        }
    }
}
