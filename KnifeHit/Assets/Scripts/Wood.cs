using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    private float rotateSpeed;

    private int woodHP;

    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        woodHP = GameManager.woodHP;
    }

    private void Update()
    {
        rotateSpeed = GameManager.rotateSpeed;
    }

    private GameManager GameManager;

    void FixedUpdate()
    {
        switch (GameManager.stage.text)
        {
            case "1":
                NormalRotator();
                break;
            case "2":
                StartCoroutine(WoodRotatorMod1());
                break;
            case "3":
                StartCoroutine(WoodRotatorMod2());
                break;
            case "4":
                StartCoroutine(WoodRotatorMod3());
                break;
            case "5":
                StartCoroutine(WoodRotatorMod4());
                break;
        }
    }

    #region вращения
    private void NormalRotator()
    {
        transform.Rotate(0, 0, rotateSpeed);
    }

    IEnumerator WoodRotatorMod1()
    {
        transform.Rotate(0, 0, rotateSpeed);
        yield return new WaitForSecondsRealtime(5);
        transform.Rotate(0, 0, 0);
        yield return new WaitForSecondsRealtime(1);
        transform.Rotate(0, 0, rotateSpeed);
    }
    
    IEnumerator WoodRotatorMod2()
    {   
        transform.Rotate(0, 0, rotateSpeed * -1);
        yield return new WaitForSecondsRealtime(3);
        transform.Rotate(0, 0, rotateSpeed * 0.5f);
        yield return new WaitForSecondsRealtime(2);
        transform.Rotate(0, 0, rotateSpeed * -1);
        yield return new WaitForSecondsRealtime(3);
    }

    IEnumerator WoodRotatorMod3()
    {   
        int sec = Random.Range(0, 4);
        transform.Rotate(0, 0, rotateSpeed * -1);
        yield return new WaitForSecondsRealtime(3);
        transform.Rotate(0, 0, rotateSpeed * 0.5f);
        yield return new WaitForSecondsRealtime(2);
        transform.Rotate(0, 0, rotateSpeed * -1);
        yield return new WaitForSecondsRealtime(3);
    }
    IEnumerator WoodRotatorMod4()
    {   
        int sec = Random.Range(0, 4);
        float speed = Random.Range(0.0f, 3.0f);
        transform.Rotate(0, 0, speed * -1);
        yield return new WaitForSecondsRealtime(sec);
        transform.Rotate(0, 0, speed * 0.5f);
        yield return new WaitForSecondsRealtime(sec);
        transform.Rotate(0, 0, speed * -1);
        yield return new WaitForSecondsRealtime(sec);
    }
    #endregion
}
