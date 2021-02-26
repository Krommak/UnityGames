using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Division : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private int a;

    void Awake(){
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
   
    // Update is called once per frame
    public void Select(int a)
    {
        if(gameManager.images[a].gameObject.tag == "Untagged")
        {
            gameManager.images[a].color = new Color(1f, 0.766f, 0.1745283f);
            gameManager.images[a].gameObject.tag = "selected";
            gameManager.SelectNum(a);
        }
        else
        {
            gameManager.images[a].color = new Color(1f, 0.3971356f, 0.1745283f);
            gameManager.images[a].gameObject.tag = "Untagged";
        }
    }    
}
