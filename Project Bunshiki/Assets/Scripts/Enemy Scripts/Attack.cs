using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public Sentence[] sentenceAmmo;
    public int currentSentence = 0;
    public GameObject gameManager;

    //public bool attacksSlowed = false;
    public float attackSpeedModifier = 1.0f;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }
    public virtual void Start()
    {
        Debug.Log($"Attacking! With {gameObject.name}");
        //new Vector3(1.56f,3f,0)
        Vector3 AttackSpawnPos = gameManager.GetComponent<GameManager>().attackSpawnPoint.transform.position;
        Vector3 spawnPos = new Vector3(AttackSpawnPos.x + 1.57f,AttackSpawnPos.y,0);

        Sentence temp;

        temp = Instantiate(sentenceAmmo[Random.Range(0,sentenceAmmo.Length)],spawnPos,Quaternion.identity,gameManager.transform);
        temp.GetComponent<MoveDown>().modifier *= attackSpeedModifier;
        
        Destroy(gameObject);
    }

}
