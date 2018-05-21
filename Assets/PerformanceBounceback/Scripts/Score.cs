using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public GameManager gameManager;
    public Text text;

	void Update () {
        text.text = "Score: " + gameManager.score.ToString();
	}
}
