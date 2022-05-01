using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyLeftCounter : MonoBehaviour
{
    public TextMeshPro counterText;

    public void ChangeText(string text)
    {
        counterText.text = text;
    }
}
