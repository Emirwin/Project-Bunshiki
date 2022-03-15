using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class GameManager : MonoBehaviour
{
    public GameObject sight;
    public int sightNewPosition = 0;
    private bool fixSight = true;

    public string weakPoint = ""; //For POSAttacks
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveSight();
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
