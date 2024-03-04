using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DevTimer : MonoBehaviour
{
    private Microcontroller mc;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mc = GameObject.Find("Microcontroller").GetComponent<Microcontroller>();
        for (int i = 0; i < mc.totalTime; ++i) {
            if (mc.timer >= i) {
                if (mc.timer <= mc.totalTime) {
                    GetComponent<TMP_Text>().text = Mathf.Ceil(mc.totalTime - mc.timer).ToString();
                }
                else {
                    // Make text red
                    
                    GetComponent<TMP_Text>().text = "0";
                }
            }
        }
    }
}
