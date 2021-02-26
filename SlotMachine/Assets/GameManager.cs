using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText, bestScoreText;

    public GameObject menuPanel, soundOff, soundOn, megaWin;

    public GameObject audioObj, indicatorGO;

    private Indicator indicator;

    private int score, bestScore;

    private int [] speed = new int[3];

    private float [] distance = new float[3];

    private int index;

    private int[] numbers = new int[3];

    private bool isMove = false;

    [SerializeField] private Transform [] feeds;
    private Rigidbody2D [] feedsRB = new Rigidbody2D[3];
    
    private Vector3 [] feedsPos = new Vector3[3];

    private float [] coefficients = new float[4];

    void Awake()
    {
        if(Screen.height/Screen.width == 18/9)
        {
            coefficients[0] = 1.5f;
            coefficients[1] = 2.4f;
            coefficients[2] = 0.1f;
            coefficients[3] = 9.5f;
        }
        if (Screen.height/Screen.width == 13/6 || Screen.height/Screen.width == 214/99)
        {
            coefficients[0] = 1.42f;
            coefficients[1] = 2.1f;
            coefficients[2] = 0.05f;
            coefficients[3] = 8.4f;
        }
        else
        {
            coefficients[0] = 1.4f;
            coefficients[1] = 2.5f;
            coefficients[2] = 0.0f;
            coefficients[3] = 10f;
        }
    }

    void Start()
    {
        Debug.Log(Screen.height + " " + Screen.width);
        score = PlayerPrefs.GetInt("Score");
        if (score == 0)
        {
            scoreText.text = "5000";
        }
        else {
            scoreText.text = score.ToString();
        }
        
        bestScoreText.text = PlayerPrefs.GetInt("BestScore").ToString();
        StartSound();
        for(int i = 0; i < feedsRB.Length; i++)
        {
            feedsRB[i] = feeds[i].gameObject.GetComponent<Rigidbody2D>();
        }
        for(int i = 0; i < feeds.Length; i++)
        {
            feedsPos[i] = feeds[i].position;            
        }
        foreach(Transform feed in feeds)
        {
            feed.localScale = new Vector3(feed.localScale.x, coefficients[0], feed.localScale.z);
            feed.transform.position = new Vector3(feed.position.x, coefficients[3], feed.position.z);
        }
        indicator = indicatorGO.GetComponent<Indicator>();

    }

    void FixedUpdate()
    {
        if(feeds[0].position.y < distance[0])
        {
            feedsRB[0].velocity = Vector2.zero;
            feeds[0].position = new Vector3 (feedsPos[0].x, distance[0]+coefficients[2], feedsPos[0].z);
            // Debug.Log(distance[0] + " feed1 " + feeds[0].position);
        }
        if(feeds[1].position.y < distance[1])
        {
            feedsRB[1].velocity = Vector2.zero;
            feeds[1].position = new Vector3 (feedsPos[1].x, distance[1]+coefficients[2], feedsPos[1].z);
            // Debug.Log(distance[1] + " feed2 " + feeds[1].position);
        }
        if(feeds[2].position.y < distance[2])
        {
            feedsRB[2].velocity = Vector2.zero;
            feeds[2].position = new Vector3 (feedsPos[2].x, distance[2]+coefficients[2], feedsPos[2].z);
            // Debug.Log(distance[2] + " feed3 " + feeds[2].position);
        }
        if(feedsRB[0].IsSleeping() && feedsRB[1].IsSleeping() && feedsRB[2].IsSleeping() && isMove)
        {
            CheckScore();
        }
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

    public void Click()
    {
        if(!isMove)
        {
            for(int i = 0; i < feeds.Length; i++)
            {
                feeds[i].position = feedsPos[i];
            }
            for(int i = 0; i < distance.Length; i++)
            {
                index = Random.Range(-3, 3);
                distance[i] = index*coefficients[1];
            }
            for(int i = 0; i < speed.Length; i++)
            {
                index = Random.Range(-5, -15);
                speed[i] = index;    
            }
            for(int i = 0; i < feedsRB.Length; i++)
            {
                feedsRB[i].AddForce(new Vector3(0, speed[i], 0), ForceMode2D.Impulse);
            }
            isMove = true;
        }
    }

    void CheckScore()
    {
        score = int.Parse(scoreText.text);
        bestScore = int.Parse(bestScoreText.text);
        numbers = indicator.num;

        if(numbers[0] == numbers[1] && numbers[0] == numbers[2])
        {
            score +=1000;
            StartCoroutine(Win());
        }
        else if(numbers[0] == numbers[1] && numbers[0] != numbers[2] || numbers[1] == numbers[2] && numbers[0] != numbers[1])
        {
            score +=50;
        }
        else
        {
            score -=200;
        }
        if(score>bestScore)
        {
            bestScoreText.text = score.ToString();
            PlayerPrefs.SetInt("BestScore", score);
        }
        scoreText.text = score.ToString();
        isMove = false;
    }

    private IEnumerator Win()
    {
        megaWin.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        megaWin.SetActive(false);
    }

    public void GamePlay()
    {
        menuPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        menuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}