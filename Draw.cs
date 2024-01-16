using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Draw : MonoBehaviour
{
    
    public GameObject CardArea;
    public int MaxHandCount;
    public int baseEnergy;
    public int ManaRegen;
    public int fullMana;
    public int CurrentHandSize = 0;
    public Enemy enemy;
    public string targetTag = "Card";
    public string targetTag1 = "enemy";
    //public string LVL2_1;
    //public string LVL2_2;
    //public string LVL2_3;
    //public string LVL3_1;
    //public string LVL3_2;
    //public string LVL3_3;
    public List<GameObject> Startdeck = new List<GameObject>();
    public static List<GameObject> deck = new List<GameObject>();
    public static List<GameObject> discardPile = new List<GameObject>();
    public int CurrentLvl = 0;
    public bool addPoison = false;
    public Text DeckText;
    public Text DiscardText;
    public bool Boss = false;
    public bool Elite = false;
    private static List<GameObject> instantiatedCards = new List<GameObject>();
    public Transform StartinactiveArea;
    public static Transform inactiveArea;
    public static Draw Instance;
    
    void Start()
    {
        
        AwakeInitialization();
    }
    

    void Awake()
    {
        Instance = this;
        deck = new List<GameObject>(Startdeck);
    }
    void AwakeInitialization()
    {
        discardPile = new List<GameObject>();

        //// Check if Startdeck is already initialized
        //if (Startdeck == null || Startdeck.Count == 0)
        //{
        //    // Try to find the StarterDeck object in the scene by tag
        //    GameObject starterDeckObject = GameObject.FindGameObjectWithTag("Player");

        //    // Get the Draw component from the StarterDeck object
        //    Draw starterDeck = starterDeckObject?.GetComponent<Draw>();

        //    // Check if the StarterDeck component is found
        //    if (starterDeck != null)
        //    {
        //        // Use the Startdeck from the found StarterDeck component
        //        Startdeck = Draw.Startdeck;
        //    }
        //    else
        //    {
        //        Debug.Log("StarterDeck not found. Make sure there is an object tagged as 'Player' in the scene.");
        //        // Fallback: Use the manually assigned Startdeck
        //        Startdeck = Draw.Startdeck;
        //    }
        //}
        
    }

    void Update()
    {
        GameObject inactiveAreaObject = GameObject.FindGameObjectWithTag("InactiveArea");
        inactiveArea = inactiveAreaObject?.transform;

        
        CardArea = GameObject.FindGameObjectWithTag("CardArea");

        
        DeckText = GameObject.Find("DeckText")?.GetComponent<Text>();
        DiscardText = GameObject.Find("DiscardText")?.GetComponent<Text>();
        Debug.Log("Deck count after shuffle: " + deck.Count);
        Debug.Log("StartDeck count after shuffle: " + Startdeck.Count);
        Debug.Log("Discard pile count after shuffle: " + discardPile.Count);    
        DeckText.text = deck.Count.ToString();
        DiscardText.text = discardPile.Count.ToString();      
        Debug.Log(CurrentHandSize);
        if (deck.Count <= 0)
        {
            Shuffle();
        }
    }
    public void AddCardToStarterDeck(GameObject card)
    {
        Startdeck.Add(card);
    }
    public void OnClick()
    {
        CurrentHandSize = 0;

        
        

        GameObject[] enemiesWithTag = GameObject.FindGameObjectsWithTag(targetTag1);
        foreach (GameObject enemyObject in enemiesWithTag)
        {
            Enemy enemyScript = enemyObject.GetComponent<Enemy>();

            if (enemyScript != null)
            {
                if (enemyScript.boss == true)
                {
                    Boss = true;
                }
                if (enemyScript.elite == true)
                {
                    Elite = true;
                }
                enemyScript.ResetShield();
                enemyScript.Action();
                enemyScript.NewTurn();
            }
        }
        DeleteObjectsWithTag(targetTag);
        DrawCards(4);
        
        PlayerStats.Mana += ManaRegen;
        PlayerStats.Energy = baseEnergy;
        PlayerStats.Shield = 0;
        if (enemiesWithTag.Length <= 0)
        {
            NextLvl();
        }
        PlayerStats.PlayerEndTurn();
    }

    void DeleteObjectsWithTag(string tag)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsWithTag)
        {
            DiscardCard(obj);
        }
    }

    public void DrawCards(int value)
    {
        for (int i = 0; i < value; i++)
        {
            if (CurrentHandSize < MaxHandCount)
            {
                if (deck.Count <= 0)
                {
                    Shuffle();
                    if (deck.Count <= 0)
                    {
                        Debug.LogWarning("Deck is empty after shuffling.");
                        AwakeInitialization();
                        return;
                    }
                }

                int randomIndex = Random.Range(0, deck.Count);
                GameObject playerCard = Instantiate(deck[randomIndex], new Vector3(0, 0, 0), Quaternion.identity);
                playerCard.SetActive(true);
                if (playerCard != null)
                {
                    // Your code here
                    playerCard.SetActive(true);
                    instantiatedCards.Add(playerCard);

                    playerCard.transform.SetParent(CardArea.transform, false);
                    CurrentHandSize++;

                    if (discardPile.Contains(deck[randomIndex]))
                    {
                        discardPile.Remove(deck[randomIndex]);
                    }
                    deck.RemoveAt(randomIndex);

                    if (deck.Count <= 0)
                    {
                        Shuffle();
                    }
                }
                else
                {
                    Debug.LogWarning("Instantiated card is null. This might happen if the original prefab is missing.");
                }
            }
        }
    }


    void Shuffle()
    {
        deck.Clear();
        foreach (GameObject card in discardPile)
        {
            deck.Add(card);
        }
        discardPile = new List<GameObject>();

        Debug.Log("Deck count after shuffle: " + deck.Count);
        Debug.Log("Discard pile count after shuffle: " + discardPile.Count);
    }

    public void DiscardCard(GameObject card)
    {
        discardPile.Add(card);
        deck.Remove(card);

        // Remove the card from the instantiatedCards list
        instantiatedCards.Remove(card);

        // Move the card to the inactive area
        if (card != null && inactiveArea != null)
        {
            card.transform.SetParent(inactiveArea, false);
            card.SetActive(false);
        }
    }


    IEnumerator DelayedDestroy(GameObject obj)
    {
        // Wait until the end of the frame before destroying the object
        yield return new WaitForEndOfFrame();

        // Check if the object still exists before adding it to discardPile
        if (obj != null)
        {
            // Optionally, you can destroy the card object here if needed
            Destroy(obj);
        }
    }

    
    public void NextLvl()
    {
        if (Boss == true)
        {
            SceneManager.LoadScene("WinScreen");
        }
        if (Boss == false && Elite == true)
        {
            SceneManager.LoadScene("RewardScreenRelic");
        }
        else
        {
            SceneManager.LoadScene("RewardScreen");
        }     
    }
    float Choose(float[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
    public void DrawAssist(int draw)
    {
        int n = draw;
        DrawCards(n);
    }

}
