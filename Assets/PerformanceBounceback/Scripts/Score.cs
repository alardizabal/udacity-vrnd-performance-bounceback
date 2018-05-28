using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameManager gameManager;
    public Text text;
    private int previousScore;

    void Update()
    {
        if (previousScore != gameManager.score) ChangeScore();
    }

    private void ChangeScore()
    {
        previousScore = gameManager.score;
        text.text = "Score: " + gameManager.score.ToString();
    }
}
