using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrower : MonoBehaviour
{
    private float force = 1f;
    private GameObject knifePrefab;
    private GameObject knife;

    private GameManager GameManager;

    void Start ()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        force = GameManager.force;
        knifePrefab = GameManager.knifePrefab;
        KnifeGenerate();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
             knife.GetComponent<BoxCollider2D>().enabled = true;
             knife.transform.parent = null;
             knife.GetComponent<Rigidbody2D>().gravityScale = 1f;
             knife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
             KnifeGenerate();
        }
    }

    private void KnifeGenerate()
    {
        knife = Instantiate(knifePrefab, transform);
    }
}
