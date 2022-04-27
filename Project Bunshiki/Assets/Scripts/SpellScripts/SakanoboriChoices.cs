using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakanoboriChoices : MonoBehaviour
{
    public int pointValue;
    public GameObject waterBG;
    public GameObject mistBG;
    public GameObject answerText;

    public int choiceXPos;

    public AudioSource mySE;
    public AudioClip CorrectSE;
    public AudioClip WrongSE;
    public GameObject CorrectSymbol;
    public GameObject WrongSymbol;

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
        answerText.SetActive(true);
    }

    public void PlayCorrectEffect()
    {
        mySE.PlayOneShot(CorrectSE);
        StartCoroutine(FlashEffect(CorrectSymbol));
    }

    public void PlayWrongEffect()
    {
        mySE.PlayOneShot(WrongSE);
        StartCoroutine(FlashEffect(WrongSymbol));
    }

    IEnumerator FlashEffect(GameObject objectToFlash)
    {
        objectToFlash.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        objectToFlash.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        objectToFlash.SetActive(true);
        yield return new WaitForSeconds(0.2f);
    }
}
