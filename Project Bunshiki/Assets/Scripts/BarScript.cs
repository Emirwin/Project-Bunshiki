using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarScript : MonoBehaviour
{
    public TextMeshPro currValueText;
    public int currValue;
    // Start is called before the first frame update
    public void InitializeBar(int number)
    {
        currValue = number;
        updateBar(0);
    }

    public void updateBar(int number)
    {
        currValue += number;
        currValueText.text = $"{currValue}";
    }
}
