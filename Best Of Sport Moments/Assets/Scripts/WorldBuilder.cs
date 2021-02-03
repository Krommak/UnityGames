using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public GameObject player;

    public GameObject [] free;
    public GameObject [] obst;

    public Transform sectionContainer;
    private Transform lastSection = null;

    private int lastSecIndex;

    void Awake()
    {
            CreateFreeSection();
        for (int index = 0; index < 6; index++ )
        {
            CreateObstSection();
        }
    }

    public void CreateSection()
    {
        int index = Random.Range(0, 10);

        if(index < 1)
        {
            CreateFreeSection();
        }
        else
        {
            CreateObstSection();
        }
    }
    private void CreateObstSection()
    {
        Vector3 pos = (lastSection == null) ?
            sectionContainer.position :
            lastSection.GetComponent<SectController>().endPoint.position;
        int index = Random.Range(0, obst.Length);
        if(index != lastSecIndex)
        {
            GameObject res = Instantiate(obst[index], pos, Quaternion.identity, sectionContainer);
            lastSection = res.transform;
            lastSecIndex = index;
        }
        else
        {
            CreateObstSection();
        }
    }

    private void CreateFreeSection()
    {
        Vector3 pos = (lastSection == null) ?
            sectionContainer.position :
            lastSection.GetComponent<SectController>().endPoint.position;
        int index = Random.Range(0, free.Length);
        GameObject res = Instantiate(free[index], pos, Quaternion.identity, sectionContainer);
        lastSection = res.transform;
    }
}
