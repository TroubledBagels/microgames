using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteController : MonoBehaviour
{
    private GameObject red;
    private GameObject yellow;
    private GameObject blue;
    private GameObject white;
    private string target = "";
    public GameController gc;
    private Microcontroller mc;
    public List<string> reqList;
    public List<string> curSelected;

    // Start is called before the first frame update
    void Awake()
    {
        curSelected = new List<string>();

        int rng = Random.Range(0, 5);
        switch (rng) {
            case 0:
                target = "Orange";
                reqList = new List<string>() {"Red", "Yellow"};
                break;
            case 1:
                target = "Purple";
                reqList = new List<string>() {"Blue", "Red"};
                break;
            case 2:
                target = "Green";
                reqList = new List<string>() {"Blue", "Yellow"};
                break;
            case 3:
                target = "Pink";
                reqList = new List<string>() {"Red", "White"};
                break;
            case 4: 
                target = "Brown";
                reqList = new List<string>() {"Blue", "Red", "Yellow"};
                break;
            case 5:
                target = "Light Blue";
                reqList = new List<string>() {"Blue", "White"};
                break;
        }
        mc = GameObject.Find("Microcontroller").GetComponent<Microcontroller>();
        mc.instruction = "Make " + target.ToLower() + "!";
        //mc.ShowInstruction();
        foreach (string s in reqList) {
            Debug.Log(s);
        }

        GameObject red = GameObject.Find("Red");
        GameObject yellow = GameObject.Find("Yellow");
        GameObject blue = GameObject.Find("Blue");
        GameObject white = GameObject.Find("White");
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: FIX
        if (Controls.GetTouchDown()) {
            GameObject go = Controls.GetTouchObject3D(Input.touches[0]);
            curSelected.Add(go.name);
            curSelected.Sort();
            int index = 0;
            bool accurate = true;
            foreach (string s in reqList) {
                if (index >= curSelected.Count) {
                    accurate = false;
                    break;
                }
                if (s != curSelected[index]) {
                    accurate = false;
                    break;
                }
                index++;
            }
            Debug.Log(accurate);
            if (accurate) {
                mc.GameBeaten();
            }
        }
    }

    void AddColour(string colour) {

    }
}
