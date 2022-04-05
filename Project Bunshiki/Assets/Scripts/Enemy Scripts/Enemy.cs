using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitPoints;
    private int maxHitPoints;   //original hit points
    
    public float enemyCurrentAggression = 10.0f; //lower is more aggressive (controls rate of attack)
    [SerializeField]
    private float enemyMaxAgression;    //original aggression

    public Attack[] enemyAttacks;
    public int currentAttack = 0;
    public int attackCount = 3; //Number of attacks to do before switching to next attack
    [SerializeField]
    private int attackCounter = 0; 
    [SerializeField]
    private int attackCountOriginal;
    public float attackSpeedModifier = 1.0f;

    public bool isLastAttack = false;

    
    //public
    void Awake()
    {
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

        if(attackCounter == attackCount && enemyAttacks.Length > 1)
        {
            isLastAttack = true;

            switchAttack();
            attackCounter = 0;
        }
        
        
    }

    public void changeCount(int newCount)
    {
        attackCount = newCount;
    }

    public void ResetCount()
    {
        changeCount(attackCountOriginal);
    }
    
    public bool IsFirstAttack()
    {
        return (attackCounter == 1);
    }

    void switchAttack()
    {
        Debug.Log("SWITCHING ATTACK!");
        currentAttack++;

    }

}
