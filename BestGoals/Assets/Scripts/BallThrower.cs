using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    private float force;
    private GameObject ballPrefab;
    private GameObject ball;

    private Transform dotGenerate;

    private GameManager gameManager;

    public GameObject arrow;

    private GameObject ballToDestroy;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        dotGenerate = gameManager.dotGenerate.transform;
        ballPrefab = gameManager.ballPrefab;
        force = gameManager.throwForce;
        BallGenerate();
    }

    void Update()
    {

    }

    private void BallGenerate()
    {
        ball = Instantiate(ballPrefab, dotGenerate);
    }

    //удаление отработанных мячей
    IEnumerator BallToDestroy(GameObject ball)
    {
        yield return new WaitForSecondsRealtime(2f);
        Destroy(ball);
    }

    public void Tap()
    {
        if (!gameManager.GameOver)
        {
            ball.GetComponent<CircleCollider2D>().enabled = true;
            ball.GetComponent<Rigidbody2D>().gravityScale = 1f;
            ball.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(arrow.transform.position.x, arrow.transform.position.y * -1) * force, arrow.transform.position, ForceMode2D.Impulse);
            ball.transform.parent = null;
            ballToDestroy = ball;
            StartCoroutine(BallToDestroy(ballToDestroy));
            BallGenerate();
        }
    }
}