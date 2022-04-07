using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MoveScript
{
    public override void Start()
    {
        base.Start();
        direction = Vector2.down;
    }
    public override void Update()
    {
        base.Update();
    }
}
