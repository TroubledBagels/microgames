using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallpitGenerator : MonoBehaviour
{
    public GameObject ball;
    public GameObject bear;
    public int width;
    public int depth;
    public int height;
    
    public Material red;
    public Material orange;
    public Material yellow;
    public Material green;
    public Material cyan;
    public Material blue;
    public Material magenta;

    void Start()
    {
        Material[] materials = {red, orange, yellow, green, cyan, blue, magenta};
        GameObject go = Instantiate(bear, new Vector3(Random.Range(-2.0f, 2.0f), -0.262f, Random.Range(-1.2f, 0.1f)), Random.rotation);
        go.transform.SetParent(transform);
        for (int y = 0; y < height; ++y) {
            for (int z = 0; z < depth; ++z) {
                for (int x = 0; x < width; ++x) {
                    var n_ball = Instantiate(ball, new Vector3(transform.position.x + x*0.2f + Random.Range(0, 0.1f), transform.position.y + y*0.2f + Random.Range(0, 0.1f), transform.position.z + z*0.3f + Random.Range(0, 0.1f)), Quaternion.identity);
                    n_ball.GetComponent<Renderer>().material = materials[Random.Range(0, 7)];
                    n_ball.transform.SetParent(transform);
                }   
            }
        }
    }
}