using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Rigidbody2D knifeRB;

    private float rubber;

    private PhysicsMaterial2D rubberMath;

    private UI canvas;

    private GameManager GameManager;

    private bool enabledWood = true;

    public GameObject particleWood, particleKnife, particleApple;

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rubberMath = GameManager.rubberMath;
        rubber = GameManager.rubber;
        canvas = GameObject.Find("Canvas").GetComponent<UI>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "KnifeInWood")
        {
            particleKnife.SetActive(true);
            GameManager.isGameOver = true;
            enabledWood = false;
            knifeRB.gameObject.tag = "ReflectKnife";
            StartCoroutine(EndTime());
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        rubberMath = new PhysicsMaterial2D();
        rubberMath.bounciness = rubber;
        if(knifeRB.gameObject.tag == "Knife" && collider.gameObject.tag == "Wood" && enabledWood)
        {
            particleWood.SetActive(true);
            knifeRB.velocity = Vector2.zero;
            transform.parent = collider.transform;
            knifeRB.gameObject.tag = "KnifeInWood";
            knifeRB.sharedMaterial = rubberMath;
            knifeRB.gameObject.GetComponent<PolygonCollider2D>().sharedMaterial = rubberMath;
            knifeRB.constraints = RigidbodyConstraints2D.FreezeAll;
            canvas.knifesRateUp();
            GameManager.throwing++;
        }

        if(collider.gameObject.tag == "Apple")
        {
            particleApple.SetActive(true);
            StopCoroutine(AppleDestroy(collider));
            canvas.applesUp();
            collider.gameObject.transform.parent = null;
            collider.gameObject.GetComponent<Animator>().enabled = true;
            collider.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }
    IEnumerator AppleDestroy(Collider2D collider)
    {
        yield return new WaitForSeconds(1f);
        Destroy(collider.gameObject);
    }

    IEnumerator EndTime()
    {
        GameManager.rotateSpeed = 0f;
        yield return new WaitForSeconds(1f);
        GameManager.gameOver.SetActive(true);
        canvas.GameOverUI();
    }
}
