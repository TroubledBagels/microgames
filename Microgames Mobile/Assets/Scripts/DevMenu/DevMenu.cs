using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class RuntimeButtonExample : MonoBehaviour
{
    public UIDocument uiDocument;

    public int buttonCount = 10;
    private void OnEnable()
    {
        VisualElement root = uiDocument.rootVisualElement;
        VisualElement scrollview = root.Query<ScrollView>("scroll").First();

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            int index = i;
           
            Button button = new Button();

            string path = SceneUtility.GetScenePathByBuildIndex(i);
            button.text = System.IO.Path.GetFileNameWithoutExtension(path);
            button.AddToClassList("button");

            // Add the button to the scroll view
            scrollview.Add(button);
                
            // Add a click event handler to the button
            
            button.clickable.clicked += () =>
            {
                SceneManager.LoadScene("AppMain");
                SceneManager.LoadScene(path, LoadSceneMode.Additive);
                Scene scene = SceneManager.GetSceneByPath(path);
                SceneManager.SetActiveScene(scene);
                SceneManager.UnloadSceneAsync("DevMenu");
            };
        }
    }
}
