using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Sentence[] sentenceAmmo;
    void Start()
    {
        Debug.Log("Attacking!");
        Instantiate(sentenceAmmo[0]);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
