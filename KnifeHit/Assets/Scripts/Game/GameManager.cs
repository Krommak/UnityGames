using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Transform [] dotsOfCreation;
    public int appleCreationChance = 25;
    public GameObject applePrefab;
    public GameObject knifeGenPrefab;

    public PhysicsMaterial2D rubberMath;
    public float rubber = 1f;

    public GameObject knifeTilePrefab;

    public float force = 2f;
    public GameObject knifePrefab;

    public GameObject gameOver;
    public Text applesCount, endScore, knifesRate, stage, endStage;

    public float rotateSpeed = 1f;
    public int woodHP;

    public int throwing;

    public bool isGameOver = false;
    
    [Header ("Настройки движения для второго уровня")]
    public float timeToRight2, timeToLeft2, timeToStop2;

    
    [Header ("Настройки движения для третьего уровня")]
    public float timeToRight3, timeToLeft3, timeToStop3;

    
    [Header ("Настройки движения для четвёртого уровня")]
    public float timeToRight4, timeToLeft4, timeToStop4;

    
    [Header ("Настройки движения для пятого уровня")]
    public float timeToRight5, timeToLeft5, timeToStop5;

    void Start()
    {   
        if(PlayerPrefs.GetInt("Stage") == 0)
        {
            PlayerPrefs.SetInt("Stage", 1);
            PlayerPrefs.SetInt("WoodHP", 7);
        }
        woodHP = PlayerPrefs.GetInt("WoodHP");
    }
    void Update()
    {
        if (throwing == woodHP)
        {
            StageUp();
        }
    }

    void StageUp()
    {
        int index = PlayerPrefs.GetInt("Stage");
        index++;
        PlayerPrefs.SetInt("Stage", index);
        int woodHP = PlayerPrefs.GetInt("WoodHP");
        woodHP++;
        PlayerPrefs.SetInt("WoodHP", woodHP);
        GameObject.Find("SceneLoader").GetComponent<SceneLoader>().SceneUpLoader();
    }
            
}
