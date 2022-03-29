using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Word objects for the sight specifically
public class WordAttack : MonoBehaviour
{
    public int hitPoints = 6;
    public GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    void Update()
    {
        if(hitPoints==0)
        {
            //Once destroyed add to mana
            gameManager.GetComponent<GameManager>().playerUpdateMana(2);
            Destroy(gameObject);
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            Debug.Log($"{gameObject.name} collided with {other.name}!");
            Destroy(gameObject);
        }
        else if(other.CompareTag("Bullet"))
        {
            Debug.Log($"{gameObject.name} collided with {other.name}! Dealing {other.GetComponentInParent<Bullet>().bulletPower} damage!");
            hitPoints -= other.GetComponentInParent<Bullet>().bulletPower;
            
            if(string.Equals(gameObject.name,gameManager.GetComponent<GameManager>().weakPoint))
            {
                Debug.Log($"BONUS DAMAGE!"); 
                hitPoints -= 2;
                //Particle Effect
            }
        }
    }
}
