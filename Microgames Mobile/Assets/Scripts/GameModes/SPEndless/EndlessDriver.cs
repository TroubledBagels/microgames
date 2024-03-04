using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessDriver : MonoBehaviour
{
    public int gameIndexOffset;
    private List<int> prevGames = new List<int>();
    public GameController gc;
    private float timer = 3;
    private bool playing = false;
    private Scene endlessMode;

    private int lives = 5;
    private int wins;
    private int speed = 10;

    public Canvas endlessUI;
    public Camera endlessCam;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI winsText;
    public TextMeshProUGUI timerText;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        endlessMode = SceneManager.GetActiveScene();
        PickGame();
    }
    void PickGame()
    {
        // if the game is within the latest half of the last played games, don't play it again

        HashSet<int> excludedGames = new HashSet<int>();
        for (int i = Mathf.CeilToInt(prevGames.Count / 2); i < prevGames.Count; ++i)
            excludedGames.Add(prevGames[i]);
       
        int rng;
        do {
            rng = Random.Range(gameIndexOffset, SceneManager.sceneCountInBuildSettings);
        } while (excludedGames.Contains(rng));

        prevGames.Add(rng);
        gc.code = rng.ToString("000") + speed.ToString("00") + lives.ToString("0");
        //StartCoroutine(gc.LoadGame(rng));
    }

    // Update is called once per frame
    void Update()
    {
        switch (gc.state) 
        {
            default:
                break;
            case GameController.State.LoadingGame:
                timerText.text = "Next game in " + Mathf.CeilToInt(timer);

                if (timer > 0)
                    timer -= Time.deltaTime;
                else
                {
                    // TODO: add a check to see if the game is finished loading
                    gc.activateGame = true;
                    playing = true;
                    endlessUI.enabled = false;
                    endlessCam.enabled = false;
                }
                break;
            case GameController.State.FloatingResult:                
                if (playing == true)
                {
                    // TODO: probably temp, different games will depend on when they're over
                    // I might end up moving when the game is over to the game itself
                    if (gc.result == 0)
                        lives--;
                    wins += gc.result;

                    livesText.text = "Lives: " + lives;
                    winsText.text = "Wins: " + wins;

                    timer = 3; 
                    playing = false;
                    gc.activateGame = false;
                }
                if (timer > 0)
                    timer -= Time.deltaTime;
                else
                {
                    SceneManager.SetActiveScene(endlessMode);
                    endlessUI.enabled = true;
                    endlessCam.enabled = true;

                    gc.state = GameController.State.UnloadingGame;
                    //StartCoroutine(gc.UnloadGame());
                    timer = 3;
                    PickGame();
                }
                break;
        }
    }
}
