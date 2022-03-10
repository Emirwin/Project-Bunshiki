using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitPoints;
    public float enemySpeed;
    public Attack[] enemyAttacks;
    //public
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("doAttack",2.0f,3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(hitPoints==0)
        {
            Destroy(gameObject);
        }

        //moveEnemy();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other);
        hitPoints--;
    }

    public virtual void doAttack()
    {
        Instantiate(enemyAttacks[0]);
    }

    // public virtual void moveEnemy()
    // {
    //     transform.Translate(direction * Time.deltaTime * playerSpeed);
    // }
}
