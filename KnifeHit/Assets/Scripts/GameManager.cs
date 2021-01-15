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
