using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count5Controller : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public TextMeshProUGUI label1;
    public TextMeshProUGUI label2;
    public TextMeshProUGUI label3;
    public TextMeshProUGUI label4;
    public TextMeshProUGUI label5;
    public List<GameObject> pressedButtons;
    public List<GameObject> order;
    public List<TextMeshProUGUI> labelOrder;
    public List<int> allNums = new List<int> {1, 2, 3, 4, 5};
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++) {
            int rng = Random.Range(0, allNums.Count);
            order.Add(GameObject.Find("Button" + allNums[rng]));
            labelOrder.Add(GameObject.Find("B" + allNums[rng] + "Label").GetComponent<TextMeshProUGUI>());
            allNums.RemoveAt(rng);
        }

        for (int i = 1; i <= 5; i++) {
            labelOrder[i - 1].text = i.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Controls.GetTouchDown()) {
            GameObject go = Controls.GetTouchObject3D(Input.touches[0]);
            if (go == order[0]) {
                go.GetComponent<Count5Button>().Sink();
                pressedButtons.Add(go);
                order.RemoveAt(0);
                labelOrder.RemoveAt(0);
                if (order.Count == 0) {
                    GameObject.Find("Microcontroller").GetComponent<Microcontroller>().GameBeaten();
                }
            }
        }
    }
}
