using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrower : MonoBehaviour
{
    public float force = 1f;
    public GameObject knifePrefab;
    private GameObject knife;

    void Start ()
    {
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
