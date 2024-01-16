using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDeck : MonoBehaviour
{
    public GameObject CardPrefab;
    public GameObject Panel;
    public bool Shop;
    public Card CardValue;
    // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.FindGameObjectWithTag("Shop");
        CardValue = CardPrefab.GetComponent<Card>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Close()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
       
    }
    public void AddCardToStarterDeck()
    {
        if (Shop == false)
        {       
            // Assuming you have a reference to the Draw script
            Draw drawScript = FindObjectOfType<Draw>();

            if (drawScript != null)
            {
                // Instantiate the card or get it from somewhere
            

                // Call the function in the Draw script to add the card to the starter deck
                drawScript.AddCardToStarterDeck(CardPrefab);
            }
            else
            {
                Debug.LogError("Draw script not found.");
            }
        }
        else
        {
            if ((PlayerStats.Gold - CardValue.Gvalue) >= 0 )
            {
                PlayerStats.Gold -= CardValue.Gvalue;
                // Assuming you have a reference to the Draw script
                Draw drawScript = FindObjectOfType<Draw>();
                Debug.Log("gold:" + PlayerStats.Gold.ToString()); ;
                if (drawScript != null)
                {
                    // Instantiate the card or get it from somewhere


                    // Call the function in the Draw script to add the card to the starter deck
                    drawScript.AddCardToStarterDeck(CardPrefab);
                }
                else
                {
                    Debug.LogError("Draw script not found.");
                }
            }
            else
            {
                Debug.Log("Not enough gold");
            }
           
        }
    }
}
