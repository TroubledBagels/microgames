using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionText : MonoBehaviour
{
    public Canvas canvas;
    public TMP_Text textComponent;
    private float timer = 0;
    private Microcontroller mc;
    
    void Start() {
        mc = GameObject.Find("Microcontroller").GetComponent<Microcontroller>();
        textComponent.text = mc.instruction;
    }

    Vector3 Vectorised(float x) {
        return new Vector3(x,x,x);
    }

    void FixedUpdate()
    {
        /*textComponent.ForceMeshUpdate();
        var textInfo = textComponent.textInfo;

        for (int i = 0; i < textInfo.characterCount; ++i) {
            var charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible) {
                continue;
            }
            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;
            for (int j = 0; j < 4; ++j) {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 4f + orig.x * 0.02f) * 5f, 0);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; ++i) {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textComponent.UpdateGeometry(meshInfo.mesh, i);
        }*/

        timer += Time.fixedDeltaTime;

        if (timer <= 1/1.5f) {
            canvas.GetComponent<CanvasGroup>().alpha = EasingFunction.EaseInQuad(0, 1, timer*3f);
            textComponent.transform.localScale = Vectorised(EasingFunction.EaseInQuad(10, 1, timer*1.5f));
        }
        else if (timer >= 1.5) {
            canvas.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 3;
            if (canvas.GetComponent<CanvasGroup>().alpha <= 0) {
                Destroy(gameObject);
                mc.StartTimer();
            }
        }
    }
}
