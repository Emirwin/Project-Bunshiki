using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentence : MonoBehaviour
{
    //This does nothing but separate it from other GameObjects
    //public List<WordAttack> words;

    void Update()
    {
        if(transform.childCount == 0)
        {
            Destroy(gameObject, 1.0f);
        }
    }
}
