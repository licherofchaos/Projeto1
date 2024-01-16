using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public Text playerhp;
    //public Text enemyHP;
    //public Enemy enemy;
    public Text energy;
    public Text shield;
    public Text Weak;
    public Text Frail;
    public Text Poison;
    public Text Burn;
    public GameObject PPoison;
    public Image Energy1;
    public Image Energy2;
    public Image Energy3;
    public Image Energy4;
    // Start is called before the first frame update
    void Start()
    {
        Poison.text = PlayerStats.Poison.ToString();
        Burn.text = PlayerStats.Burn.ToString();
        shield.text = PlayerStats.Shield.ToString();
       
        playerhp.text = PlayerStats.Hp.ToString();
        energy.text = PlayerStats.Energy.ToString();
        Frail.text = PlayerStats.Frail.ToString();
        Weak.text = PlayerStats.Weak.ToString();
        //enemyHP.text = Enemy.health.ToString() + "+" + Enemy.shield.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        Poison.text = PlayerStats.Poison.ToString();
        Burn.text = PlayerStats.Burn.ToString();
        if (PlayerStats.UPPoison && PlayerStats.Poison >= 0)
        {
            PPoison.SetActive(true);
        }
        else
        {
            PPoison.SetActive(false);
        }
        if (PlayerStats.Poison >= 0)
        {
            PPoison.SetActive(false);
        }
        shield.text = PlayerStats.Shield.ToString();
        playerhp.text = PlayerStats.Hp.ToString();
        Frail.text = PlayerStats.Frail.ToString();
        Weak.text = PlayerStats.Weak.ToString();
        //enemyHP.text = Enemy.health.ToString() + "+" + Enemy.shield.ToString();
        energy.text = PlayerStats.Energy.ToString();
        if (PlayerStats.Energy == 0)
        {
            Energy1.enabled = false;
            Energy2.enabled = false;
            Energy3.enabled = false;
            Energy4.enabled = false;
        }
        if (PlayerStats.Energy == 1)
        {
            Energy1.enabled = true;
            Energy2.enabled = false;
            Energy3.enabled = false;
            Energy4.enabled = false;
        }
        if (PlayerStats.Energy == 2)
        {
            Energy1.enabled = false;
            Energy2.enabled = true;
            Energy3.enabled = false;
            Energy4.enabled = false;
        }
        if (PlayerStats.Energy == 3)
        {
            Energy1.enabled = false;
            Energy2.enabled = false;
            Energy3.enabled = true;
            Energy4.enabled = false;
        }
        if (PlayerStats.Energy >= 4)
        {
            Energy1.enabled = false;
            Energy2.enabled = false;
            Energy3.enabled = false;
            Energy4.enabled = true;
        }

    }
    
}
