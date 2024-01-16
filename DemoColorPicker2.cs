using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoColorPicker2 : MonoBehaviour
{


    public void SetColorForDescendants(Color newColor)
    {
        // Recursively iterate through all descendants of the current GameObject
        SetColorRecursive(transform, newColor);
    }

    private void SetColorRecursive(Transform currentTransform, Color color)
    {
        // Iterate through each child of the current Transform
        foreach (Transform childTransform in currentTransform)
        {
            // Assuming the child has a SpriteRenderer component
            SpriteRenderer childRenderer = childTransform.GetComponent<SpriteRenderer>();

            // Check if the child has a SpriteRenderer component
            if (childRenderer != null)
            {
                // Set the color of the SpriteRenderer's material
                childRenderer.material.color = color;

                // Log the new color to the console
                Debug.Log("New Color for " + childTransform.name + ": " + color);
            }
            else
            {
                Debug.LogWarning(childTransform.name + " does not have a SpriteRenderer component.");
            }

            // Recursively call this method for each child to process their descendants
            SetColorRecursive(childTransform, color);
        }
    }
}