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


    //public bool attacksSlowed = false;
    public float attackSpeedModifier = 1.0f;    //modifier for the changing of screens
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        attackSpawnPos = gameManager.attackSpawnPoint.transform.position;
        spawnPos = new Vector3(attackSpawnPos.x + 1.57f,attackSpawnPos.y,0);
    }
    public virtual void Start()
    {
        int choiceIndex = 0;
        
        choiceIndex = Random.Range(0,sentenceAmmo.Count);
        
        
        
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

}
