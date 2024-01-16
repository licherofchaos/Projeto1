using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;
    [SerializeField] private int layerToSet = 20;
    private Card card;
    private GameObject zoomCard;
    private RectTransform zoomRect;
    private RectTransform canvasRect;

    private void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
        zoomRect = zoomCard?.GetComponent<RectTransform>();
        canvasRect = Canvas?.GetComponent<RectTransform>();
        card = GetComponent<Card>();
    }
    void Update()
    {
        if (card.destroy == true)
        {
            Destroy(zoomCard);
            zoomCard = null;
        }
    }
    public void OnHoverEnter()
    {
        // Instantiate the zoomed card if it doesn't exist
        if (zoomCard == null)
        {
            zoomCard = Instantiate(gameObject, Vector2.zero, Quaternion.identity);
            zoomCard.transform.SetParent(Canvas.transform, false);
            zoomCard.layer = layerToSet;

            zoomRect = zoomCard.GetComponent<RectTransform>();
            canvasRect = Canvas.GetComponent<RectTransform>();

            // Set the initial size
            zoomRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);
            zoomRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70);
        }

        // Set the position based on the mouse pointer with an offset
        Vector2 mousePosition = Input.mousePosition;

        // Convert mouse position to canvas space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, mousePosition, null, out Vector2 localPoint);

        // Add an offset to make it appear above the mouse pointer
        float yOffset = 5f;
        localPoint.y += yOffset;

        zoomRect.localPosition = localPoint;

        // Show the zoomed card
        zoomCard.SetActive(true);
    }

    public void OnHoverExit()
    {
        // Hide the zoomed card
        if (zoomCard != null)
        {
            Destroy(zoomCard);
            zoomCard = null;
        }
    }
}