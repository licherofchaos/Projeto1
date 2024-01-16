using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public List<GameObject> Cards = new List<GameObject>();
    public GameObject CardArea;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
    public void RandomReward()
    {
        // Create a list of indices
        List<int> indices = new List<int>();
        for (int i = 0; i < Cards.Count; i++)
        {
            indices.Add(i);
        }

        // Shuffle the list of indices
        ShuffleList(indices);

        // Take the first three indices
        int randomIndex0 = indices[0];
        int randomIndex1 = indices[1];
        int randomIndex2 = indices[2];

        // Instantiate and set the parent for each card
        InstantiateAndSetParent(randomIndex0);
        InstantiateAndSetParent(randomIndex1);
        InstantiateAndSetParent(randomIndex2);
    }

    // Helper method to shuffle a list of integers
    void ShuffleList(List<int> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    // Helper method to instantiate and set parent for a card
    void InstantiateAndSetParent(int randomIndex)
    {
        GameObject playerCard = Instantiate(Cards[randomIndex], new Vector3(0, 0, 0), Quaternion.identity);
        playerCard.transform.SetParent(CardArea.transform, false);
    }

}
