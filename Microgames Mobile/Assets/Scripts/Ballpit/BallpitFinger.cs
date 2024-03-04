using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallpitFinger : MonoBehaviour
{
    GameObject particle;

    private float radius = 0.5f;
    private float power = 50.0f;

    private Vector3 explosionPos;

    private GameController gc;

    void Start() {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }
    void Update () {
        if (gc.result != -1) 
            return;
        for (int i = 0; i < Input.touchCount; ++i) {
            if (Input.GetTouch(i).phase != TouchPhase.Moved && Input.GetTouch(i).phase != TouchPhase.Began)
                continue;
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Vector3 direction = hit.point - transform.position;
                direction.y = 0;
                //GetComponent<Rigidbody>().position = hit.point;

                explosionPos = hit.point;
                Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
                foreach (Collider hi in colliders)
                {
                    // Make a circular outward force area that pushes the balls away
                    Rigidbody rb = hi.GetComponent<Rigidbody>();
                    if (rb != null)
                        rb.AddExplosionForce(power, explosionPos, radius, 0.0F);
                }
            }      
        }        
    }
}