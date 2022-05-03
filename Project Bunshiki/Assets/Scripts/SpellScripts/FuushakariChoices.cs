using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuushakariChoices : YakuyakiChoices
{
    public GameObject answer;
    [SerializeField]private Fuushakari fuushakariScript;
    //private new GameObject referredWord = null;
    public override void Start()
    {
        referredWord = null;
        fuushakariScript = GameObject.FindGameObjectWithTag("ActiveSpell").GetComponent<Fuushakari>();
    }
    public override void Update()
    {
        
        if(isSEPlayedFinished && pointValue>0)
        {
            isSEPlayedFinished = false;
            
            mySE.PlayOneShot(BurnSE);

            //spin the windmill, show the answer and then destroy
            StartCoroutine(DestroyFuushakariRoutine());
        }
        else if(isSEPlayedFinished)
        {
            isSEPlayedFinished = false;
            mySE.PlayOneShot(BurnSE);

            //Destroy(gameObject);
        }
    }
    public override void OnMouseDown()
    {
        fuushakariScript.activeProblem = GameObject.FindGameObjectWithTag("ActiveProblem");

        if(!isClicked)
        {
            if(pointValue>0)
            {
                //play Correct particle
                PlayCorrectEffect();

                fuushakariScript.UpdateScore(pointValue);
            }
            else
            {
                //play Incorrect particle
                PlayWrongEffect();
            }
            isClicked = true;
        }
    }

    IEnumerator DestroyFuushakariRoutine()
    {
        answer.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        fuushakariScript.noActiveProblem = true;
        Destroy(fuushakariScript.activeProblem);
    }
}
