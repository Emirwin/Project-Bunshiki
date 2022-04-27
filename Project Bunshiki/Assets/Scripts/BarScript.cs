using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarScript : MonoBehaviour
{
    public TextMeshPro currValueText;
    public int currValue;
    public Animator animator;
    public AudioSource mySE;
    public AudioClip gainSE;

    public void InitializeBar(int number)
    {
        currValue = number;
        updateBar(0);
    }

    public void updateBar(int number)
    {
        //add sound effect
        //add vfx (change the text mesh pro color for a while)
        if(animator!=null && number < 0) {
            animator.Play("HealthBar_Damage",0,0.0f);
        }
        else if(animator!=null && number>0)
        {
            //sound effect
            mySE.PlayOneShot(gainSE);
            //animator play
            animator.Play("Gain",0,0.0f);
            
        }
        currValue += number;
        currValueText.text = $"{currValue}";
    }
}
