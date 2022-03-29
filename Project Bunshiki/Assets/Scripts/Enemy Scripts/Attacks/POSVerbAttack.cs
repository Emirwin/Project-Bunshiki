using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POSVerbAttack : Attack
{
    // Start is called before the first frame update
    public override void Start()
    {
        if(!gameManager.GetComponent<GameManager>().weakPoint.Contains("verb"))
        {
            gameManager.GetComponent<GameManager>().weakPoint = "verb";
        }
        base.Start();
    }

}
