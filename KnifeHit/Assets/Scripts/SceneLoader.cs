using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void SceneUpLoader()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("lvl", 1);
        PlayerPrefs.SetInt("woodHP", 7);
        PlayerPrefs.SetInt("knifesRate", 0);
    }
}
