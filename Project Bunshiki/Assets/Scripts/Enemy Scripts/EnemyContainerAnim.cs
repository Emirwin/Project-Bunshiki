using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainerAnim : MonoBehaviour
{
    public Animator containerAnimator;

    public void PlayDamageAnim(string damageElement)
    {
        containerAnimator.Play("Damage"+damageElement,0,0.0f);
    }
}
