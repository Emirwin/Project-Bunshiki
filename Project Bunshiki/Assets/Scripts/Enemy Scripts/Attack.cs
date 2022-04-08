using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    //public Sentence[] sentenceAmmo;
    public List<Sentence> sentenceAmmo;
    //public int currentSentence = 0;
    public Sentence newestSentence;
    public GameManager gameManager;

    protected Vector3 attackSpawnPos;
    protected Vector3 spawnPos;
    public float spawnPosXOffset = 1.57f;

    public int numberToSpawn;
    public float aggressionMod; 


    //public bool attacksSlowed = false;
    public float attackSpeedModifier = 1.0f;    //modifier for the changing of screens
    void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        attackSpawnPos = gameManager.attackSpawnPoint.transform.position;
        spawnPos = new Vector3(attackSpawnPos.x + spawnPosXOffset,attackSpawnPos.y,0);
    }
    public virtual void Start()
    {
        int choiceIndex = 0;
        
        choiceIndex = Random.Range(0,sentenceAmmo.Count);
        
        if(numberToSpawn != 1)
        {
            ManageEnemyValues(aggressionMod, numberToSpawn);  
        }  
        
        
        newestSentence = SpawnSentence(sentenceAmmo[choiceIndex]);
        newestSentence.GetComponent<MoveScript>().modifier *= attackSpeedModifier;

        Destroy(gameObject);
        
    }

    public Sentence SpawnSentence(Sentence sentenceToSpawn)
    {
        Debug.Log($"Attacking! With {gameObject.name}");

        

        Sentence temp;

        temp = Instantiate(sentenceToSpawn,spawnPos,Quaternion.identity,gameManager.transform);
        //temp.GetComponent<MoveDown>().modifier *= attackSpeedModifier;
        
        return temp;
        //Destroy(gameObject);
    }
    
    public void ManageEnemyValues(float aggressionModifier, int numberOfAttacksToSpawn)
    {
        if(gameManager.enemyScript.IsFirstAttack())
        {
            Debug.Log("First Attack");
            gameManager.enemyScript.ChangeAggression(aggressionModifier);
            gameManager.enemyScript.ChangeCount(numberOfAttacksToSpawn);
        }
        if(gameManager.enemyScript.isLastAttack)
        {
            Debug.Log("Last Attack");
            gameManager.enemyScript.ResetAggression();
            gameManager.enemyScript.ResetCount();
        }
    }
}
