using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldValue : MonoBehaviour
{
    public Card Cardv;
    public Relic Relicv;
    public Text Gvalue;
    public int GoldCost;
    public bool isRelicShop;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming Gvalue is a Text component on the same GameObject
        if (Cardv != null)
        {
            Gvalue.text = Cardv.Gvalue.ToString() + "€";
        }
        if (Relicv != null)
        {
            Gvalue.text = Relicv.Gvalue.ToString() + "€";
        }
        if (isRelicShop)
        {
            Gvalue.text = GoldCost.ToString() + "€";
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        // Your Update code, if needed
        if (isRelicShop)
        {
            Gvalue.text = GoldCost.ToString() + "€";
        }
    }
    public void ActivateRelic1()
    {
        if (PlayerStats.relic1 = false && PlayerStats.Gold >= GoldCost)
        {
            PlayerStats.relic1 = true;
            PlayerStats.Gold -= GoldCost;
        }
        
    }
}