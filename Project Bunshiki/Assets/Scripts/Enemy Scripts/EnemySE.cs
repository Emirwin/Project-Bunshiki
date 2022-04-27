using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySE : MonoBehaviour
{
    public AudioSource mySE;
    public AudioClip fireSE, waterSE, windSE, defSE;

    public void PlayDamageSE(string se)
    {
        switch (se)
        {
            case "Fire":
                mySE.PlayOneShot(fireSE);
                break;
            case "Water":
                mySE.PlayOneShot(waterSE);
                break;
            case "Wind":
                mySE.PlayOneShot(windSE);
                break;
            default:
                mySE.PlayOneShot(defSE);
                break;
        }
    }
}
