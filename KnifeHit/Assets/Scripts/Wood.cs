using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private float rotateSpeed;

    private float speedIndex = 0;
    private GameManager GameManager;

    private bool isToLeft = true;

    private int index; 

    private float rotateZ;

    private float angle = 80f;
    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        rotateSpeed = GameManager.rotateSpeed;

        index = int.Parse(GameManager.stage.text);
    }

    private void FixedUpdate()
    {
        rotateZ = transform.rotation.eulerAngles.z;
        if (isToLeft)
        {
            Rotator5left();
        }
        else 
        {
            Rotator5right();
        }
        transform.Rotate(0, 0, speedIndex);
        Debug.Log((int)angle + " " + isToLeft + " " + (int)rotateZ);
        // switch ((index+5)%5)
        // {
        //     case 1:
        //         transform.Rotate(0, 0, rotateSpeed);
        //         break;
        //     case 2:
        //         if (isToLeft)
                    // {
                    //     Rotator2left();
                    // }
                    // else 
                    // {
                    //     Rotator2right();
                    // }
                    // transform.Rotate(0, 0, speedIndex);
        //         break;
        //     case 3:
        //         if (isToLeft)
                    // {
                    //     Rotator3left();
                    // }
                    // else 
                    // {
                    //     Rotator3right();
                    // }
                    // transform.Rotate(0, 0, speedIndex);
        //         break;
        //     case 4:
        //         Rotator4();
        //         transform.Rotate(0, 0, speedIndex);
        //         break;
            // case 0:
            //     StartCoroutine(WoodRotatorMod4());
            //     break;
        // }    
    }

    #region вращения
        private void Rotator2left()
        {
            if(speedIndex < rotateSpeed)
            { 
                speedIndex += 1f * Time.deltaTime;
            }
            if(rotateZ > 180)
            {
                isToLeft = false;
            }
        }
        private void Rotator2right()
        {
            if(speedIndex > rotateSpeed * -1)
            { 
                speedIndex += -1f * Time.deltaTime;
            }
            if(rotateZ < 10)
            {
                isToLeft = true;
            }
        }

        private void Rotator3left()
        {
            if(speedIndex < rotateSpeed)
            { 
                speedIndex += 1f * Time.deltaTime;
            }
            if(rotateZ > 180)
            {
                isToLeft = false;
            }
        }
        private void Rotator3right()
        {
            if(speedIndex > (rotateSpeed-2) * -1)
            { 
                speedIndex += -1.2f * Time.deltaTime;
            }
            if(rotateZ < 30)
            {
                isToLeft = true;
            }
        }

        private void Rotator4left()
        {
            if(speedIndex < rotateSpeed)
            { 
                speedIndex += 1f * Time.deltaTime;
            }
            if(rotateZ > 60 && rotateZ < 120)
            {
                isToLeft = false;
            }
            if(rotateZ > 180 && rotateZ < 240)
            {
                isToLeft = false;
            }
            if(rotateZ > 300 && rotateZ < 360)
            {
                isToLeft = false;
            }
        }
        private void Rotator4right()
        {
            if(speedIndex > (rotateSpeed -2) * -1)
            { 
                speedIndex -= 1f * Time.deltaTime;
            }
            if(rotateZ > 0 && rotateZ < 60)
            {
                isToLeft = true;
            }
            if(rotateZ > 120 && rotateZ < 180)
            {
                isToLeft = true;
            }
            if(rotateZ > 240 && rotateZ < 300)
            {
                isToLeft = true;
            }
        }

        private void Rotator5left()
        {
            if(speedIndex < rotateSpeed)
            { 
                speedIndex += 1f * Time.deltaTime;
            }
            if(rotateZ == angle)
            {
                angle -=20;
                isToLeft = false;
                speedIndex = 0;
            }
            if(angle >= 360)
            {
                angle = 340;
            }

        }
        private void Rotator5right()
        {
            if(speedIndex > rotateSpeed * -1)
            { 
                speedIndex -= 1f * Time.deltaTime;
            }
            if(rotateZ == angle)
            {
                angle +=80;
                isToLeft = true;
                speedIndex = 0;
            }
            if(angle >= 360)
            {
                angle = 80;
            }
        }
    #endregion
}
