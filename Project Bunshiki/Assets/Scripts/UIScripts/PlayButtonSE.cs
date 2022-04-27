using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButtonSE : ButtonSE
{
    public Button thisButton;
    public AudioClip altClickSE;
    public override void HoverSound()
    {
        mySE.PlayOneShot(hoverSE);
    }
    
    public override void ClickSound()
    {
        if(thisButton.IsInteractable())
        {
            mySE.PlayOneShot(clickSE);
        }
        else
        {
            mySE.PlayOneShot(altClickSE);
        }
        
    }
}
