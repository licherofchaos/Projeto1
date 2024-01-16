using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject popupImagePrefab; // Reference to the image prefab
    private GameObject popupImageInstance;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Instantiate the popup image when the pointer enters
        popupImagePrefab.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Destroy the popup image when the pointer exits
        popupImagePrefab.SetActive(false);
    }
}