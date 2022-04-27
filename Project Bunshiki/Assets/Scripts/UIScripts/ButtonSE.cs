using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSE : MonoBehaviour
{
    public AudioSource mySE;
    public AudioClip hoverSE;
    public AudioClip clickSE;

    public virtual void HoverSound()
    {
        mySE.PlayOneShot(hoverSE);
    }

    public virtual void ClickSound()
    {
        mySE.PlayOneShot(clickSE);
    }
}
