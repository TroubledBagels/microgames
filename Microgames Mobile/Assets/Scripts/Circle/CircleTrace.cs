using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTrace : MonoBehaviour
{
    public LineRenderer lineRenderer;
    [Range(6,60)]
    public int lineCount;
    public float radius;
    void Start()
    {
        lineRenderer.loop = true;
        lineRenderer.positionCount = lineCount;
        float theta = (2f * Mathf.PI) / lineCount;
        float angle = 0;
        for (int i = 0; i < lineCount; i++)
        {
            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);
            lineRenderer.SetPosition(i, new Vector3(x, y, -1));
            angle += theta;
        } 
    }
}
