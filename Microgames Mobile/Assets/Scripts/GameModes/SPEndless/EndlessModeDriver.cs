using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessModeDriver : MonoBehaviour
{
    public int totalGames;
    public Queue<int> prevGames = new Queue<int>();
    public GameController gc;
    public int lives = 3;
    public int timecode;
    public int playedGames = 0;
    public int wins = 0;
    private float timer = 0;
    private bool transitionLoaded = false;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
        gc.state = GameController.State.AwaitingCode;
    }

    // Update is called once per frame
    void Update()
    {
        if (gc.state == GameController.State.AwaitingCode) {
            int rng = Random.Range(1, totalGames + 1);
            while (prevGames.Contains(rng)) {
                rng = Random.Range(1, totalGames + 1);
            }
            prevGames.Enqueue(rng);
            if (prevGames.Count > totalGames / 2) {
                prevGames.Dequeue();
            }
            foreach (int i in prevGames) {
                Debug.Log(i);
            }

            gc.code = rng.ToString("000") + timecode.ToString("00") + lives.ToString("0");
        }

        if (gc.state == GameController.State.LoadingGame) {
            gc.code = "null";
        }

        if (gc.state == GameController.State.FloatingResult) {
            int result = gc.result; 
            if (timer < 5)
                timer += Time.deltaTime;

            if (timer >= 5) {
                gc.state = GameController.State.UnloadingGame;
                gc.result = 0;

                playedGames++;
                switch (result) {
                    case 0:
                        // lost
                        lives--;
                        break;
                    case 1:
                        // won
                        wins++;
                        break;
                    default:
                        break;
                }

                if (lives < 0) {
                    LoseGame();
                }

                if (wins % 10 == 0) {
                    lives++;
                }
                if (playedGames % 5 == 0) {
                    timecode = (int)(timecode * 0.95);
                }
                
            }
        }

        if (gc.state == GameController.State.UnloadingGame) {
            timer = 0;
        }

        if (gc.state == GameController.State.Transitioning && !transitionLoaded) {
            transitionLoaded = true;
            SceneManager.LoadScene("EndlessTransitionScreen", LoadSceneMode.Additive);
        }
    }

    public void Next() {
        gc.state = GameController.State.AwaitingCode;
        SceneManager.UnloadScene("EndlessTransitionScreen");
        transitionLoaded = false;
    }

    public void LoseGame() {

    }
}
