using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum State {
        AwaitingCode,
        LoadingGame,
        PlayingGame,
        UnloadingGame,
        FloatingResult,
        Transitioning
    }

    public State state = State.AwaitingCode;
    public string code = "null";
    public int gameNum = -1;
    public string path = "";
    public int speed = 10;
    public int result = -1;
    public int endTime;
    public bool activateGame = false;
    
    // Start is called before the first frame update
    void Start()
    {
        //Application.targetFrameRate = -1;
        //if (SceneManager.GetActiveScene().name == "AppMain") {
        //    SceneManager.LoadScene("DevMenu", LoadSceneMode.Additive);  
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case State.AwaitingCode:
                AwaitCode();
                break;
            case State.LoadingGame:
                break;
            case State.PlayingGame:
                break;
            case State.UnloadingGame:
                StartCoroutine(UnloadGame());
                break;
            case State.FloatingResult:
                FloatResult();
                break;
        }
    }

    void AwaitCode() {
        // check for code
        if (code != "null") {
            state = State.LoadingGame;
            Debug.Log(code);
            gameNum = int.Parse(code.Substring(0, 3));
            speed = int.Parse(code.Substring(3, 2));
            int lives = int.Parse(code.Substring(5, 1));
            StartCoroutine(LoadGame(gameNum));
        }
    }

    public int FetchTimer() {
        return endTime;
    }

    private IEnumerator LoadGame(int gN) {
        // wait for a frame before loading
        yield return null; 
        
        result = -1;
        path = SceneUtility.GetScenePathByBuildIndex(gN);

        Debug.Log("this has happened now");
        AsyncOperation op = SceneManager.LoadSceneAsync(path, LoadSceneMode.Additive);
        op.allowSceneActivation = false;

        //float time = (Int32.Parse(timecode) / 100) * GameInfo.GetTime(Int32.Parse(gN));
        //if (timecode == "00") time = GameInfo.GetTime(Int32.Parse(gN));
        //endTime = Mathf.CeilToInt(time);
        //gameNum = gN;

        while (!op.isDone)
        {
            // Check if the load has finished
            if (op.progress >= 0.9f && activateGame)
            {
                op.allowSceneActivation = true;
            }
            yield return null;
        }

        if (op.isDone)
        {
            this.gameNum = gN;
            state = State.PlayingGame;
            var scene = SceneManager.GetSceneByPath(path);
            SceneManager.SetActiveScene(scene);
        }
    }

    private IEnumerator UnloadGame() {
        state = State.AwaitingCode;
        yield return null; // wait for a frame before unloading
        AsyncOperation op = SceneManager.UnloadSceneAsync(path);

        while (!op.isDone)
        {
            yield return null;
        }

        if (op.isDone)
        {
            Resources.UnloadUnusedAssets();
        }
    }

    void FloatResult() {
        // floats back the result
    }
}
