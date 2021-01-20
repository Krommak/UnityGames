using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private int rateIndex;

    private GameObject gameOver;
    
    private Text applesCount, endScore, knifesRate, stage, endStage, restApples;

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
        restApples = GameManager.restApples;
        knifesRate.text = PlayerPrefs.GetInt("Score").ToString();
        applesCount.text = PlayerPrefs.GetInt("Apples").ToString();
        stage.text = PlayerPrefs.GetInt("Stage").ToString();
        restApples.text = PlayerPrefs.GetInt("Apples").ToString();
    }

    void Update()
    {

    }

    public void knifesRateUp()
    {
        int index = PlayerPrefs.GetInt("Score");
        ++index;
        PlayerPrefs.SetInt("Score", index);
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
        if(int.Parse(endScore.text) > PlayerPrefs.GetInt("GreateScore"))
        {
            PlayerPrefs.SetInt("GreateScore", int.Parse(endScore.text));
        }
        if(int.Parse(stage.text) > PlayerPrefs.GetInt("GreateStage"))
        {
            PlayerPrefs.SetInt("GreateStage", int.Parse(stage.text));
        }
        
    }
}
