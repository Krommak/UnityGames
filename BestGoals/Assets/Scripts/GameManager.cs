using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject dotGenerate;

    public float rotateSpeed;

    public float throwForce = 1f;
    public GameObject ballPrefab;

    public GameObject goalkeeper;

    public float goalkeeperSpeed;

    private bool goalkeeperLeft;

    private float dotGenerateAngle;

    private bool ballToLeft = true;

    public Text scoreText, greatScoreMenu, greatScoreRestart;

    public GameObject menu, restart;

    public bool GameOver = true;

    private int score;

    private int greateScore;

    public GameObject audioObj, soundOff, soundOn;

    void Start()
    {
        //направление движение вратаря
        goalkeeperLeft = Random.Range(0, 2) == 0 ? false : true;
        StartSound();
        greateScore = PlayerPrefs.GetInt("greateScore");
        greatScoreMenu.text = "BESTSCORE " + greateScore;
    }
    private void StartSound()
    {
        bool sound = PlayerPrefs.GetInt("Sound") == 1 ? false : true;
        audioObj.SetActive(sound);
        soundOff.SetActive(sound);
        soundOn.SetActive(!sound);
    }
    public void SetSound(int a)
    {
        PlayerPrefs.SetInt("Sound", a);
        soundOff.SetActive(!soundOff.activeSelf);
        soundOn.SetActive(!soundOff.activeSelf);
        audioObj.SetActive(soundOff.activeSelf);
    }

    void FixedUpdate()
    {
        //поворот мяча
        if (ballToLeft && !GameOver)
        {
            dotGenerate.transform.Rotate(0, 0, rotateSpeed);
            if (dotGenerate.transform.rotation.eulerAngles.z >= 20 && dotGenerate.transform.rotation.eulerAngles.z < 320)
            {
                ballToLeft = false;
            }
        }
        else if (!ballToLeft && !GameOver)
        {
            dotGenerate.transform.Rotate(0, 0, rotateSpeed * -1);
            if (dotGenerate.transform.rotation.eulerAngles.z <= 340 && dotGenerate.transform.rotation.eulerAngles.z > 40)
            {
                ballToLeft = true;
            }
        }

        //движение вратаря
        if (goalkeeperLeft && !GameOver)
        {
            goalkeeper.transform.Translate(Vector2.left * goalkeeperSpeed);
            if (goalkeeper.transform.position.x <= -1.25)
            {
                goalkeeperLeft = false;
            }
        }
        else if (!goalkeeperLeft && !GameOver)
        {
            goalkeeper.transform.Translate(-Vector2.left * goalkeeperSpeed);
            if (goalkeeper.transform.position.x >= 1.25)
            {
                goalkeeperLeft = true;
            }
        }
    }

    public void CheckScore(int index)
    {
        score = PlayerPrefs.GetInt("Score");
        score += index;
        scoreText.text = "SCORE " + score;
        PlayerPrefs.SetInt("Score", score);
        
        if (score > PlayerPrefs.GetInt("greateScore"))
        {
            PlayerPrefs.SetInt("greateScore", score);
        }
        greateScore = PlayerPrefs.GetInt("greateScore");
        greatScoreMenu.text = "BESTSCORE " + greateScore;
        greatScoreRestart.text = "BESTSCORE " + greateScore;
    }
}
