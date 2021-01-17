using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private float rotateSpeed;

    private float speedIndex = 0;
    private GameManager GameManager;

    private int isRotate = 1;

    private float timeToLeft, timeToRight, timeToStop;

    private int stage;

    private float angleZ;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        rotateSpeed = GameManager.rotateSpeed;
        stage = int.Parse(GameManager.stage.text);
        switch(stage%5)
        {
            case 1:
                break;
            case 2:
                timeToLeft = GameManager.timeToLeft2;
                timeToStop = GameManager.timeToStop2;
                timeToRight = GameManager.timeToRight2;
                break;
            case 3:          
                timeToLeft = GameManager.timeToLeft3;
                timeToStop = GameManager.timeToStop3;
                timeToRight = GameManager.timeToRight3;
                break;
            case 4:
                timeToLeft = GameManager.timeToLeft4;
                timeToStop = GameManager.timeToStop4;
                timeToRight = GameManager.timeToRight4;
                break;
            case 5:
                timeToLeft = GameManager.timeToLeft5;
                timeToStop = GameManager.timeToStop5;
                timeToRight = GameManager.timeToRight5;
                break;
        }
    }

    private void Update()
    {
        if(speedIndex<rotateSpeed)
        {
            speedIndex+=Time.deltaTime;
        }
        switch(stage%5)
        {
            case 1:
                transform.Rotate(0, 0, rotateSpeed);
                break;
            case 2:                
                switch(isRotate)
                {    
                    case 1:
                        if(timeToLeft > 0)
                        {
                        transform.Rotate(0, 0, speedIndex);
                        timeToLeft-=Time.deltaTime;
                            if(timeToLeft <= 0)
                            {
                                isRotate=2;
                                timeToRight = GameManager.timeToRight2;
                            }
                        }
                        break;
                    case 2:
                        if(timeToStop >= 0)
                        {
                        transform.Rotate(0, 0, speedIndex * 0.1f);
                        timeToStop-=Time.deltaTime;
                            if(timeToStop <= 0)
                            {
                                isRotate=3;
                                timeToLeft = GameManager.timeToLeft2;
                            }
                        }
                        break;
                    case 3:
                        if(timeToRight > 0)
                        {
                        transform.Rotate(0, 0, speedIndex * -1);
                        timeToRight-=Time.deltaTime;
                            if(timeToRight <= 0)
                            {
                                isRotate=1;
                                timeToStop = GameManager.timeToStop2;
                            }
                        }
                        break;
                }
                break;
            case 3:
                switch(isRotate)
                {    
                    case 1:
                        if(timeToLeft > 0)
                        {
                        transform.Rotate(0, 0, speedIndex);
                        timeToLeft-=Time.deltaTime;
                            if(timeToLeft <= 0)
                            {
                                isRotate=2;
                                timeToRight = GameManager.timeToRight3;
                            }
                        }
                        break;
                    case 2:
                        if(timeToStop >= 0)
                        {
                        transform.Rotate(0, 0, speedIndex * 0.1f);
                        timeToStop-=Time.deltaTime;
                            if(timeToStop <= 0)
                            {
                                isRotate=3;
                                timeToLeft = GameManager.timeToLeft3;
                            }
                        }
                        break;
                    case 3:
                        if(timeToRight > 0)
                        {
                        transform.Rotate(0, 0, speedIndex * -1);
                        timeToRight-=Time.deltaTime;
                            if(timeToRight <= 0)
                            {
                                isRotate=1;
                                timeToStop = GameManager.timeToStop3;
                            }
                        }
                        break;
                }
                break;
            case 4:
                switch(isRotate)
                {    
                    case 1:
                        if(timeToLeft > 0)
                        {
                        transform.Rotate(0, 0, speedIndex);
                        timeToLeft-=Time.deltaTime;
                            if(timeToLeft <= 0)
                            {
                                isRotate=2;
                                timeToRight = GameManager.timeToRight4;
                            }
                        }
                        break;
                    case 2:
                        if(timeToStop >= 0)
                        {
                        transform.Rotate(0, 0, speedIndex * 0.1f);
                        timeToStop-=Time.deltaTime;
                            if(timeToStop <= 0)
                            {
                                isRotate=3;
                                timeToLeft = GameManager.timeToLeft4;
                            }
                        }
                        break;
                    case 3:
                        if(timeToRight > 0)
                        {
                        transform.Rotate(0, 0, speedIndex * -1);
                        timeToRight-=Time.deltaTime;
                            if(timeToRight <= 0)
                            {
                                isRotate=1;
                                timeToStop = GameManager.timeToStop4;
                            }
                        }
                        break;
                }
                break;
            case 0:
                switch(isRotate)
                {    
                    case 1:
                        if(timeToLeft > 0)
                        {
                        transform.Rotate(0, 0, speedIndex);
                        timeToLeft-=Time.deltaTime;
                            if(timeToLeft <= 0)
                            {
                                isRotate=2;
                                timeToRight = GameManager.timeToRight5;
                            }
                        }
                        break;
                    case 2:
                        if(timeToStop >= 0)
                        {
                        transform.Rotate(0, 0, speedIndex * 0.1f);
                        timeToStop-=Time.deltaTime;
                            if(timeToStop <= 0)
                            {
                                isRotate=3;
                                timeToLeft = GameManager.timeToLeft5;
                            }
                        }
                        break;
                    case 3:
                        if(timeToRight > 0)
                        {
                        transform.Rotate(0, 0, speedIndex * -1);
                        timeToRight-=Time.deltaTime;
                            if(timeToRight <= 0)
                            {
                                isRotate=1;
                                timeToStop = GameManager.timeToStop5;
                            }
                        }
                        break;
                }
                break;
        }
    }

    #region вращения
              
    #endregion
}
