using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatGiver : MonoBehaviour
{
    public GameObject player;
    public PlayerStats StatsSheet;
    public int Points;
    public int Str;
    public int Int;
    public int Dex;
    public Text PointsT;
    public Text StrT;
    public Text IntT;
    public Text DexT;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StatsSheet = player.GetComponent<PlayerStats>();
       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
    void UpdateUI()
    {
        // Update the UI text with the current Strength value
        PointsT.text = "Points To Spend: " + Points.ToString();
        StrT.text = "Strength: " + StatsSheet.Strength.ToString();
        IntT.text = "Intelligence: " + StatsSheet.Intelligence.ToString();
        DexT.text = "Dexterity: " + StatsSheet.Dexterity.ToString();
    }

    public void IntUp()
    {
        if (Points > 0)
        {
            StatsSheet.AddIntelligence(1);
            UpdateUI();
            Points--;
        }       
    }
    public void IntDown()
    {
        if (StatsSheet.Intelligence > 0)
        {
            StatsSheet.RemoveIntelligence(1);
            UpdateUI();
            Points++;
        }     
    }
    public void StrUp()
    {
        if (Points > 0)
        {
            StatsSheet.AddStrength(1);
            UpdateUI();
            Points--;
        }
    }
    public void StrDown()
    {
        if (StatsSheet.Strength > 0)
        {
            StatsSheet.RemoveStrength(1);
            UpdateUI();
            Points++;
        }
    }
    public void DexUp()
    {
        if (Points > 0)
        {
            StatsSheet.AddDexterity(1);
            UpdateUI();
            Points--;
        }
    }
    public void DexDown()
    {
        if (StatsSheet.Dexterity > 0)
        {
            StatsSheet.RemoveDexterity(1);
            UpdateUI();
            Points++;
        }
    }

}
