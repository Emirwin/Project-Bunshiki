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

    public string weakPoint = ""; //For POSAttacks

    void Awake()
    {
        hpScript = healthBar.GetComponent<BarScript>();
        manaScript = manaBar.GetComponent<BarScript>();
        playerScript = playerObject.GetComponent<Player>();

        enemyHpScript = enemyHealthBar.GetComponent<BarScript>();
        enemyScript = enemyObject.GetComponent<Enemy>();
    }
    // Start is called before the first frame update
    void Start()
    {
        hpScript.InitializeBar(playerScript.playerHitPoints);
        manaScript.InitializeBar(playerScript.playerManaPoints);

        enemyHpScript.InitializeBar(enemyScript.hitPoints);
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

    public void ChangeScreen(string screenName)
    {
        if(string.Compare("returnScreen",screenName)==0)
        {
            sightNewPosition = 0;
            fixSight = false;
        } 
        else if (string.Compare("spellScreen",screenName)==0)
        {
            sightNewPosition = -5;
            fixSight = false;
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
}
