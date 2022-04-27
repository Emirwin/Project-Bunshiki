using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleAttackIntro : Attack
{
    public override void Start()
    {
        if(numberToSpawn == 0)
        {
            Debug.LogError("Number to spawn is set to zero");
        }
        if(sentenceAmmo.Count>1)
        {
            Debug.LogWarning($"Attack {gameObject.name} should only have one ammo!");
        }
        if(numberToSpawn != 1)
        {
            ManageEnemyValues(aggressionMod, numberToSpawn);  
        }  
        //ManageEnemyValues(1.0f,numberToSpawn);
        int choiceIndex = 0;
        
        newestSentence = SpawnSentence(sentenceAmmo[choiceIndex]);
        newestSentence.GetComponent<MoveScript>().modifier *= attackSpeedModifier;

        Destroy(gameObject);
        
    }
}
