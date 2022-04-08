using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleAttackGloss : Attack
{
    // Start is called before the first frame update
    public override void Start()
    {
        if(sentenceAmmo.Count>1)
        {
            Debug.LogWarning($"Attack {gameObject.name} should only have one ammo!");
        }
        base.Start();
    }
}
