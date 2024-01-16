using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [Tooltip("Stats do inimigo")]
    public int startHealth;
    public int startShield; 
    public int Damage;
    public int Defense;
    public int WeakS;
    public int FrailS;
    public int Gvalue;
    public int PoisonS;
    public int BurnS;
    public bool boss;
    public bool elite;
    public bool UPPoisonS;
    [Header("other stuff")]
    [Tooltip("N�o mexer")]
    public bool UPPoison;
    public int selectedIndex;
    public int Weak;
    public int Frail;
    public int bonus;
    public int strenght;
    public bool powerUp;
    public int cooldown;
    public int Poison;
    public int Burn;
    public int health;
    public int shield;
    public Animator animator;
    public healthbar healthBar;
    public Text shieldtxt;
    //[SerializeField] private AudioSource attackSE;
    //[SerializeField] private AudioSource blockSE;
    //[SerializeField] private AudioSource hurtSE;
    //[SerializeField] private AudioSource defeatSE;
    //public Image healtBar;


    void Start()
    {
        health = startHealth;
        shield = startShield;
        Debug.Log("Selected Index: " + selectedIndex);
    }
    void Update()
    {
        shieldtxt.text = shield.ToString();
        healthBar.SetMaxHealth(startHealth);
        healthBar.SetHealth(health);
    }
    public void NewTurn()    
    {

        float[] probabilities = { 0.2f, 0.5f, 0.3f };
        selectedIndex = (int)Choose(probabilities);
        bonus = 0;

    }
    public void Action()
    {
        PlayerStats playerStats = GameObject.FindObjectOfType<PlayerStats>();
        float a = 0.5f * playerStats.hpStart;
        float b = 0.3f * startHealth;
        cooldown -= 1;
        if (boss)
        {
            if (health < b && powerUp == false)
            {
                strenght += 5;
                powerUp = true;
                return;
            }
        }
        if (boss || elite)
        {
            if (PlayerStats.Hp < a && cooldown == 0)
            {
                cooldown += 2;
                DealDMG();
                DealDMG();
                return;
            }
        }
       

        switch (selectedIndex)
        {
            case 0:
                GainShield();
                break;
            case 1:
                DealDMG();
                break;
            case 2:
                Debuff();
                break;

            default:
                break;
        }
        return;
    }
    public void ResetShield()
    {
        if (startShield > 0)
        {
            shield = startShield;
        }
        else
        {
            shield = 0;
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

    public void TakeDamage(int amount)
    {
        int dmgbonus = PlayerStats.DmgBonus;
        int dmg = amount + dmgbonus;
        //hurtSE.Play();
        animator.SetBool("tookdamage",true);

        if (PlayerStats.Weak > 0)
        {
            dmg = Mathf.FloorToInt(dmg* 0.75f);
        }
        int testshield = shield - dmg;
        if (testshield < 0)
        {
            ResetShield();
            health += testshield;
        }
        else
        {
            shield -= dmg;
        }
        Debug.Log(health + "remaining");
        animator.SetBool("tookdamage", false);


        Debug.Log(dmg);
        if (health <= 0)
        {
            animator.SetBool("isdead", true);
            
            StartCoroutine(DieAfterDelay(2f));
            //defeatSE.Play();
            
        }

    }

     IEnumerator DieAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Die();
    }
    
    public void GainShield()
    {
        animator.SetBool("isblocking",true);
        if (Frail > 0)
        {
            float frailshield = Defense * 0.75f;
            int fshield = Mathf.FloorToInt(frailshield);
            shield += fshield;
        }
        shield += Defense;
        //blockSE.Play();
        //animator.SetBool("isblocking",false);
    }
    public void DealDMG()
    {
        //animator.SetBool("isattacking",true);
        if (Weak > 0)
        {
            float dmg = (Damage * 0.75f) + bonus + strenght;
            int Idmg = Mathf.FloorToInt(dmg);
            PlayerStats.Shield -= Idmg;
            if (PlayerStats.Shield < 0)
            {
                PlayerStats.Hp += PlayerStats.Shield;
            }
        }
        else
        {
            PlayerStats.Shield -= Damage + bonus + strenght;
            if (PlayerStats.Shield < 0)
            {
                PlayerStats.Hp += PlayerStats.Shield;
            }
        }
        if (UPPoisonS)
        {
            PlayerStats.UPPoison = true;
        }
        if (PoisonS > 0)
        {
            PlayerStats.Poison += PoisonS;
        }
        //animator.SetBool("isattacking",false);
        //attackSE.Play();

    }
    public void Debuff()
    {
        //animator.SetBool("castingspell",true);
        if (FrailS > 0)
        {
            PlayerStats.Frail += FrailS;
        }
        if (WeakS > 0)
        {
            PlayerStats.Weak += WeakS;
        }
        
        if (BurnS > 0)
        {
            PlayerStats.Burn += BurnS;
        }
       
        //animator.SetBool("castingspell",false);        
    }
   public void Die()
    {

        //animator.SetBool("isdead",true);
        PlayerStats.Gold += Gvalue;
        PlayerStats.Count = 0;
        Destroy(gameObject);
    }
    public void EndOfTurnEffects()
    {
        if (Burn > 0)
        {
            health -= Burn;
            Burn--;
        }
        if (UPPoison && Poison > 0)
        {
            health -= UnityEngine.Mathf.FloorToInt(health * 0.05f);
            Poison--;
        }
        else if (Poison > 0)
        {
            health -= UnityEngine.Mathf.FloorToInt(health*0.02f);
            Poison--;
        }
    }
}
