using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackamoleController : MonoBehaviour
{
    private GameObject mole;
    private GameObject fMoleOne;
    private GameObject fMoleTwo;
    private int xOffset = 6;
    private int zOffset = 4;
    private bool started;
    private bool raised;
    private Microcontroller mc;
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        mc = GameObject.Find("Microcontroller").GetComponent<Microcontroller>();

        mole = GameObject.Find("Mole");
        fMoleOne = GameObject.Find("Fake Mole (1)");
        fMoleTwo = GameObject.Find("Fake Mole (2)");

        int rng = Random.Range(0, 9);
        int fakeOne;
        int fakeTwo;
        do {
            fakeOne = Random.Range(0, 9);
        } while (fakeOne == rng);
        do {
            fakeTwo = Random.Range(0, 9);
        } while (fakeTwo == rng || fakeTwo == fakeOne);
        AssignLocation(rng, mole);
        AssignLocation(fakeOne, fMoleOne);
        AssignLocation(fakeTwo, fMoleTwo);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!started) {
            started = mc.getIsStarted();
            
        }

        if (started & !raised) {
            Rise();
        }

        if (Controls.GetTouchDown() && started && gc.state != GameController.State.FloatingResult) {
            GameObject go = Controls.GetTouchObject3D(Input.touches[0]);
            if (go == mole) {
                mc.GameBeaten();
            }
            else if (go == fMoleOne || go == fMoleTwo) {
                mc.GameLost();
            }
        }
    }

    void Rise() {
        if (mole.transform.position.y < 1) {
            mole.transform.position = new Vector3(mole.transform.position.x, mole.transform.position.y + 0.02f, mole.transform.position.z);
            fMoleOne.transform.position = new Vector3(fMoleOne.transform.position.x, fMoleOne.transform.position.y + 0.02f, fMoleOne.transform.position.z);
            fMoleTwo.transform.position = new Vector3(fMoleTwo.transform.position.x, fMoleTwo.transform.position.y + 0.02f, fMoleTwo.transform.position.z);
        } else {
            raised = true;
        }
    }

    void AssignLocation(int rng, GameObject obj) {
        if (rng % 3 == 0) {
            obj.transform.position = new Vector3(-xOffset, -1, 0);
        }
        else if (rng % 3 == 1) {
            obj.transform.position = new Vector3(0, -1, 0);
        }
        else {
            obj.transform.position = new Vector3(xOffset, -1, 0);
        }

        if (Mathf.Floor(rng / 3) == 0) {
            obj.transform.position = new Vector3(obj.transform.position.x, -1, -zOffset);
        }
        else if (Mathf.Floor(rng / 3) == 1) {
            obj.transform.position = new Vector3(obj.transform.position.x, -1, 0);
        }
        else {
            obj.transform.position  = new Vector3(obj.transform.position.x, -1, zOffset);
        }
    }
}
