using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PerspectiveSwitcher : MonoBehaviour
{
    private Matrix4x4   ortho,
                        perspective;
    private float        fov     = 30f,
                        near    = .3f,
                        far     = 15f,
                        orthographicSize = 1.48f;
    private float       aspect;
    private MatrixBlender blender;
    private bool        orthoOn;
 
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("001"));

        aspect = (float) Screen.width / (float) Screen.height;
        ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, near, far);
        perspective = Matrix4x4.Perspective(fov, aspect, near, far);
        GetComponent<Camera>().projectionMatrix = ortho;
        orthoOn = true;
        blender = GetComponent<MatrixBlender>();
    }

    public void SwitchPerspective() 
    {
        orthoOn = !orthoOn;
        if (orthoOn)
            blender.BlendToMatrix(ortho, 0.1f);
        else
            blender.BlendToMatrix(perspective, 0.1f);    
    }
}