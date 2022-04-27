using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFreqChanger : Attack
{
    public enum fixedTimes
    {
        QuadTime,
        DoubleTime,
        OneAndHalfTimeFaster,
        HalfTime,
        QuarterTime,
        OneAndHalfTime,
        ResetTime

    }

    public fixedTimes aggressionModifier;

    public override void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    
    public override void Start()
    {
        float temp = gameManager.enemyScript.EnemyMaxAggression;
        if(sentenceAmmo.Count>0)
        {
            Debug.LogWarning($"Attack {gameObject.name} should have no ammo!");
        }

        Debug.Log($"{gameObject.name}: adding multiplier to aggression: {aggressionModifier}");

        if(aggressionModifier == fixedTimes.DoubleTime)
        {
            gameManager.enemyScript.ReplaceAggression(temp/2);
        }
        else if(aggressionModifier == fixedTimes.HalfTime)
        {
            gameManager.enemyScript.ReplaceAggression(temp*2);
        }
        else if(aggressionModifier == fixedTimes.QuadTime)
        {
            gameManager.enemyScript.ReplaceAggression(temp/4);
        }
        else if(aggressionModifier == fixedTimes.QuarterTime)
        {
            gameManager.enemyScript.ReplaceAggression(temp*4);
        }
        else if(aggressionModifier == fixedTimes.OneAndHalfTimeFaster)
        {
            gameManager.enemyScript.ReplaceAggression(temp/1.5f);
        }
        else if(aggressionModifier == fixedTimes.OneAndHalfTime)
        {
            gameManager.enemyScript.ReplaceAggression(temp*1.5f);
        }
        else
        {
            gameManager.enemyScript.ReplaceAggression(temp);
        }

        

        Destroy(gameObject);
    }
}
