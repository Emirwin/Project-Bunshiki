using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFreqChanger : Attack
{
    public enum fixedTimes
    {
        QuadTime,
        DoubleTime,
        HalfTime,
        QuarterTime,
        ResetTime

    }

    public fixedTimes aggressionModifier;
    
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
        else
        {
            gameManager.enemyScript.ReplaceAggression(temp);
        }

        

        Destroy(gameObject);
    }
}
