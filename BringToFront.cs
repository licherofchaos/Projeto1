using UnityEngine;
using UnityEngine.UI;

public class BringToFront : MonoBehaviour
{
    public GameObject CardArea;

    void Start()
    {
        // Set the CardArea to the top of the rendering order
        BringCardAreaToFront();
    }

    void BringCardAreaToFront()
    {
        // Get the sibling index of the CardArea
        int cardAreaIndex = CardArea.transform.GetSiblingIndex();

        // Set the CardArea to the top by setting its sibling index to the highest
        CardArea.transform.SetSiblingIndex(cardAreaIndex + 1);
    }
}