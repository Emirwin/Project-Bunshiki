using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSightBackground : MoveScript
{
    public GameObject Sight;
    private Vector2 startPos;
    public float repeatWidth = 14;
    // Start is called before the first frame update
    public override void Start()
    {
        startPos = transform.position;
        direction = Vector2.down;
    }

    public override void Update()
    {
        base.Update();
        if(transform.position.y < startPos.y - repeatWidth)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        transform.position = new Vector3(Sight.transform.position.x,startPos.x,0);
    }
}
