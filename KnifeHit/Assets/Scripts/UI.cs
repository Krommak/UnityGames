using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public int rateIndex = 0;

    public GameObject gameOver;
    
    public Text applesCount, endScore, knifesRate, stage, endStage;

    void Start()
    {
        knifesRateUp();
        applesCount.text = PlayerPrefs.GetInt("Apples").ToString();
    }

    public void knifesRateUp()
    {
        knifesRate.text = rateIndex + "";
    }

    public void applesUp()
    {
        int index = PlayerPrefs.GetInt("Apples");
        index+=2;
        PlayerPrefs.SetInt("Apples", index);
        applesCount.text = index.ToString();
    }

    public void GameOverUI()
    {
        endScore.text = knifesRate.text;
        endStage.text = "Stage " + stage.text;
    }
}
