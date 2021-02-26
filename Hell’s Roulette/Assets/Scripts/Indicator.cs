using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public int number;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        number = int.Parse(collider.gameObject.name);
    }
}
