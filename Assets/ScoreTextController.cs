using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreTextController : MonoBehaviour {

    private int score = 0;
    private Text scoreText;
	void Awake () {
        scoreText = GetComponent<Text>();
	}
	
	
	void Update () {
		
	}

    public void IncreaseScore() //call from TubeMove class
    {
        this.score++;
        ScoreText();
    }
    private void ScoreText()
    {
        this.scoreText.text = score.ToString();
    }
}
