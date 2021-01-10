using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text scoreText;
    public Text endScore, bestScore;
    public Transform player;

    private float nowScore;
    private float nextScore;

    private int score = 0;



    void Update()
    {

        nextScore = player.position.y - 3.42f;
        
        if(nextScore > nowScore)
        {
            scoreText.text = "Высота: " + Mathf.Floor(nextScore).ToString() + "м";
            endScore.text = scoreText.text;
            nowScore = nextScore;
            score = (int)nowScore;
        }
        if (score > PlayerPrefs.GetInt("Score"))
        {
            PlayerPrefs.SetInt("Score", score);
            bestScore.text= "Новый рекорд: " + score.ToString();
        }
        else
        {
            bestScore.text = "Рекорд: " + PlayerPrefs.GetInt("Score");
        }
    }

}
