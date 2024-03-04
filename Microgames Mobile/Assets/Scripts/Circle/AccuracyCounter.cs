using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AccuracyCounter : MonoBehaviour
{  
    public float accuracy = 100.0f;
    public TMP_Text textComponent;
    private float timer = 0;
    private Gradient faceGradient = new Gradient();
    void Start()
    {
        var colors = new GradientColorKey[3];
        colors[0] = new GradientColorKey(Color.red, 0.0f);
        colors[1] = new GradientColorKey(Color.yellow, 0.5f);    
        colors[2] = new GradientColorKey(Color.green, 1.0f);    

        var alphas = new GradientAlphaKey[2];
        alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
        alphas[1] = new GradientAlphaKey(1.0f, 1.0f);
        faceGradient.SetKeys(colors, alphas);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float display = 0;

        if (timer < 2.0f) {
            display = Random.Range(0.0f, 100.0f);
        }  
        else {
            display = accuracy;
        }
        
        textComponent.SetText(string.Format("{0:00.00}", display) + "%");
        textComponent.faceColor = faceGradient.Evaluate(display / 100.0f);
    }
}
