using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("Card Settings")]
    [Tooltip("Efeitos que a carta pode fazer")]
    
    public int Damage;
    public int Shield;
    public int Mana;
    public int Weak;
    public int Frail;
    public int bonus;
    public int drawN;
    public int Poison;
    public int Burn;
    public int energy;
    public int Gvalue;
    [Header("Nr� maximo de inimigos que afeta")]
    public int Target;
    [Header("Cost")]
    public int Energy;
    [Header("other things")]
    public bool needTarget;
    public Enemy enemy;
    public bool selected;
    private GameObject[] enemies;
    public bool destroy;
    public GameObject Draw;
    public PlayerStats StatsSheet;
    public Draw drawScript;
    //public ParticleSystem block;
    //public ParticleSystem swing;
    //public ParticleSystem spell;
    
    //[SerializeField] private AudioSource CardPlayedSE;
    //[SerializeField] private AudioSource CardNotPlayedSE;
    
    void Start()
    {
        Draw = GameObject.FindGameObjectWithTag("Player");
        StatsSheet = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        float cardWidth = Screen.width / 275f; // Adjust the divisor as needed
        float cardHeight = Screen.height / 175f; // Adjust the divisor as needed

        // Set the card size
        transform.localScale = new Vector3(cardWidth, cardHeight, 1f);
    
        if (Draw == null)
        {
            Debug.LogError("Could not find object named 'Draw'");
            // Handle the missing object case, throw an error, or perform alternative actions.
        }
        else
        {
            // Access a script attached to the "Draw" object
             drawScript = Draw.GetComponent<Draw>();

            if (drawScript == null)
            {
                Debug.LogError("The 'Draw' object is missing the 'Draw' component");
                // Handle the missing component case, throw an error, or perform alternative actions.
            }

        }
    }
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        // Log the number of enemies found
        Debug.Log("Number of enemies: " + enemies.Length);

        // Assuming there is only one selected enemy at a time
        selected = false;
        enemy = null;

        foreach (GameObject e in enemies)
        {
            // Assuming the Select script is attached to the parent of the enemy
            Select enemyScript = e.GetComponent<Select>();

            if (enemyScript != null && enemyScript.isSelected)
            {
                enemy = enemyScript.GetEnemy();
                selected = true;

                // If you only want one selected enemy, break out of the loop after finding the first one
                break;
            }
        }
    }
    public void PlayCard()
    {
        //destroy = false;
        if (Drag.isPlayable)
        {
            //CardPlayedSE.Play();
            Debug.Log("Played card");
            int cost = PlayerStats.Energy - Energy;
            if (cost >= 0)
            {
                if (needTarget)
                {               
                    // Filter selected enemies
                    List<Enemy> selectedEnemies = new List<Enemy>();
                    foreach (GameObject e in enemies)
                    {
                        // Assuming the Select script is attached to a child of the enemy
                        Select enemyScript = e.GetComponentInChildren<Select>();

                        if (enemyScript != null && enemyScript.isSelected)
                        {
                            selectedEnemies.Add(enemyScript.GetEnemy());
                        }
                    }

                    // Check if there are enough selected enemies
                    if (selectedEnemies.Count > 0 && Target >= selectedEnemies.Count)
                    {
                        Debug.Log("Enough selected enemies: " + selectedEnemies.Count);

                        for (int i = 0; i < Target; i++)
                        {
                            if (i < selectedEnemies.Count && selectedEnemies[i] != null)
                            {
                                DealDamageAndApplyEffects(selectedEnemies[i]);
                                destroy = true;
                            }
                            else
                            {
                                Debug.Log("Selected enemy is null or index out of range at index " + i);
                            }
                        }

                        
                    }
                    else
                    {
                        ResetCard();
                    }
                }

                if (Shield > 0)
                    {
                        //block.Play();
                        if (PlayerStats.Frail > 0)
                        {
                            float a = Shield * 0.75f;
                            int b = Mathf.FloorToInt(a);
                            PlayerStats.Shield += b;
                            destroy = true;

                        }
                        else
                        {
                            PlayerStats.Shield += Shield;
                            destroy = true;
                        }
                    }
                                          
                    if (drawN > 0)
                    {
                    drawScript.DrawCards(drawN);
                        destroy = true;

                    }
                    if (energy > 0)
                    {
                        PlayerStats.Energy += energy;
                        destroy = true;
                    }  
                }
                if (destroy == true)
                {
                drawScript.DiscardCard(gameObject);
                Drag.isPlayable = false;
                    PlayerStats.Energy -= Energy;
                drawScript.CurrentHandSize -= 1;
                    destroy = false;
                }
                else
                {
                    ResetCard();

                }
        }
    }
    public void EndTurn()
    {
        drawScript.CurrentHandSize -= 1;
        drawScript.DiscardCard(gameObject);
        Destroy(gameObject);
        Drag.isPlayable = false;
    }

    private void DealDamageAndApplyEffects(Enemy enemy)
    {
        if (Damage > 0 || Weak > 0 || Frail > 0 || Burn > 0|| Poison > 0)
        {
            if (Damage > 0)
            {
                bonus = StatsSheet.CalculateDmgBonus(); // Assuming bonus is a static method
                enemy.TakeDamage(Damage + bonus);

            }
            if (Weak > 0)
            {
                enemy.Weak += Weak;
            }
            if (Frail > 0)
            {
                enemy.Frail += Frail;
            }
            if (Burn > 0)
            {
                enemy.Burn += Burn;
            }
            if (Poison > 0)
            {
                enemy.Poison += Poison;
            }
        }
    }

    private void ResetCard()
    {
        //CardNotPlayedSE.Play();
        Drag.reset = true;
        Drag.isPlayable = false;
        Debug.Log("Card reset because more enemies were selected than the target value");
    }
}