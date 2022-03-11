using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POSNounAttack : Attack
{
    // Start is called before the first frame update
    public override void Start()
    {
        if(!gameManager.GetComponent<GameManager>().weakPoint.Contains("noun"))
        {
            gameManager.GetComponent<GameManager>().weakPoint = "noun";
        }
        base.Start();
    }

}
