using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private GameManager gameManager;

    private Text greatScoreMenu;
    private GameObject restart, menu;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        greatScoreMenu = gameManager.greatScoreMenu;
        restart = gameManager.restart;
        menu = gameManager.menu;
    }

    public void StartGame()
    {
        menu.SetActive(false);
        StartCoroutine(DelayStartGame());
    }

    public void RestartGame()
    {
        restart.SetActive(false);
        PlayerPrefs.SetInt("Score", 0);
        gameManager.CheckScore(0);
        StartCoroutine(DelayStartGame());
    }

    public void BackToMenu()
    {
        menu.SetActive(true);
        gameManager.GameOver = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator DelayStartGame()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        gameManager.GameOver = false;
    }
}
