using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POSBarrage : Attack
{
    public int numberToSpawn = 3;
    public float aggressionMod = 0.3f; 
    // Start is called before the first frame update
    public override void Start()
    {
        float randomPosX;
        float randomPosY;
        int choiceIndex;
        
        if(gameManager.enemyScript.IsFirstAttack())
        {
            Debug.Log("First Attack");
            gameManager.enemyScript.ChangeAggression(aggressionMod);
            gameManager.enemyScript.changeCount(numberToSpawn);
        }
        if(gameManager.enemyScript.isLastAttack)
        {
            Debug.Log("Last Attack");
            gameManager.enemyScript.ResetAggression();
            gameManager.enemyScript.ResetCount();
        }
        
        
        randomPosX = Random.Range(-1.5f,1.5f);
        randomPosY = Random.Range(0, 1.0f);
        spawnPos = new Vector3(attackSpawnPos.x + randomPosX,attackSpawnPos.y + randomPosY,0);
        choiceIndex = Random.Range(0,sentenceAmmo.Count);

        newestSentence = SpawnSentence(sentenceAmmo[choiceIndex]);
        newestSentence.GetComponent<MoveScript>().modifier *= attackSpeedModifier;
        
        
        Destroy(gameObject);
    }

    
}
