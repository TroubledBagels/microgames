using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndlessTransition : MonoBehaviour
{
    private int showTime = 5;
    public TextMeshProUGUI livesLeft;
    public TextMeshProUGUI wins;
    public GameObject gainLife;
    public EndlessModeDriver emd;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        emd = GameObject.Find("EndlessDriver").GetComponent<EndlessModeDriver>();

        livesLeft.text = "Lives Left: " + emd.lives;
        wins.text = "Wins: " + emd.wins;
        if (emd.wins % 10 == 0 && emd.wins != 0) {
            gainLife.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= showTime) {
            emd.Next();
        }
    }
}
