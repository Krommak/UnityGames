using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text score, greatScore, restartGreatScore, stopGreatScore;
    
    public Transform player;

    public GameObject startCounter, gameOverPanel, menuPanel, stopPanel;
    private GameManager GameManager;

    private float playerSpeed;

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(PlayerPrefs.GetInt("Restart") == 1)
        {
            StartGame();
        }

        score.text = "SCORE: " + 0;
        greatScore.text = "BESTSCORE: " + PlayerPrefs.GetInt("BestScore");
        stopGreatScore.text = "BESTSCORE: " + PlayerPrefs.GetInt("BestScore");
    }
    void Update()
    {
        score.text = "SCORE: " + ((int)player.position.z + 7);
    }

    public void StartGame()
    {
        StartCoroutine(StarterGame());
    }
    private IEnumerator StarterGame()
    {
        player.gameObject.SetActive(true);
        menuPanel.SetActive(false);
        startCounter.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        Destroy(startCounter);
        GameManager.isStart = true;
    }

    public void BackToMenu()
    {
        playerSpeed = player.gameObject.GetComponent<Animator>().speed;
        player.gameObject.GetComponent<Animator>().speed = 0;
        stopPanel.SetActive(true);
    }
    public void ResumeGame()
    {
        stopPanel.SetActive(false);
        player.gameObject.GetComponent<Animator>().speed = playerSpeed;
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCor());
    }

    IEnumerator GameOverCor()
    {
        yield return new WaitForSecondsRealtime(1f);
        gameOverPanel.SetActive(true);
        if((int)player.position.z + 7 > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", (int)player.position.z + 7);
        }
        restartGreatScore.text = "BESTSCORE: " + PlayerPrefs.GetInt("BestScore");
    }

    public void Restart(string name)
    {
        SceneManager.LoadScene(name);
        PlayerPrefs.SetInt("Restart", 1);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Restart", 0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
