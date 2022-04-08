using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Word objects for the sight specifically
//DEPRECATED: use WordAttack instead.
public abstract class Word : MonoBehaviour
{
    public int hitPoints = 6;
    public GameObject gameManager;

    public bool isIndestructible;
    public bool isPassable;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        if(isIndestructible)
        {
            //change color to cool one
        }
        if(isPassable)
        {
            //change opacity
        }
    }
    void Update()
    {
        if(hitPoints==0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            Debug.Log($"{gameObject.name} collided with {other.name}!");
            hitPoints = 0;
        }
        else if(other.CompareTag("Bullet") && !isIndestructible)
        {
            Debug.Log($"{gameObject.name} collided with {other.name}! Dealing {other.GetComponentInParent<Bullet>().bulletPower} damage!");
            hitPoints -= other.GetComponentInParent<Bullet>().bulletPower;
            
            if(string.Equals(gameObject.name,gameManager.GetComponent<GameManager>().weakPoint))
            {
                Debug.Log($"BONUS DAMAGE!"); 
                hitPoints -= 2;
            }
        }
    }
}
