using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Text greatScoreRestart;

    private GameObject restart;

    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        greatScoreRestart = gameManager.greatScoreRestart;
        restart = gameManager.restart;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "danger")
        {
            StartCoroutine(GameOver());
            GetComponent<CircleCollider2D>().enabled = false;
        }

        if (collision.gameObject.tag == "purpose")
        {
            GetComponent<CircleCollider2D>().enabled = false;
            gameManager.CheckScore(1);
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        gameManager.GameOver = true;
        restart.SetActive(true);
    }
}
