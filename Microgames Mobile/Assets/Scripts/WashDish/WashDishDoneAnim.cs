using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WashDishDoneAnim : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    public Vector3 init;
    void Start()
    {
        init = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Fly over to the target linearly
        transform.position = Vector3.Lerp(init, target.transform.position, Time.deltaTime) ;
    }
}
