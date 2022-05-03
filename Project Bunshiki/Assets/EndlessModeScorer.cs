using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndlessModeScorer : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        scoreText.text = $"{gameManager.score}";
    }
}
