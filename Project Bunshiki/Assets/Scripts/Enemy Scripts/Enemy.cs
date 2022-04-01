using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitPoints;
    private int maxHitPoints;
    
    public float enemySpeed;
    
    public float enemyCurrentAggression = 10.0f; //lower is more aggressive
    private float enemyMaxAgression;

    public Attack[] enemyAttacks;
    public int currentAttack = 0;
    public float attackSpeedModifier = 1.0f;

    
    //public
    void Awake()
    {
        maxHitPoints = hitPoints;
        enemyMaxAgression = enemyCurrentAggression;
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

    void ChangeAggression(int multiplier)
    {
        enemyCurrentAggression*=multiplier;
    }

    public virtual void doAttack()
    {
        Attack temp;
        temp = Instantiate(enemyAttacks[currentAttack%enemyAttacks.Length]);
        temp.attackSpeedModifier *= attackSpeedModifier;

        if(hitPoints == maxHitPoints*0.6) //Think about the role of agression and etc
        {
            currentAttack++;
        }
        
    }

}
