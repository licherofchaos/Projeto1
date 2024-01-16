using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic : MonoBehaviour
{
    public int Gvalue;
    public GameObject player;
    public PlayerStats StatsSheet;
    public List<GameObject> Relics = new List<GameObject>();
    public GameObject RelicArea;
    public bool isRelic1 = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StatsSheet = player.GetComponent<PlayerStats>();
    }
    void Update()
    {
        if (PlayerStats.relic1 == true)
        {
            if (isRelic1 == false)
            {
                InstantiateAndSetParent(0);
                isRelic1 = true;
            }
            
        }
    }
    void InstantiateAndSetParent(int randomIndex)
    {
        GameObject playerCard = Instantiate(Relics[randomIndex], new Vector3(0, 0, 0), Quaternion.identity);
        playerCard.transform.SetParent(RelicArea.transform, false);
    }
    public void Relic1()
    {
        PlayerStats.relic1 = true;
    }
    public void IntUp()
    {
      
     
            StatsSheet.AddIntelligence(1);
        
    }
    public void IntDown()
    {
   
            StatsSheet.RemoveIntelligence(1);
        
    }
    public void StrUp()
    {
       
            StatsSheet.AddStrength(1);
        
    }
    public void StrDown()
    {
       
            StatsSheet.RemoveStrength(1);
        
    }
    public void DexUp()
    {
            StatsSheet.AddDexterity(1);
        
    }
    public void DexDown()
    {
        
            StatsSheet.RemoveDexterity(1);
        
    }
}
