using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDiagonal : MoveScript
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        direction = new Vector2(Random.Range(-1,1),-1f);
        
    }
    public override void Update()
    {
        base.Update();
    }
}
