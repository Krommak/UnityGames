using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleAndKnifesCreator : MonoBehaviour
{
    private GameManager GameManager;
    private Transform [] dotsOfCreation;

    private GameObject applePrefab;

    private GameObject knifeGenPrefab;

    private int appleCreationChance;

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        dotsOfCreation = GameManager.dotsOfCreation;
        appleCreationChance = GameManager.appleCreationChance;
        applePrefab = GameManager.applePrefab;
        knifeGenPrefab = GameManager.knifeGenPrefab;
        ObjCreation();
    }

#region тестовый генератор с яблоками и ножами

    private void ObjCreation()
    {
        KnifesGen();
        AppleGen();
    }

    private void KnifesGen()
    {
        int quant = Random.Range(1, 4);
        for (int i = 0; i < quant; i++)
        {
            int randomDot = Random.Range(0, dotsOfCreation.Length);

            if(dotsOfCreation[randomDot].gameObject.tag != "BlockedGenDot")
            {
                Vector2 pos = dotsOfCreation[randomDot].transform.position;
                Quaternion rot = dotsOfCreation[randomDot].transform.rotation;
                GameObject res = Instantiate(knifeGenPrefab, pos, rot);
                res.transform.parent = dotsOfCreation[randomDot].transform;
                res.GetComponentInChildren<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                dotsOfCreation[randomDot].gameObject.tag = "BlockedGenDot";
            }
        }
    }

    private void AppleGen()
    {
        for(int i = 0; i < 5; i++)
        {
            if (dotsOfCreation[i].gameObject.tag != "BlockedGenDot")
            {
                int chance = Random.Range(0, 100);

                if(chance <= appleCreationChance)
                {
                    Vector2 pos = dotsOfCreation[i].transform.position;
                    Quaternion rot = dotsOfCreation[i].transform.rotation;
                    GameObject res = Instantiate(applePrefab, pos, rot);
                    res.transform.parent = dotsOfCreation[i].transform;
                    dotsOfCreation[i].gameObject.tag = "BlockedGenDot";
                }
            }
        }
    }

#endregion
}
