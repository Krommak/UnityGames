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

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rubberMath = GameManager.rubberMath;
        rubber = GameManager.rubber;
        canvas = GameObject.Find("Canvas").GetComponent<UI>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        rubberMath = new PhysicsMaterial2D();
        rubberMath.bounciness = rubber;
        if(collider.gameObject.tag == "Wood" && knifeRB.gameObject.tag == "Knife")
        {
            knifeRB.velocity = Vector2.zero;
            transform.parent = collider.transform;
            knifeRB.gameObject.tag = "KnifeInWood";
            knifeRB.sharedMaterial = rubberMath;
            knifeRB.gameObject.GetComponent<BoxCollider2D>().sharedMaterial = rubberMath;
            knifeRB.constraints = RigidbodyConstraints2D.FreezeAll;
            --GameManager.woodHP;
            canvas.knifesRateUp();
        }

        if(collider.gameObject.tag == "Apple")
        {
            canvas.applesUp();
            Destroy(collider.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "KnifeInWood")
        {
            knifeRB.gameObject.tag = "ReflectKnife";
            StartCoroutine(EndTime());
        }
    }
    
    IEnumerator EndTime()
    {
        GameManager.rotateSpeed = 0f;
        yield return new WaitForSeconds(0.5f);
        GameManager.gameOver.SetActive(true);
        canvas.GameOverUI();
    }
}
