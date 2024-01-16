using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    private PlayerStats playerStats;
    public bool UpSTR = false;
    public bool UpINT = false;
    public bool UpDEX = false;
    public bool DownSTR = false;
    public bool DownINT = false;
    public bool DownDEX = false;
    public bool addgold = false;
    public bool removegold = false;
    public bool Heal = false;


    // Start is called before the first frame update
    void Start()
    {

        // Assuming the Draw script is attached to a GameObject with the "Draw" tag
        GameObject dontDestroyObject = GameObject.FindGameObjectWithTag("Player");

        if (dontDestroyObject != null)
        {

            playerStats = dontDestroyObject.GetComponent<PlayerStats>();
        }


        // Check if the Draw script is found
        if (playerStats == null)
        {
            Debug.LogError("Draw script not found in the scene or in the DontDestroyOnLoad object.");
        }
    }

    // Method to handle button click and trigger the Draw script's OnClick function
    public void HandleButtonClick()
    {
        if (playerStats != null)
        {
            if (UpSTR)
            {
                playerStats.AddStrength(1);
            }
            if (UpINT)
            {
                playerStats.AddIntelligence(1);
            }
            if (UpDEX)
            {
                playerStats.AddDexterity(1);
            }
            if (DownSTR)
            {
                playerStats.RemoveStrength(1);
            }
            if (DownINT)
            {
                playerStats.RemoveIntelligence(1);
            }
            if (DownDEX)
            {
                playerStats.RemoveDexterity(1);
            }
            if (addgold)
            {
                PlayerStats.Gold += 100;
            }
            if (removegold)
            {
                PlayerStats.Gold -= 50;
            }
            if (Heal)
            {
                PlayerStats.Hp += 20;
            }
            // Call the OnClick function in the Draw script

        }
        else
        {
            Debug.LogError("Draw script not found. Make sure the Draw script is in the scene or in the DontDestroyOnLoad object.");
        }
    }
}