using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public Text enemyHP;
    public Enemy enemy;
    private float HP;
    private float SH;
    void Start()
    {
         HP = enemy.health;
         SH = enemy.shield;
    }

    // Update is called once per frame
    void Update()
    {
         HP = enemy.health;
         SH = enemy.shield;
        enemyHP.text = "HP = " + HP.ToString() + " Shield = " + SH.ToString();
    }

}