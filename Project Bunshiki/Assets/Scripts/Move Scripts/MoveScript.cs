using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveScript : MonoBehaviour
{
    public float speed = 0.5f;
    public float modifier = 1f;
    public Vector2 direction = new Vector2(0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed * modifier);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{gameObject.name} collided with {other.name}!");
        if(!other.CompareTag("Bullet"))
        {
            Reflect();
        }
        
    }

    public void Reflect()
    {
        direction.x *= -1;
    }
}
