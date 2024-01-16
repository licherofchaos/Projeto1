using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoColorPicker : MonoBehaviour
{
    public void SetColor(Color newColor)
    {
        // Iterate through each child of the current GameObject
        foreach (Transform childTransform in transform)
        {
            // Assuming the child has a SpriteRenderer component
            SpriteRenderer childRenderer = childTransform.GetComponent<SpriteRenderer>();

            // Check if the child has a SpriteRenderer component
            if (childRenderer != null)
            {
                // Set the color of the SpriteRenderer's material
                childRenderer.material.color = newColor;

                // Log the new color to the console
                Debug.Log("New Color for " + childTransform.name + ": " + newColor);
            }
            else
            {
                Debug.LogWarning(childTransform.name + " does not have a SpriteRenderer component.");
            }
        }
    }
}
