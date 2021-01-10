using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class TestAds : MonoBehaviour { 

    string gameId = "3949575";
    bool testMode = true;

    void Start () {
        Advertisement.Initialize (gameId, testMode);
    }
}

