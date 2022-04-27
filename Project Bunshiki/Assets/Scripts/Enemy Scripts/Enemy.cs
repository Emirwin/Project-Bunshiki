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

    public enum AttackMode
    {
        Normal, Defense, Offense
        //Normal uses the regular pattern of attack
        //Defense minimizes player acquisition of mana and is done during spell rituals
        //Offense uses the regular pattern but adds an additional attack
    }
    [SerializeField] private AttackMode attackMode = AttackMode.Normal;

    public Attack[] enemyAttacks;
    public Attack[] enemyDefAttack, enemyOffAttack;
    public int currentAttack, currentDefAttack, currentOffAttack = 0;
    public int attackCount = 2; //Number of attacks to do before switching to next attack
    [SerializeField] private int[] attackCounter = {0,0,0}; 
    [SerializeField] private int attackCountOriginal;
    public float attackSpeedModifier = 1.0f;

    public bool[] isLastAttack = {false,false,false};

    public EnemyAnim enemyAnimScript;

    void OnEnable()
    {
        Player.OnPlayerDeath += StopAttack;
    }

    void OnDisable()
    {
        Player.OnPlayerDeath -= StopAttack;
    }

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
        StartAttack();
    }

    // Update is called once per frame
    void Update()
    {
        if(hitPoints <= maxHitPoints/3 && attackMode.Equals(AttackMode.Normal))
        {
            ChangeAttackMode("Offense");
        }

        if(hitPoints<=0)
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
        if(attackMode.Equals(AttackMode.Normal))
        {
            attackCounter[0]++;
            if(IsFirstAttack())
            {
                isLastAttack[0] = false;
            }

            Attack temp;
            temp = Instantiate(enemyAttacks[currentAttack%enemyAttacks.Length]);
            temp.attackSpeedModifier *= attackSpeedModifier;

            if(attackCounter[0] == attackCount && enemyAttacks.Length > 1 || temp.numberToSpawn == 1)
            {
                isLastAttack[0] = true;

                switchAttack("Normal");
                attackCounter[0] = 0;
            }
        }
        else if(attackMode.Equals(AttackMode.Defense))
        {
            attackCounter[1]++;
            if(IsFirstAttack())
            {
                isLastAttack[1] = false;
            }
            
            Attack temp;
            temp = Instantiate(enemyDefAttack[currentDefAttack%enemyDefAttack.Length]);
            temp.attackSpeedModifier *= attackSpeedModifier;

            if(attackCounter[1] == attackCount && enemyDefAttack.Length > 1 || temp.numberToSpawn == 1)
            {
                isLastAttack[1] = true;

                switchAttack("Defense");
                attackCounter[1] = 0;
            }
        }
        else if(attackMode.Equals(AttackMode.Offense))
        {
            attackCounter[2]++;
            if(IsFirstAttack())
            {
                isLastAttack[2] = false;
            }
            
            Attack temp;
            temp = Instantiate(enemyOffAttack[currentOffAttack%enemyOffAttack.Length]);
            temp.attackSpeedModifier *= attackSpeedModifier;

            if(attackCounter[2] == attackCount && enemyOffAttack.Length > 1 || temp.numberToSpawn == 1)
            {
                isLastAttack[2] = true;

                switchAttack("Offense");
                attackCounter[2] = 0;
            }
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
        switch (attackMode)
        {
            case AttackMode.Normal:
                return (attackCounter[0] == 1);
            case AttackMode.Defense:
                return (attackCounter[1] == 1);
            case AttackMode.Offense:
                return (attackCounter[2] == 1);
            default:
                return (attackCounter[0] == 1);
        }
        
    }

    public bool IsLastAttack()
    {
        switch (attackMode)
        {
            case AttackMode.Normal:
                return (isLastAttack[0]);
            case AttackMode.Defense:
                return (isLastAttack[1]);
            case AttackMode.Offense:
                return (isLastAttack[2]);
            default:
                return (isLastAttack[0]);
        }
    }

    public void switchAttack(string attackModeName)
    {
        switch (attackModeName)
        {
            case "Offense":
                currentOffAttack++;
                break;
            case "Defense":
                currentDefAttack++;
                break;
            default:
                currentAttack++;
                break;  
        }
        Debug.Log($"SWITCHING {attackModeName} ATTACK!");

    }

    public void StopAttack()
    {
        Debug.Log("STOPPING ATTACKS!");
        CancelInvoke();
    }

    public void StartAttack()
    {
        InvokeRepeating("doAttack",2.0f,enemyCurrentAggression);
    }

    public void ChangeAttackMode(string attackModeName)
    {
        switch (attackModeName)
        {
            case "Normal":
                attackMode = AttackMode.Normal;
                break;
            case "Offense":
                attackMode = AttackMode.Offense;
                break;
            case "Defense":
                attackMode = AttackMode.Defense;
                break;
            default:
                attackMode = AttackMode.Normal;
                break;
        }
    }

}
