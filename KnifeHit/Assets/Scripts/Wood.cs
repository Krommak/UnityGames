using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public float rotateSpeed = 1f;

    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }
}
