using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public GameObject sight;
    public int sightNewPosition = 0;
    private bool fixSight = true;

    public GameObject playerObject;
    public Player playerScript;
    public GameObject healthBar;
    public BarScript hpScript;
    public GameObject manaBar;
    public BarScript manaScript;
    
    public GameObject enemyObject;
    public Enemy enemyScript;
    public GameObject enemyHealthBar;
    public BarScript enemyHpScript;


    public GameObject attackSpawnPoint;
    public string weakPoint = ""; //For POSAttacks

    public SpellManager spellManager;

    void Awake()
    {
        spellManager = GameObject.Find("SpellManager").GetComponent<SpellManager>();

        hpScript = healthBar.GetComponent<BarScript>();
        manaScript = manaBar.GetComponent<BarScript>();
        playerScript = playerObject.GetComponent<Player>();

        if(enemyObject != null)
        {
            
            enemyHpScript = enemyHealthBar.GetComponent<BarScript>();
            enemyScript = enemyObject.GetComponent<Enemy>();
        }
        else
        {
            Debug.LogWarning("No enemy in scene.");
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        hpScript.InitializeBar(playerScript.playerHitPoints);
        manaScript.InitializeBar(playerScript.playerManaPoints);

        if(enemyObject!=null)
        {
            enemyHpScript.InitializeBar(enemyScript.hitPoints);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveSight();
    }

    public void playerTakeDamage()
    {
        hpScript.updateBar(-1);
    }

    public void playerUpdateMana(int manaToAdd)
    {
        manaScript.updateBar(manaToAdd);
    }

    public void enemyTakeDamage(int damageToDeal)
    {
        enemyHpScript.updateBar(-damageToDeal);
    }

    public void ChangeScreen(string screenName)
    {
        if(string.Compare("returnScreen",screenName)==0)
        {
            sightNewPosition = 0;
            fixSight = false;
            //make the sight return to normal speed
            ChangeSpeed(2f);
        } 
        else if (string.Compare("spellScreen",screenName)==0)
        {
            sightNewPosition = -5;
            fixSight = false;
            //slow down the sight
            ChangeSpeed(0.5f);
        }
        else if (string.Compare("inventoryScreen",screenName)==0)
        {
            //Open Inventory UI Menu
        }
        else
        {
            Debug.Log("No such screen!");
        }
    }

    void MoveSight()
    {
        if(sight.transform.position.x > sightNewPosition && !fixSight)
        {
            sight.transform.Translate(Vector2.left * Time.deltaTime * 3);
            if(Mathf.Ceil(sight.transform.position.x) == sightNewPosition)
            {
                fixSight = true;
            }
        }
        else if(sight.transform.position.x < sightNewPosition && !fixSight)
        {
            sight.transform.Translate(Vector2.right * Time.deltaTime * 3);
            if(Mathf.Floor(sight.transform.position.x) == sightNewPosition)
            {
                fixSight = true;
            }
        }
    }

    void ChangeSpeed(float multiplier)
    {
        ChangeSpeedCurrentAttacks(multiplier, "EnemyAttack");
        ChangeSpeedCurrentBullets(multiplier, "Bullet");

        //tell enemy to make its attacks go slower/faster
        enemyScript.attackSpeedModifier *= multiplier;
        //tell player to make its bullets go slower/faster
        // if(multiplier<1)
        // {
        //     playerScript.bulletsSlowed = true;
        // }
        // else
        // {
        //     playerScript.bulletsSlowed = false;
        // }

        playerScript.bulletSpeedModifier *= multiplier;
        
    }

    void ChangeSpeedCurrentAttacks(float multiplier, string tags)
    {
        GameObject[] sceneEnemyAttacks = GameObject.FindGameObjectsWithTag(tags);
        Debug.Log(sceneEnemyAttacks);

        for(int i = 0; i < sceneEnemyAttacks.Length; i++)
        {
            sceneEnemyAttacks[i].GetComponent<MoveScript>().modifier*=multiplier;
        }
    }

    void ChangeSpeedCurrentBullets(float multiplier, string tags)
    {
        GameObject[] scenePlayerBullets = GameObject.FindGameObjectsWithTag(tags);
        Debug.Log(scenePlayerBullets);

        for(int i = 0; i < scenePlayerBullets.Length; i++)
        {
            scenePlayerBullets[i].GetComponent<MoveScript>().modifier*=multiplier;
        }
    }
}
