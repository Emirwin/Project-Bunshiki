using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the movement of a Sentence (group of Words)
public abstract class MoveScript : MonoBehaviour
{
    public float speed = 0.5f;
    public float modifier = 1f;
    public Vector2 direction = new Vector2(0,0);
    // Start is called before the first frame update
    public virtual void Start()
    {
        if(gameObject.GetComponent<Collider2D>() == null)
        {
            Debug.LogWarning($"The sentence {gameObject.name} has no collider attached.");
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed * modifier);
    }


    // void OnTriggerEnter2D(Collider2D other) 
    // {
    //     Debug.Log($"{gameObject.name} collided with {other.name}!");
    //     if(!other.CompareTag("Bullet"))
    //     {
    //         Reflect();
    //     }
        
    // }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log($"{gameObject.name} collided with {col.gameObject.name}!");
        if(!col.gameObject.CompareTag("Bullet") && !col.gameObject.CompareTag("Player"))
        {
            Reflect();
        }
        
    }

    public void Reflect()
    {
        direction.x *= -1;
    }
}
