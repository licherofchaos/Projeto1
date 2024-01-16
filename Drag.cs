using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool isDragging = false;
    public static bool isPlayable = false;
    public static bool reset = false;
    private Vector3 offset;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition + offset;
        }

        if (reset)
        {
            ResetCard();
        }
    }

    public void StartDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - mousePosition;

        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;

        // Raycast to check if the card is over a drop zone
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("DropZone") && PlayerStats.Energy > 0)
            {
                isPlayable = true;
            }
            else if (!hit.collider.CompareTag("DropZone"))
            {
                reset = true;
                isPlayable = false;
            }
        }
        else
        {
            reset = true;
            isPlayable = false;
        }
    }

    private void ResetCard()
    {
        transform.position = startPosition;
        reset = false;
    }
}