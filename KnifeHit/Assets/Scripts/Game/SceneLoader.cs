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
        PlayerPrefs.SetInt("Stage", 1);
        PlayerPrefs.SetInt("WoodHP", 7);
        PlayerPrefs.SetInt("Score", 0);
    }

    public void StartGame(string name)
    {
        SceneManager.LoadScene(name);
        PlayerPrefs.SetInt("Stage", 1);
        PlayerPrefs.SetInt("WoodHP", 7);
        PlayerPrefs.SetInt("Score", 0);
    }

    public void ToMenu(string name)
    {
        SceneManager.LoadScene(name);
    }
}
