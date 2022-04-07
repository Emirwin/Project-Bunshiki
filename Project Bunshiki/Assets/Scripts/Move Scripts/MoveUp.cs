using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MoveScript
{
    public override void Start()
    {
        base.Start();
        direction = Vector2.up;
    }
    public override void Update()
    {
        base.Update();
    }
}
