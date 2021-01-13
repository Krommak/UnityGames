using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Rigidbody2D knifeRB;

    public float rubber = 1f;

    public PhysicsMaterial2D rubberMath;

    private UI canvas;

    void Start()
    {
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
            canvas.rateIndex++;
            canvas.knifesRateUp();
            if (canvas.rateIndex == GameObject.Find("Wood").GetComponent<Wood>().woodHP)
            {
                GameObject.Find("Wood").GetComponent<Wood>().woodHP++;
                PlayerPrefs.SetInt("WoodHP", GameObject.Find("Wood").GetComponent<Wood>().woodHP);
                GameObject.Find("SceneLoader").GetComponent<SceneLoader>().SceneUpLoader();
            }
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
        yield return new WaitForSeconds(0.5f);
        canvas.gameOver.SetActive(true);
        GameObject.Find("Wood").GetComponent<Wood>().rotateSpeed = 0f;
        canvas.GameOverUI();
    }
}
