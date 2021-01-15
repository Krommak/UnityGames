using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private float rotateSpeed;


    private float speedIndex = 0;
    private GameManager GameManager;
    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        rotateSpeed = GameManager.rotateSpeed;
    }

    private void Update()
    {

        if(speedIndex < rotateSpeed)
        { 
            speedIndex += 0.5f * Time.deltaTime;
        } 
        transform.Rotate(0, 0, speedIndex);
        
    }

    void FixedUpdate()
    {
        
        // switch ((index+5)%5)
        // {
        //     case 1:
        //         NormalRotator();
        //         break;
        //     case 2:
        //         StartCoroutine(WoodRotatorMod1());
        //         break;
        //     case 3:
        //         StartCoroutine(WoodRotatorMod2());
        //         break;
        //     case 4:
        //         StartCoroutine(WoodRotatorMod3());
        //         break;
        //     case 0:
        //         StartCoroutine(WoodRotatorMod4());
        //         break;
        // }
    }

    #region вращения

    #endregion
}
