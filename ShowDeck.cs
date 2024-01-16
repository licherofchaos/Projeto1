using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDeck : MonoBehaviour
{
    public GameObject CardArea;
    private Draw drawScript;



    void Start()
    {
        // Find the Draw script at the start
        
        FindDrawScript();

    }

    void Update()
    {
        // Per-frame updates, if needed
    }

    void FindDrawScript()
    {

        GameObject dontDestroyObject = GameObject.FindGameObjectWithTag("Player");
        if (dontDestroyObject != null)
        {

            drawScript = dontDestroyObject.GetComponent<Draw>();
        }

        if (drawScript != null)
        {
            // If the Draw script is found, call the method to show the deck
            ShowDeckCards(Draw.deck);
        }
        else
        {
            Debug.LogError("Draw script not found in the scene.");
        }
    }

    public void ShowDeckCards(List<GameObject> showdeck)
    {
        // Clear existing cards in the CardArea
        ClearCardArea();

        foreach (GameObject cardPrefab in showdeck)
        {
            // Check if the cardPrefab is not null before instantiating
            if (cardPrefab != null)
            {
                GameObject playerCard = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                playerCard.transform.SetParent(CardArea.transform, false);
            }
            else
            {
                Debug.LogWarning("Card prefab is null. Make sure it's not destroyed elsewhere.");
            }
        }
    }

    void ClearCardArea()
    {
        // Destroy all child objects (cards) in the CardArea
        foreach (Transform child in CardArea.transform)
        {
            Destroy(child.gameObject);
        }
    }
}