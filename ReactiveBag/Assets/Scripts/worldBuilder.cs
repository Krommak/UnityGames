using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldBuilder : MonoBehaviour
{
    public GameObject player;

    public GameObject [] free;
    public GameObject [] obst;

    public Transform sectionContainer;
    private Transform lastSection = null;

    // Start is called before the first frame update
    void Start()
    {
        for (int index = 0; index < 2; index++ )
        {
            CreateFreeSection();
        }
        CreateObstSection();
    }

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CreateSection();
        }
    }

    public void CreateSection()
    {
        int i = Random.Range(0, 2);

        if(i == 1)
        {
            CreateFreeSection();
        }
        if(i == 0)
        {
            CreateObstSection();
        }


    }
    private void CreateObstSection()
    {
        Vector3 pos = (lastSection == null) ?
            sectionContainer.position :
            lastSection.GetComponent<sectController>().endPoint.position;
        int index = Random.Range(0, obst.Length);
        GameObject res = Instantiate(obst[index], pos, Quaternion.identity, sectionContainer);
        lastSection = res.transform;
    }

    private void CreateFreeSection()
    {
        Vector3 pos = (lastSection == null) ?
            sectionContainer.position :
            lastSection.GetComponent<sectController>().endPoint.position;
        int index = Random.Range(0, free.Length);
        GameObject res = Instantiate(free[index], pos, Quaternion.identity, sectionContainer);
        lastSection = res.transform;
    }
}
