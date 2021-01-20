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
    public Text applesCount, endScore, knifesRate, stage, endStage, restApples;

    public float rotateSpeed = 1f;
    public int woodHP;

    public int throwing;

    public bool isGameOver = false;

    private bool isWoodDestroyed = false;
    
    [Header ("Настройки движения для второго уровня")]
    public float timeToRight2, timeToLeft2, timeToStop2;

    
    [Header ("Настройки движения для третьего уровня")]
    public float timeToRight3, timeToLeft3, timeToStop3;

    
    [Header ("Настройки движения для четвёртого уровня")]
    public float timeToRight4, timeToLeft4, timeToStop4;

    
    [Header ("Настройки движения для пятого уровня")]
    public float timeToRight5, timeToLeft5, timeToStop5;

    public GameObject destroyWoodPrefab;
    private bool isVibr = false;

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
        if (throwing == woodHP && !isGameOver)
        {
            if(!isWoodDestroyed)
            {
                StartCoroutine(Victory());
                WoodDestroy();
                Invoke("StageUp", 1f);
            }
        }
        if(isVibr)
        {
            Handheld.Vibrate();
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

    void WoodDestroy()
    {
        GameObject wood = GameObject.Find("Wood");
        List<Transform> woodChild = new List<Transform>(); 

        for (int i = 0; i < wood.transform.childCount; i++)
        {
            Transform childTransform = wood.transform.GetChild(i);
            if(childTransform.gameObject.tag == "BlockedGenDot" || childTransform.gameObject.tag == "KnifeInWood")
            {
                woodChild.Add(childTransform);
            }
            if(childTransform.Find("KnifeForGen(Clone)"))
            {
                GameObject knife = childTransform.Find("KnifeForGen(Clone)").gameObject;
                wood.GetComponent<AppleAndKnifesCreator>().FreeKnifes(knife);
            }
        }
        for (int i = 1; i < woodChild.Count; i++)
        {
            woodChild[i].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            woodChild[i].transform.parent = null;
            woodChild[i].GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * 20f, ForceMode2D.Impulse);
        }
        Destroy(wood);
        Instantiate(destroyWoodPrefab, new Vector3(-0.091f, 0.016f, 0f), Quaternion.identity);
        isWoodDestroyed = true;
    }

    public IEnumerator Victory()
    {
        for(int i = 0; i <= 2; i++)
        {
            isVibr = true;
            yield return new WaitForSecondsRealtime(0.2f);
            isVibr = false;
            yield return new WaitForSecondsRealtime(0.3f);
        }
    } 

    public IEnumerator HitInWood()
    {
        isVibr = true;
        yield return new WaitForSecondsRealtime(0.2f);
        isVibr = false;
    }

    public IEnumerator HitInKnifes()
    {
        isVibr = true;
        yield return new WaitForSecondsRealtime(0.8f);
        isVibr = false;
    }  
}
