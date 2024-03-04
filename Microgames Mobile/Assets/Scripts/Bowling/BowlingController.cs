using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingController : MonoBehaviour
{
    private Vector3 touchDown;
    private Vector3 touchUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) {
            touchDown = Input.touches[0].position;
        }
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended) {
            touchUp = Input.touches[0].position;
            Vector3 dir = touchUp - touchDown;
            GameObject.Find("Bowling Ball").GetComponent<BowlingBall>().Launch(dir);
        }
    }
}
