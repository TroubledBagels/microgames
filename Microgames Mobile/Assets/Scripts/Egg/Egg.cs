using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    // Start is called before the first frame update
    private float value;
    private bool cracking = false;
    private bool cracked = false;
    private int crackCount = 0;
    private float timer = 1;

    private Vector3 lastPos;
    private Vector3 lastRot;

    public GameObject half1;
    public GameObject half2;
    
    void Start()
    {
        Input.gyro.enabled = true;
    }   

    // Update is called once per frame
    void Update()
    {
        if (cracked) {
            GetComponent<Renderer>().enabled = false;
            half1.GetComponent<Renderer>().enabled = true;
            half2.GetComponent<Renderer>().enabled = true;

            if (timer <= 1) {
                timer += Time.deltaTime;
            }
            
            transform.localPosition = new Vector3(EasingFunction.EaseOutQuad(lastPos.x, -2.24f, timer),
                                            EasingFunction.EaseOutQuad(0, 1.37f, timer), 1);
            transform.localRotation = Quaternion.Euler(lastRot.x + 30 * EasingFunction.EaseOutQuad(0, 1, timer), 
                                 -90, 90);

            half1.transform.localPosition = new Vector3(0, EasingFunction.EaseOutQuad(0, 0.00294f, timer), 1);
            half1.transform.localRotation = Quaternion.Euler(0 - 65.073f * EasingFunction.EaseOutQuad(0, 1, timer), 
                                 0, 0);
            
            half2.transform.localPosition = new Vector3(EasingFunction.EaseOutQuad(0, -3.09944f, timer), 1);
            half2.transform.localRotation = Quaternion.Euler(0 + EasingFunction.EaseOutQuad(0, 62.657f, timer), 
                                 0, 0);
            
            return;
        }
        
        if (Input.gyro.rotationRateUnbiased.z > 8f && !cracking) {
            Debug.Log("WE ARE MOOOOOOOOOOOVING");
            timer = 0;
            cracking = true;
            Handheld.Vibrate();
        }

        if (cracking) {
            value = Mathf.Clamp(timer, 0, 1);
        }
        else {
            value = EasingFunction.EaseOutQuad(1, 0, timer);
        }

        if (timer < 1) {
            timer += cracking ? Time.deltaTime * 10 : Time.deltaTime * 2;
        } 
        else {
            if (cracking) {
                cracking = false;
                timer = 0;
                crackCount++;
            }
        }

        value = Mathf.Clamp(value, 0, 1);

        transform.position = new Vector3(Mathf.Lerp(2.71f, 0.93f, value), Mathf.Lerp(1.37f, 0.57f, value), 1);
        transform.rotation = Quaternion.Euler(new Vector3(Mathf.Lerp(-75, -30, value), -90, 90));

        if (crackCount > 2) {
            cracked = true;
            lastPos = transform.position;
            lastRot = transform.rotation.eulerAngles;
            timer = 0;
        }

    }

    protected void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        GUILayout.Label("Orientation: " + Screen.orientation);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
        GUILayout.Label("iphone width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
    }
}
