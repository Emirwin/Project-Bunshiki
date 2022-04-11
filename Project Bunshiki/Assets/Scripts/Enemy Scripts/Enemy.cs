using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitPoints;
    private int maxHitPoints;   //original hit points
    
    public float enemyCurrentAggression = 10.0f; //lower is more aggressive (controls rate of attack)
    [SerializeField]
    private float enemyMaxAgression;  
    public float EnemyMaxAggression {
        get { return enemyMaxAgression; }
    }  //original aggression

    public Attack[] enemyAttacks;
    public int currentAttack = 0;
    public int attackCount = 2; //Number of attacks to do before switching to next attack
    [SerializeField]
    private int attackCounter = 0; 
    [SerializeField]
    private int attackCountOriginal;
    public float attackSpeedModifier = 1.0f;

    public bool isLastAttack = false;

    
    //public
    void Awake()
    {
        if(attackCount == 1)
        {
            Debug.LogWarning("Attack Count was set to 1. It must be at least 2. If you want a single sentence from an attack, make the attack Inherit from AttackSingle (All attacks will be spawned at least twice otherwise).");
        }
        if(attackCount <= 2)
        {
            Debug.Log($"First: Attack Count was set to {attackCount}");
        }
        else
        {
            Debug.LogError($"Invalid attackCount: {attackCount}");
        }
        
        //Save values
        maxHitPoints = hitPoints;
        enemyMaxAgression = enemyCurrentAggression;
        attackCountOriginal = attackCount;

    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("doAttack",2.0f,enemyCurrentAggression);
    }

    // Update is called once per frame
    void Update()
    {


        if(hitPoints==0)
        {
            //kill enemy
            Destroy(gameObject);
        }

        //moveEnemy();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other);
        //hitPoints--;
    }

    public void ChangeAggression(float multiplier)
    {
        enemyCurrentAggression*=multiplier;

        if(multiplier<=1.0f) {  //For animation
            Debug.Log($"{gameObject.name} got angrier! Aggresion: {enemyCurrentAggression}");
        }
        else {
            Debug.Log($"{gameObject.name} got calmer! Aggresion: {enemyCurrentAggression}");
        }

        CancelInvoke();
        InvokeRepeating("doAttack", 2.0f, enemyCurrentAggression);
    }

    public void ReplaceAggression(float newAggression)
    {
        enemyCurrentAggression = newAggression;
        Debug.Log($"{gameObject.name}: New aggression ({newAggression})");

        CancelInvoke();
        InvokeRepeating("doAttack", 2.0f, enemyCurrentAggression);
    }

    public void ResetAggression()
    {
        Debug.Log("Enemy Aggression has been reset");
        enemyCurrentAggression = enemyMaxAgression;

        CancelInvoke();
        InvokeRepeating("doAttack", 3.0f, enemyCurrentAggression);
    }

    public virtual void doAttack()
    {
        attackCounter++;
        if(IsFirstAttack())
        {
            isLastAttack = false;
        }

        Attack temp;
        temp = Instantiate(enemyAttacks[currentAttack%enemyAttacks.Length]);
        temp.attackSpeedModifier *= attackSpeedModifier;

        if(attackCounter == attackCount && enemyAttacks.Length > 1 || temp.numberToSpawn == 1)
        {
            isLastAttack = true;

            switchAttack();
            attackCounter = 0;
        }
        
        
    }

    public void ChangeCount(int newCount)
    {
        Debug.Log($"Enemy {gameObject.name}: attack count changed to {newCount}");
        attackCount = newCount;
    }

    public void ResetCount()
    {
        Debug.Log($"Enemy {gameObject.name}: attack count reset");
        ChangeCount(attackCountOriginal);
    }
    
    public bool IsFirstAttack()
    {
        return (attackCounter == 1);
    }

    public void switchAttack()
    {
        Debug.Log("SWITCHING ATTACK!");

        currentAttack++;

    }

}
