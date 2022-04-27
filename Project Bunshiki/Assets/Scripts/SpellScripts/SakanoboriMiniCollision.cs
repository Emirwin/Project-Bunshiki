using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakanoboriMiniCollision : MonoBehaviour
{
    public Sakanobori sakanoboriScript;
    public GameObject miniSprite;
    public Vector3 startPosition;

    void Start()
    {
        startPosition = gameObject.transform.position;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        sakanoboriScript.activeProblem = GameObject.FindGameObjectWithTag("ActiveProblem");
        
        if(other.CompareTag("StartSakanobori"))
        {

        }
        else if(other.CompareTag("Water"))
        {
            sakanoboriScript.PlayLandOnSE("water");
            sakanoboriScript.StopMini();
            sakanoboriScript.nextProblemButton.SetActive(true);
        }
        else if(other.CompareTag("Mist")) //
        {
            sakanoboriScript.StopMini();
        }
        else if(other.CompareTag("Choice"))
        {
            SakanoboriChoices choice = other.GetComponent<SakanoboriChoices>();
            int choicePtValue = choice.pointValue;
            int choiceXPosition = choice.choiceXPos;
            
            other.GetComponent<SakanoboriChoices>().Demist();

            if(choicePtValue>0){
                //Play Correct Particle
                choice.PlayCorrectEffect();
                sakanoboriScript.PlayLandOnSE("water");

                sakanoboriScript.UpdateScore(choicePtValue);
                
                StartCoroutine(CorrectCoroutine(0.5f,choiceXPosition));
            }
            else {
                //Play Incorrect Particle
                choice.PlayWrongEffect();
                sakanoboriScript.PlayLandOnSE("rock");

                sakanoboriScript.NextMini();
            }
            
        }
    }

    IEnumerator CorrectCoroutine(float seconds, int choiceXPosition)
    {

        yield return new WaitForSeconds(seconds);

        sakanoboriScript.StopMini();

        switch (choiceXPosition)
        {
            case 1:
                sakanoboriScript.Jump(Sakanobori.jumpDirection.Right);
                break;
            case 4:
                sakanoboriScript.Jump(Sakanobori.jumpDirection.Center);
                break;
            case 7:
                sakanoboriScript.Jump(Sakanobori.jumpDirection.Left);
                break;
        }
    }
}
