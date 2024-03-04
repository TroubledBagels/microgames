using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject accuracyCounter;
    List<Vector2> points;
    GameController gc;
    private bool calculated = false;
    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (calculated) return;
        if (gc.state == GameController.State.FloatingResult) {
            var aC = Instantiate(accuracyCounter);
            aC.transform.parent = GameObject.Find("Circle").transform;
            GameObject.Find("AccuracyCounter").GetComponent<AccuracyCounter>().accuracy = CalculateAccuracy(); 
            calculated = true;
        }
    }

    public bool CircleClosed() {
        int positionCount = points.Count;
        float angleTolerance = 10f;
        float totalAngle = 0f;
        Vector2 center = new Vector2(0, 0);

        for (int i = 0; i < positionCount - 1; i++)
        {
            // Get the current and next positions of the line
            Vector2 currentPosition = points[i];
            Vector2 nextPosition = points[i + 1];

            // Calculate the vectors from the center to the current and next positions
            Vector2 currentVector = currentPosition - center;
            Vector2 nextVector = nextPosition - center;

            // Calculate the angle between the two vectors in degrees
            float angle = Vector3.Angle(currentVector, nextVector);

            // Add the angle to the total angle
            totalAngle += angle;
        }

        // Check if the total angle is approximately equal to 360 degrees within the tolerance
        return totalAngle > 350f;
    }

    float CalculateAccuracy() 
    {
        float totalDeviation = 0;
        float perimeter = 0;
        int count = points.Count;

        
        if (!CircleClosed()) {
            Debug.Log("Circle not closed");
            return 0;
        }
        
        for (int i = 0; i < count - 1; i++)
        {
            Vector2 current = points[i];
            Vector2 next = points[i + 1];

            perimeter += Vector2.Distance(current, next); 
        }   

        float circumference = 2 * Mathf.PI * 4;
        float perimeterDeviation = Mathf.Abs((perimeter - circumference) / circumference);

        for (int i = 0; i < points.Count; ++i) {
            float measuredRadius = points[i].x * points[i].x + points[i].y * points[i].y;
            float trueRadius = 16;
            float deviation = Mathf.Abs((measuredRadius - trueRadius) / trueRadius);
            totalDeviation += deviation;
        }
        float meanDeviation = (totalDeviation + perimeterDeviation) / (points.Count + 1);
        float percentageDeviation = meanDeviation * 100;

        return 100 - percentageDeviation;
    }

    public void UpdateLine(Vector2 position) 
    {
        if (points == null) {
            points = new List<Vector2>();
            SetPoint(position);
            return;
        }

        if (Vector2.Distance(points.Last(), position) > .1f) 
        {
            SetPoint(position);
        }

    }

    void SetPoint(Vector2 point) 
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }
}
