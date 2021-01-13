using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Wood wood;

    private UI ui;

    private string [] tagsToDel = new string [3] {"KnifeInWood", "Apple", "KnifeTile"};

    void Start()
    {
        wood = GameObject.Find("Wood").GetComponent<Wood>();
        ui = GameObject.Find("Canvas").GetComponent<UI>();
    }

#region test перехода между Stage
    // public void StageUp()
    // {
    //     string stageText = ui.stage.text;
    //     int stageRate = int.Parse(stageText);
    //     stageRate++;
    //     ui.stage.text = stageRate.ToString();
    //     for(int i = 0; i < tagsToDel.Length; i++)
    //     {
    //         do
    //         {
    //             GameObject obj = GameObject.FindWithTag(tagsToDel[i]);
    //             Destroy(obj);
    //         }
    //         while(GameObject.FindWithTag(tagsToDel[i]) == null);
    //     }
    //     wood.woodHP++;
    // }
#endregion
}
