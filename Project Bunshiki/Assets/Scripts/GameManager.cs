using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Doublsb.Dialog;

public partial class GameManager : MonoBehaviour
{
    public enum GameState
    {
        StartStoryState, CombatState, EndStoryState, ScoreState
        //
    }

    public GameState gameState;
    public GameObject story;
    public GameObject endStory;
    public GameObject menuDialog;
    public GameObject helpDialog;

    public GameObject sight;
    public int sightNewPosition = 0;
    private bool fixSight = true;
    public GameObject sightBackground;

    ///PLAYER SCRIPTS
    public GameObject playerObject;
    public Player playerScript;
    public GameObject healthBar;
    public BarScript hpScript;
    public GameObject manaBar;
    public BarScript manaScript;
    
    ///ENEMY SCRIPTS
    public GameObject enemyObject;
    public Enemy enemyScript;
    public GameObject enemyHealthBar;
    public BarScript enemyHpScript;
    public List<GameObject> nextEnemies; private int nxtEnemyCounter = 0;

    public GameObject enemyContainer;
    public EnemyContainerAnim enemyParticleSystem;
    public EnemySE enemySE;


    public GameObject attackSpawnPoint;
    public string weakPoint = ""; //For POSAttacks

    public SpellManager spellManager;
    public UIManager uIManager;

    
    [SerializeField]
    private int deactivateCounter = 0;

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

        //Start story if story as attached
        if(story != null)
        {
            story.SetActive(true);
            gameState = GameState.StartStoryState;
        }
        else
        {
            enemyScript.enabled = true;
            gameState = GameState.CombatState;
        }
        //spawn enemy and initialize values
        
    }

    // Update is called once per frame
    void Update()
    {
        if(story != null && gameState.Equals(GameState.StartStoryState))
        {
            if((story.GetComponent<StoryTest>().DManager.state).Equals(Doublsb.Dialog.State.Deactivate))
            {
                if(!enemyScript.enabled)
                {
                    deactivateCounter++;
                }
            }
            Debug.Log($"{(story.GetComponent<StoryTest>().DManager.state).Equals(Doublsb.Dialog.State.Deactivate)}");
            if(!enemyScript.enabled && deactivateCounter>2)
            {
                
                enemyScript.enabled = true;
                gameState = GameState.CombatState;
                deactivateCounter = 0;
            }            
        }

        if(enemyObject == null && gameState.Equals(GameState.CombatState) )
        {
            Debug.Log($"hello ");
            //TODO Spawn new enemy if there is an enemy next in line?
            if(nextEnemies.Count != 0 && nextEnemies.Count != nxtEnemyCounter)
            {
                enemyObject = Instantiate(nextEnemies[nxtEnemyCounter],
                                            Vector3.zero,
                                            Quaternion.identity,
                                            enemyContainer.transform);
                enemyScript = enemyObject.GetComponent<Enemy>();
                enemyHpScript = enemyHealthBar.GetComponent<BarScript>();
                enemyHpScript.InitializeBar(enemyScript.hitPoints);

                nxtEnemyCounter++;

            } //otherwise go to end story state and then score state
            else if(story != null)
            {
                gameState = GameState.EndStoryState;
                //Start second dialog box
                ChangeSpeedSightBGModi(0);
                endStory.SetActive(true);
                uIManager.EnableGameClearScreen();
                //TODO unlock next level if isn't unlocked yet
                
            }
            else
            {
                //For Endless mode
                gameState = GameState.ScoreState;
            }
            
        }

        MoveSight();
    }
    
    public void playerTakeDamage()
    {
        //sound is instead handled by Player class itself
        hpScript.updateBar(-1);
    }

    public void playerUpdateMana(int manaToAdd)
    {
        //Sound effect (to be handled by bar script)
        manaScript.updateBar(manaToAdd);
    }

    public void enemyTakeDamage(int damageToDeal)
    {
        //TODO Sound effect (In the end of a spell)
        //enemy animator play damage
        enemyScript.enemyAnimScript.PlayDamageAnim();
        //enemy damage particle effect accord to element
        enemyHpScript.updateBar(-damageToDeal);
        enemyScript.hitPoints-=damageToDeal;
    }

    public void enemyTakeDamage(int damageToDeal, string damageElement)
    {
        //enemy animator play damage
        Debug.Log("Where");
        enemySE.PlayDamageSE(damageElement);
        Debug.Log("Did");
        enemyParticleSystem.PlayDamageAnim(damageElement);
        Debug.Log("it");
        enemyTakeDamage(damageToDeal);
    }

    public void enemyStopAttack()
    {
        enemyScript.StopAttack();
    }

    public void ChangeScreen(string screenName)
    {
        if(string.Compare("returnScreen",screenName)==0)
        {
            sightNewPosition = 0;
            fixSight = false;
            //make the sight return to normal speed
            ChangeSpeed(2f);
            enemyScript.ChangeAttackMode("Normal");
        } 
        else if (string.Compare("spellScreen",screenName)==0)
        {
            sightNewPosition = -5;
            fixSight = false;
            //slow down the sight
            ChangeSpeed(0.5f);
            enemyScript.ChangeAttackMode("Defense");
        }
        else if (string.Compare("inventoryScreen",screenName)==0)
        {
            //Open Inventory UI Menu
        }
        else if (string.Compare("menuScreen",screenName)==0)
        {
            menuDialog.SetActive(true);
        }
        else if (string.Compare("helpScreen",screenName)==0)
        {
            helpDialog.SetActive(true);
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

        ChangeSpeedSightBackground(multiplier);

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

    float ChangeSpeedSightBackground(float multiplier)
    {
        float temp = sightBackground.GetComponent<MoveScript>().modifier;
        sightBackground.GetComponent<MoveScript>().modifier*=multiplier;
        return temp;
    }

    void ChangeSpeedSightBGModi(float newMod)
    {
        sightBackground.GetComponent<MoveScript>().modifier = newMod;
    }

    public void PauseGame()
    {
        ChangeSpeedSightBGModi(0);
        playerScript.DisablePlayerMovement();
        enemyScript.StopAttack();
    }

    public void ResumeGame()
    {
        ChangeSpeedSightBGModi(1);
        playerScript.EnablePlayerMovement();
        enemyScript.StartAttack();
    }
}
