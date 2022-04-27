using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    public Animator enemyAnimator;
    public string damageName;

    public void PlayDamageAnim()
    {
        enemyAnimator.Play(damageName,0,0.0f);
    }
}
