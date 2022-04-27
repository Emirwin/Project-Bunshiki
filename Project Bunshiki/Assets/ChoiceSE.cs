using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceSE : MonoBehaviour
{
    public AudioSource mySE;
    public AudioClip CorrectSE;
    public AudioClip WrongSE;
    public GameObject CorrectSymbol;
    public GameObject WrongSymbol;

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
        
        Destroy(gameObject);
    }
}
