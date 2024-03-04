using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToGoalController : MonoBehaviour
{
    public GameObject goal;
    public BoxCollider playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GameObject.Find("Player 2D").GetComponent<BoxCollider>();
        goal = GameObject.Find("Goal");
        float rngOne = Random.Range(-5, 10);
        float rngTwo = Random.Range(-10, 5);
        goal.transform.position = new Vector3(rngOne, rngTwo, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
