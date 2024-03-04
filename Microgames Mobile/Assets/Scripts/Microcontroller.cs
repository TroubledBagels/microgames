using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Microcontroller : MonoBehaviour
{
    public int totalTime = 10;
    public int endTime = 0;
    public int gameID = -1;
    GameController gc;
    public float timer = 0;
    private float fixedTimer = 0;
    public string instruction;
    private GameObject iSlide;
    private TextMeshProUGUI iText;
    private bool startTimer = false;
    private bool startFade = false;


    public void Start() {
        iText = GameObject.Find("InstructionText").GetComponent<TextMeshProUGUI>();
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        timer = 0;
        endTime = gc.FetchTimer();
    }
    public void ShowInstruction() {
        iText.SetText(instruction);
    }

    public void StartTimer() {
        startTimer = true;
    }
    // Update is called once per frame
    void Update() {
        if (startTimer && gc.state != GameController.State.FloatingResult) {
            if (timer < endTime)
                timer += Time.deltaTime;

            if (timer >= endTime) {
                GameLost();
                startTimer = false;
            }
        }
    }

    public void GameBeaten() {
        gc.result = 1;
        gc.state = GameController.State.FloatingResult;
        Debug.Log("Game beaten!");
    }

    public void GameLost() {
        gc.result = 0;
        gc.state = GameController.State.FloatingResult;
        Debug.Log("Game lost!");
    }

    void FixedUpdate() {
        fixedTimer += Time.fixedDeltaTime;
    }

    public bool getIsStarted() {
        return startTimer;
    }
}
