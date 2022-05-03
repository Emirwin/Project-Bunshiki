using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConjQuestion : MonoBehaviour
{
    public GameObject answer;
    public ChoicePositionRand choicePositionRand;
    private bool oneIsDestroyed = false;
    //public List<GameObject> choices;

    void Update()
    {
        if(!oneIsDestroyed)
        {
            if(choicePositionRand.OneIsDestroyed() 
            && !answer.activeInHierarchy)
            {
                oneIsDestroyed = true;
                RevealAnswer();
            }
        }
        
    }
    
    public void RevealAnswer()
    {
        answer.SetActive(true);
    }
}
