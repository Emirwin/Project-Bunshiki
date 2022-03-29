using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POSAdjAttack : Attack
{
    // Start is called before the first frame update
    public override void Start()
    {
        if(!gameManager.GetComponent<GameManager>().weakPoint.Contains("adj"))
        {
            gameManager.GetComponent<GameManager>().weakPoint = "adj";
        }
        base.Start();
    }
}
