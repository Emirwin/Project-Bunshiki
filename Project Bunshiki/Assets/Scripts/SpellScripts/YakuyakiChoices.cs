using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuyakiChoices : MonoBehaviour
{
    public int pointValue;
    private Yakuyaki yakuyaki;
    
    void Start()
    {
        yakuyaki = GameObject.FindGameObjectWithTag("ActiveSpell").GetComponent<Yakuyaki>();
    }
    void OnMouseDown()
    {
        yakuyaki.activeProblem = GameObject.FindGameObjectWithTag("ActiveProblem");
        if(pointValue>0)
        {
            yakuyaki.UpdateScore(pointValue);
            yakuyaki.noActiveProblem = true;
            Destroy(yakuyaki.activeProblem);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
