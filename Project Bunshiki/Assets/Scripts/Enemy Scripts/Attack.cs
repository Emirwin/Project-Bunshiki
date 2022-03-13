using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public Sentence[] sentenceAmmo;
    public int currentSentence = 0;
    public GameObject gameManager;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }
    public virtual void Start()
    {
        Debug.Log("Attacking!");
        Instantiate(sentenceAmmo[Random.Range(0,sentenceAmmo.Length)]);
        Destroy(gameObject);
    }

}
