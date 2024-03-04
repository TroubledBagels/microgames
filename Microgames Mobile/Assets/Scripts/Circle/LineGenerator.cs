using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject line;
    private bool drawn = false;
    Line activeLine;

    // Update is called once per frame
    void Update()
    {
        if (!drawn && Input.GetMouseButtonDown(0)) {
            GameObject newLine = Instantiate(line);
            newLine.transform.SetParent(transform);
            activeLine = newLine.GetComponent<Line>();
        }   
        if (Input.GetMouseButtonUp(0)) {
            if (!activeLine.CircleClosed()) {
                Destroy(activeLine.gameObject);
            }
            else { 
                drawn = true;
            }
            activeLine = null;
        }
            
        if (activeLine != null) {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        } 
    }
}
