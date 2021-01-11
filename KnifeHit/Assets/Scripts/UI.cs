using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text knifesRate;

    public int rateIndex = 0;
    void Start()
    {
        knifesRateUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void knifesRateUp()
    {
        knifesRate.text = rateIndex + "";
    }
}
