using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeDucksController : MonoBehaviour
{
    public GameObject duck1;
    public GameObject duck2;
    public GameObject duckContainer;
    public GameObject goalPlane;
    public int direction;
    public float height;
    public float timer = 0;
    private bool launched = false;
    // Start is called before the first frame update
    void Start()    
    {
        duck1 = GameObject.Find("Duck1");
        duck2 = GameObject.Find("Duck2");
        duckContainer = GameObject.Find("DuckContainer");
        goalPlane = GameObject.Find("Goal");

        direction = Random.Range(0, 2);
        height = Random.Range(-10, 10);

        if (direction == 0) {
            direction = -1;
        }

        duck1.GetComponent<DodgeDucksDuck>().dirMultiplier = direction;
        duck2.GetComponent<DodgeDucksDuck>().dirMultiplier = direction;
        goalPlane.GetComponent<DodgeDucksGoal>().dirMultiplier = direction;
        goalPlane.transform.localPosition = new Vector3(2.5f * -direction, 0, 0);
        duckContainer.transform.position = new Vector3(25 * -direction, height, duckContainer.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2 && !launched) {
            duck1.GetComponent<DodgeDucksDuck>().Launch();
            duck2.GetComponent<DodgeDucksDuck>().Launch();
            goalPlane.GetComponent<DodgeDucksGoal>().Launch();
            launched = true;
        }
    }
}