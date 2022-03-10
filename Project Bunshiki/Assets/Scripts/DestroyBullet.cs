using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    public int bulletHitPoints = 1;
    
    void Update()
    {
        if(bulletHitPoints==0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{gameObject.name} collided with {other.name}!");
        bulletHitPoints--;
        if(other.CompareTag("Wall"))
        {
            bulletHitPoints = 0;
        }
    }
}
