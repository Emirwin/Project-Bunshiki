using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakanoboriChoices : MonoBehaviour
{
    public int pointValue;
    public GameObject waterBG;
    public GameObject mistBG;
    public int choiceXPos;

    void Start()
    {
        choiceXPos = (int)gameObject.transform.position.x;
        if(pointValue>0)
        {
            waterBG.SetActive(true);
        }
    }

    public void Demist()
    {
        mistBG.SetActive(false);
    }

}
