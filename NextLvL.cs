using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLvL : MonoBehaviour
{
    // The name of the scene to load
    public string sceneToLoad;

    private void Start()
    {
        // Assuming you have a Button component on the GameObject
        Button button = GetComponent<Button>();

        // Add a listener to the button click event
        button.onClick.AddListener(LoadScene);
    }

    // Method to load the scene
    private void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}