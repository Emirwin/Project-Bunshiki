using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarScript : MonoBehaviour
{
    public TextMeshPro currHealthValue;
    public int currHealth;
    // Start is called before the first frame update
    public void InitializeBar(int number)
    {
        currHealth = number;
        updateBar(0);
    }

    public void updateBar(int number)
    {
        currHealth += number;
        currHealthValue.text = $"{currHealth}";
    }
}
