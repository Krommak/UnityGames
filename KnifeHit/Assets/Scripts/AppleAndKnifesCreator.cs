using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleAndKnifesCreator : MonoBehaviour
{
    public Transform [] dotsOfCreation;

    public GameObject applePrefab;

    public GameObject knifesPrefab;

    public int appleCreationChance = 25;

    private int knifesKreationChance = 100;
    private bool isApple = false;

    private int knifes = 0;

    private int apples = 0;

    void Start()
    {
        ObjCreation();
    }
#region рабочий но только с яблоками генератор
    private void ObjCreation()
    {
        for(int i = 0; i <= dotsOfCreation.Length - 1; i++)
        {
            Vector2 pos = dotsOfCreation[i].transform.position;
            Quaternion rot = dotsOfCreation[i].transform.rotation;
            int f = Random.Range(0, 100);

            if(f <= appleCreationChance && apples < 5)
                {
                    GameObject res = Instantiate(applePrefab, pos, rot);
                    res.transform.parent = dotsOfCreation[i].transform;
                    apples++;
                } 
        } 
    }
#endregion

#region тестовый генератор с яблоками и ножами
    // private void ObjCreation()
    // {
    //     for(int i = 0; i <= dotsOfCreation.Length - 1; i++)
    //     {
    //         bool isGenerate = Random.Range(0, 2) == 1 ? true : false;
    //         Debug.Log(isGenerate);

    //         if (isGenerate)
    //         {
    //             Vector2 pos = dotsOfCreation[i].transform.position;
    //             Quaternion rot = dotsOfCreation[i].transform.rotation;

    //             isApple = Random.Range(0, 2) == 1 ? true : false;

    //             Debug.Log(isApple);
    //             if (isApple)
    //             {
    //                 if (apples < 5) 
    //                 {
    //                     AppleCreation(dotsOfCreation[i], pos, rot);
    //                 }
    //             }
    //             else
    //             {
    //                 if (knifes < 5)
    //                 {
    //                     KnifesCreation(dotsOfCreation[i], pos, rot);
    //                 }
    //             }
    //         }
    //     }
            
    // }

    // void AppleCreation(Transform dots, Vector2 pos, Quaternion rot)
    // {
    //     int f = Random.Range(0, 100);

    //     if(f <= appleCreationChance)
    //     {
    //         GameObject res = Instantiate(applePrefab, pos, rot);
    //         res.transform.parent = dots.transform;
    //         apples++;
    //     } 
    // }

    // void KnifesCreation(Transform dots, Vector2 pos, Quaternion rot)
    // {
    //     int f = Random.Range(0, 100);

    //     rot = dots.transform.Rotate();

    //     if(f <= knifesKreationChance)
    //     {
    //         GameObject res = Instantiate(knifesPrefab, pos, rot);
    //         res.transform.parent = dots.transform;
    //         knifesKreationChance =-25;
    //         knifes++;
    //     }
    // }
    #endregion
}
