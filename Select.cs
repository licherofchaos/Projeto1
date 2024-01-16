using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select : MonoBehaviour
{
    public Color highlightColor = Color.red;
    private Color originalColor;
    public bool isSelected = false;
    public Image imageComponent;
    
    void Start()
    {
        imageComponent = GetComponent<Image>();
        if (imageComponent == null)
        {
            Debug.LogError("Image component not found on " + gameObject.name);
        }
    }
    void Update()
    {
   
            //if (Input.GetMouseButtonDown(0))
            //{
            //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            //    if (hit.collider != null && hit.collider.gameObject == gameObject)
            //    {
            //        Debug.Log("Mouse Clicked on: " + gameObject.name);

            //        if (!isSelected)
            //        {
            //            SelectObject();
            //        }
            //        else
            //        {
            //            DeselectObject();
            //        }
            //    }
            //}


    }
    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            Debug.Log("Mouse Clicked on: " + gameObject.name);

            if (!isSelected)
            {
                SelectObject();
            }
            else
            {
                DeselectObject();
            }
        }
    }

    void SelectObject()
    {

        originalColor = imageComponent.color;
        imageComponent.color = highlightColor;
        isSelected = true;
        PlayerStats.Count = 1;
        Debug.Log("Selected: " + gameObject.name);
    }
    public bool Check()
    {
        if (isSelected)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void DeselectObject()
    {
        imageComponent.color = originalColor;
        isSelected = false;
        PlayerStats.Count = 0;
        Debug.Log("Deselected: " + gameObject.name);
    }

    public Enemy GetEnemy()
    {
        if (isSelected)
        {
            // Get the Enemy component from the current GameObject
            Enemy enemyComponent = GetComponent<Enemy>();

            // Return the Enemy component if found
            if (enemyComponent != null)
            {
                return enemyComponent;
            }
        }

        // Return null if not selected or if the Enemy component is not found
        return null;
    }
}