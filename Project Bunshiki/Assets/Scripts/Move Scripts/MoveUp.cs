using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed = 0.5f;
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
}
