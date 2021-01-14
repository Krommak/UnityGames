using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private int rateIndex;

    private GameObject gameOver;
    
    private Text applesCount, endScore, knifesRate, stage, endStage;

    private GameManager GameManager;

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameOver = GameManager.gameOver;
        applesCount = GameManager.applesCount;
        endScore = GameManager.endScore;
        stage = GameManager.stage;
        knifesRate = GameManager.knifesRate;
        endStage = GameManager.endStage;
        knifesRate.text = "0";
        applesCount.text = PlayerPrefs.GetInt("Apples").ToString();
    }

    void Update()
    {
        rateIndex = PlayerPrefs.GetInt("knifesRate");
    }

    public void knifesRateUp()
    {
        int index = PlayerPrefs.GetInt("knifesRate");
        index++;
        PlayerPrefs.SetInt("knifesRate", index);
        knifesRate.text = index.ToString();
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
        PlayerPrefs.SetInt("isLvlUp", 0);
    }
}
