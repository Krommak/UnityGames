using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject BugKnife = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Fix зависшего ножа
        BugKnife = GameObject.FindGameObjectWithTag("ReflectKnife");
        if (BugKnife != null)
        {
            BugKnife.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    #region тестовый контроллер

        

    #endregion
}
