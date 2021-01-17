using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    public float rSpeed;
    void Update()
    {
        transform.Rotate(0,0,rSpeed);
    }
}
