using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashDishController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameController gc;
    public ParticleSystem sparkle;
    public ParticleSystem confetti;
    public ParticleSystem water;

    private bool played = false;
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (played) return;
        if (gc.state == GameController.State.FloatingResult && gc.result == 1)
        {
            sparkle.Play();
            confetti.Play();
            water.Stop();
            played = true;
        }
    }
}
