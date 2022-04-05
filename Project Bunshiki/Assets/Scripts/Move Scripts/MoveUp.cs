using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MoveScript
{
    void Start()
    {
        direction = Vector2.up;
    }
    public override void Update()
    {
        base.Update();
    }
}
