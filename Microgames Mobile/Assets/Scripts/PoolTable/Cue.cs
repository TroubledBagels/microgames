using UnityEngine;

public class Cue : MonoBehaviour
{
    private bool launched = false;
    public float velocity = 0;

    void Start()
    {
    }

    void Update()
    {
        
    }
    public void Launch(float magnitude)
    {
        GetComponent<Rigidbody>().AddRelativeForce(transform.forward * magnitude, ForceMode.Impulse);
        velocity = magnitude;
    }
}

