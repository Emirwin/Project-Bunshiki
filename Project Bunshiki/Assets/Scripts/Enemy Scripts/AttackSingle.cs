using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackSingle : Attack
{
    public override void Start()
    {
        if(sentenceAmmo.Count>1)
        {
            Debug.LogWarning($"Attack {gameObject.name} should only have one ammo!");
        }
        if(numberToSpawn != 1)
        {
            Debug.LogError($"{gameObject.name}: Number to spawn must be 1");
        }

        newestSentence = SpawnSentence(sentenceAmmo[0]);
        newestSentence.GetComponent<MoveScript>().modifier *= attackSpeedModifier;

        Destroy(gameObject);  

    }
}
