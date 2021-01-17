using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public Text appleCount, greateScore, greateStage;

    private void Start()
    {
        appleCount.text = PlayerPrefs.GetInt("Apples").ToString();
        greateScore.text = "SCORE " + PlayerPrefs.GetInt("GreateScore");
        greateStage.text = "STAGE " + PlayerPrefs.GetInt("GreateStage"); 
    }
}
