using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text knifesRate;

    public int rateIndex = 0;
    
    public Text applesCount;
    void Start()
    {
        knifesRateUp();
        applesCount.text = PlayerPrefs.GetInt("Apples").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void knifesRateUp()
    {
        knifesRate.text = rateIndex + "";
    }

    public void applesUp()
    {
        int index = PlayerPrefs.GetInt("Apples");
        index+=2;
        PlayerPrefs.SetInt("Apples", index);
        applesCount.text = index.ToString();
    }
}
