using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    // Reference to the Draw script
    private Draw drawScript;

    // Start is called before the first frame update
    void Start()
    {

            // Assuming the Draw script is attached to a GameObject with the "Draw" tag
            GameObject dontDestroyObject = GameObject.FindGameObjectWithTag("Player");

            if (dontDestroyObject != null)
            {

            drawScript = dontDestroyObject.GetComponent<Draw>();
            }
        

        // Check if the Draw script is found
        if (drawScript == null)
        {
            Debug.LogError("Draw script not found in the scene or in the DontDestroyOnLoad object.");
        }
    }

    // Method to handle button click and trigger the Draw script's OnClick function
    public void HandleButtonClick()
    {
        if (drawScript != null)
        {

            // Call the OnClick function in the Draw script
            drawScript.OnClick();
        }
        else
        {
            Debug.LogError("Draw script not found. Make sure the Draw script is in the scene or in the DontDestroyOnLoad object.");
        }
    }
}