using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hitPoints;
    public float enemySpeed;
    public float enemyAggression = 10.0f; //lower is more aggressive
    public Attack[] enemyAttacks;
    public int currentAttack = 0;
    //public
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("doAttack",2.0f,enemyAggression);
    }

    // Update is called once per frame
    void Update()
    {
        if(hitPoints==0)
        {
            //kill enemy
            Destroy(gameObject);
        }

        //moveEnemy();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other);
        //hitPoints--;
    }

    public virtual void doAttack()
    {
        Instantiate(enemyAttacks[currentAttack%enemyAttacks.Length]);
        currentAttack++;
    }

    // public virtual void moveEnemy()
    // {
    //     transform.Translate(direction * Time.deltaTime * playerSpeed);
    // }
}
