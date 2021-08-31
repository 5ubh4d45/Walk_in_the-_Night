using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text scoreText;
    //public Text highScoreTExt;

    private int score = 0;
    //private int highscore = 0;

    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        scoreText.text = "SCORE: " + score.ToString();
        //highScoreTExt.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddScore(){
        score+=100;
        scoreText.text= "SCORE: " + score.ToString();
    }

}
