using UnityEngine;

public class Dish : MonoBehaviour
{
    private float x;
    private float y;

    public float sensitivity = 20.0f;
    private float washedness = 0;

    //private Gyroscope gyro;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;

        var meshRenderer = GetComponent<MeshRenderer>();
        Debug.Log(meshRenderer.additionalVertexStreams);
    }
    public void RotateUpDown(float axis)
    {
        transform.RotateAround(transform.position, transform.right, -axis * Time.deltaTime);
    }
    public void RotateRightLeft(float axis)
    {
        transform.RotateAround(transform.position, Vector3.up, -axis * Time.deltaTime);
    }

    public void Fade()
    {
        Mesh mesh = GetComponent<MeshRenderer>().additionalVertexStreams;
        Color[] colors = mesh.colors;

        for (int i = 0; i < colors.Length; i++)
        {
            if (colors[i] != Color.white)
            {
                colors[i] = Color.Lerp(colors[i], Color.white, 0.025f);
                washedness += 0.001f;

                if (washedness > 1)
                {
                    GameObject.Find("Microcontroller").GetComponent<Microcontroller>().GameBeaten();
                }
            }
        }
        
        // Assign the modified array back to the mesh
        mesh.colors = colors;
    }

    // Update is called once per frame
    void Update()
    {
        GyroRotation();
    }
    void GyroRotation()
    {
        x = Input.gyro.rotationRateUnbiased.x;
        y = Input.gyro.rotationRateUnbiased.y;

        float xFiltered = FilterGyroValues(x);
        RotateUpDown(xFiltered * sensitivity);

        float yFiltered = FilterGyroValues(y);
        RotateRightLeft(yFiltered * sensitivity);
    }

    float FilterGyroValues(float axis)
    {
        if (axis < -0.1 || axis > 0.1)
        {
            return axis;
        }
        else
        {
            return 0;
        }
    }
}
