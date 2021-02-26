using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public int[] num = new int[3];

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "FeedOne")
        {
            num[0] = int.Parse(collider.gameObject.name);
        }
        if(collider.gameObject.tag == "FeedTwo")
        {
            num[1] = int.Parse(collider.gameObject.name);
        }
        if(collider.gameObject.tag == "FeedThree")
        {
            num[2] = int.Parse(collider.gameObject.name);
        }
    }
}
