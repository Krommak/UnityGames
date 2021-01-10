using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Rigidbody2D knifeRB;

    public float rubber = 1f;

    public PhysicsMaterial2D rubberMath;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        rubberMath = new PhysicsMaterial2D();
        rubberMath.bounciness = rubber;
        Debug.Log(collider.tag);
        if(collider.gameObject.tag == "Wood" && knifeRB.gameObject.tag == "Knife")
        {
            knifeRB.velocity = Vector2.zero;
            transform.parent = collider.transform;
            knifeRB.gameObject.tag = "KnifeInWood";
            knifeRB.sharedMaterial = rubberMath;
            knifeRB.gameObject.GetComponent<BoxCollider2D>().sharedMaterial = rubberMath;
            knifeRB.constraints = RigidbodyConstraints2D.FreezeAll;
            knifeRB.gravityScale = 1;
        }

        if(collider.gameObject.tag == "KnifeInWood")
        {
            knifeRB.gameObject.tag = "ReflectKnife";
        }

        if(collider.gameObject.tag == "Apple")
        {
            Destroy(collider.gameObject);
        }
    }
    // private void OnTriggerEnter(Collider2D collider)
    // {
    //     Debug.Log(collider.tag);
    //     if(collider.gameObject.tag == "KnifeInWood")
    //     {
    //         knifeRB.gameObject.tag = "ReflectKnife";
    //     }
    // }
}
