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

    public int rateIndex = 0;
    public GameObject gameOver;
    public Text applesCount, endScore, knifesRate, stage, endStage;

    public int lvl = 1;

    public float rotateSpeed = 1f;
    public int woodHP;

    void Start()
    {   
        if(PlayerPrefs.GetInt("isLvlUp") == 1)
        {
            stage.text = PlayerPrefs.GetInt("lvl").ToString();
            woodHP = PlayerPrefs.GetInt("woodHP");
            knifesRate.text = PlayerPrefs.GetInt("knifesRate").ToString();
        }
        else 
        {    
            stage.text = lvl.ToString();
            woodHP = 7;
        }    
    }
    void Update()
    {
        if (woodHP == 0)
            {
                PlayerPrefs.SetInt("isLvlUp", 1);
                woodHP++;
                lvl++;
                PlayerPrefs.SetInt("lvl", lvl);
                PlayerPrefs.SetInt("woodHP", woodHP);
                PlayerPrefs.SetInt("knifesRate", rateIndex);
                GameObject.Find("SceneLoader").GetComponent<SceneLoader>().SceneUpLoader();
            }
    }
            
}
