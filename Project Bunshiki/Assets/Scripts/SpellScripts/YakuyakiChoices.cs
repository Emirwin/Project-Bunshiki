using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YakuyakiChoices : MonoBehaviour
{
    public int pointValue;
    private Yakuyaki yakuyaki;

    public GameObject referredWord;
    private TextMeshPro referredWordText;

    public AudioSource mySE;
    public AudioClip CorrectSE, WrongSE;
    public AudioClip BurnSE;
    public GameObject CorrectSymbol;
    public GameObject WrongSymbol;
    protected bool isSEPlayedFinished = false;
    protected bool isClicked = false;
    
    public virtual void Start()
    {
        yakuyaki = GameObject.FindGameObjectWithTag("ActiveSpell").GetComponent<Yakuyaki>();
        if(pointValue<=0)
        {
            if(referredWord!=null)
            {
                referredWordText = referredWord.GetComponent<TextMeshPro>();
            }
            else
            {
                Debug.LogError($"Add a referred word in {gameObject.name}!");
            }
        }
    }
    public virtual void Update()
    {
        if(isSEPlayedFinished && pointValue>0)
        {
            isSEPlayedFinished = false;
            yakuyaki.noActiveProblem = true;
            mySE.PlayOneShot(BurnSE);
            Destroy(yakuyaki.activeProblem);
        }
        else if(isSEPlayedFinished)
        {
            isSEPlayedFinished = false;
            if(referredWord!=null)
            {
                referredWordText.color = new Color32(255,175,175,255);
            }
            mySE.PlayOneShot(BurnSE);
            Destroy(gameObject);
        }
    }
    public virtual void OnMouseDown()
    {
        yakuyaki.activeProblem = GameObject.FindGameObjectWithTag("ActiveProblem");

        if(!isClicked)
        {
            if(pointValue>0)
            {
                //play Correct particle
                PlayCorrectEffect();

                yakuyaki.UpdateScore(pointValue);
            }
            else
            {
                //play Incorrect particle
                PlayWrongEffect();
            }
            isClicked = true;
        }
        
        
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

        isSEPlayedFinished = true;
    }
}
