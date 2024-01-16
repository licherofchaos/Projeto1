using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int hpStart;
    public static int Energy;
    public static int Hp;
    public static int Shield;
    public static int Mana;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    public static int Gold;
    public static int DmgBonus;
    public static int Weak;
    public static int Frail;
    public int StrengthBuff;
    public static int Poison;
    public static int Burn;
    public static bool UPPoison;
    public healthbar healthBar;
    public Text CurGold;
    public static int Count = 0;
    public static bool relic1 = false;
    private bool hasCodeExecuted1 = false;
    // Start is called before the first frame update
    void Start()
    {
        Hp = hpStart;
        
        int bonus = Mathf.Max(Dexterity, Strength, Intelligence);
        DmgBonus = bonus;
        AwakeInitialization();
        Poison = 0;
        Burn = 0;
        UPPoison = false;

    }
    void AwakeInitialization()
    {
        healthBar = GameObject.FindWithTag("Health Bar")?.GetComponent<healthbar>();
        healthBar.SetMaxHealth(hpStart);
        if (relic1 && hasCodeExecuted1)
        {
            RemoveStrength(3);
        }
        hasCodeExecuted1 = false;
    }
        
    void Update()
    {
        healthBar = GameObject.FindWithTag("Health Bar")?.GetComponent<healthbar>();
        CurGold = GameObject.Find("CurGold")?.GetComponent<Text>();
        CurGold.text = Gold.ToString() + "€";
       
        Mana = Intelligence * 2;
        healthBar.SetHealth(Hp);
        if (Hp <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("CharacterSelect");
        }
        if (relic1 == true)
        {
            Relic1();
        }
 
    }
    public static void PlayerEndTurn()
    {

        if (Burn > 0)
        {
            Hp -= Burn;
            Burn--;
        }
        if (UPPoison && Poison > 0)
        {
            Hp -= UnityEngine.Mathf.FloorToInt(Hp * 0.05f);
            Poison--;
        }
        else if (Poison > 0)
        {
            Hp -= UnityEngine.Mathf.FloorToInt(Hp * 0.02f);
            Poison--;
        }
    }
    public int CalculateDmgBonus()
    {
        return Mathf.Max(Dexterity, Strength, Intelligence);
    }

    public void Relic1()
    {

        if (!hasCodeExecuted1 && Hp <= (hpStart/2))
        {
            AddStrength(3);
        }
    }
    // Method to add value to Strength
    public void AddStrength(int value)
    {
        Strength += value;
        DmgBonus = CalculateDmgBonus();
    }

    // Method to remove value from Strength
    public void RemoveStrength(int value)
    {
        Strength = Mathf.Max(0, Strength - value); // Ensure Strength doesn't go below base value
        DmgBonus = CalculateDmgBonus();
    }

    // Similar methods for Intelligence and Dexterity
    public void AddIntelligence(int value)
    {
        Intelligence += value;
        Mana = Intelligence * 2;
        DmgBonus = CalculateDmgBonus();
    }

    public void RemoveIntelligence(int value)
    {
        Intelligence = Mathf.Max(0, Intelligence - value); // Ensure Intelligence doesn't go below base value
        Mana = Intelligence * 2;
        DmgBonus = CalculateDmgBonus();
    }

    public void AddDexterity(int value)
    {
        Dexterity += value;
        DmgBonus = CalculateDmgBonus();
    }

    public void RemoveDexterity(int value)
    {
        Dexterity = Mathf.Max(0, Dexterity - value); // Ensure Dexterity doesn't go below base value
        DmgBonus = CalculateDmgBonus();
    }
}