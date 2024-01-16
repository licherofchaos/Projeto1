using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SeeBoxCollider : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Select selectScript;

    private void OnDrawGizmos()
    {
        if (boxCollider == null)
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        if (selectScript == null)
        {
            selectScript = GetComponent<Select>();
        }

        if (boxCollider != null && selectScript != null && selectScript.isSelected)
        {
            Gizmos.color = Color.green; // Set the color of the wireframe

            // Calculate the center and size based on the Box Collider properties
            Vector2 center = boxCollider.offset;
            Vector2 size = boxCollider.size;

            // Convert center and size to world space, considering rotation
            Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
            Vector3 worldCenter = rotationMatrix.MultiplyPoint(center);
            Vector3 worldSize = rotationMatrix.MultiplyVector(size);

            // Draw the wireframe box
            Gizmos.DrawWireCube(worldCenter, worldSize);
        }
    }
}