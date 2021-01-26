using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject[] Cubes;

    private float[] speeds = new float[4];
    public bool isStarted = false;

    public Text scoreText;
    private int score;

    public GameObject soundOff, soundOn;
    private bool firstGame = true;
    public GameObject audioObj;

    public GameObject menu;

    void Start()
    {
        firstGame = PlayerPrefs.GetInt("FirstGame") != 0;
        if (firstGame)
        {
            PlayerPrefs.SetInt("Score", 5000);
            PlayerPrefs.SetInt("FirstGame", 0);
        }
        score = PlayerPrefs.GetInt("Score");
        checkScore();
        startSound();
    }

    void FixedUpdate()
    {
        if (isStarted)
        {
            for(int a = 0; a < Cubes.Length; a++)
            {
                Cubes[a].transform.Rotate(speeds[a], 0, 0);
            }
        }
    }

    private void checkScore()
    {
        PlayerPrefs.SetInt("Score", score);
        scoreText.text = score.ToString();
    }
    private void startSound()
    {
        bool startsound = PlayerPrefs.GetInt("Sound") == 1 ? false : true;
        audioObj.SetActive(startsound);
        soundOff.SetActive(startsound);
        soundOn.SetActive(!startsound);
        float b = Random.Range(0, 2);

    }

    public void SetSound(int a)
    {
        PlayerPrefs.SetInt("Sound", a);
        soundOff.SetActive(!soundOff.activeSelf);
        soundOn.SetActive(!soundOff.activeSelf);
        audioObj.SetActive(soundOff.activeSelf);
    }

    public void Started()
    {
        for(int a = 0; a < speeds.Length; a++)
        {
            speeds[a] = Random.Range(10, 20);
        }
        isStarted = true;
    }

    public void BackToMenu()
    {
        menu.SetActive(true);
    }

    public void Stoped()
    {
        List<int> varriable = new List<int>();
        

        isStarted = false;
        int counter = 0;
        for (int i = 0; i < Cubes.Length; i++)
        {
            GameObject cube = Cubes[i];
            int a = (int)Random.Range(0, 4);
            cube.transform.rotation = Quaternion.Euler(new Vector3(a * 90, 0, 0));
            varriable.Add(a);
        }

        for (int i = 0; i < varriable.Count - 1; i++)
        {
            int num = varriable[i];

            int count = 0;
            for (int f = i + 1; f < varriable.Count; f++)
            {
                if (num == varriable[f])
                {
                    count++;
                }
                if (count > counter)
                {
                    counter = count;
                }
            }
        }
        switch(counter)
        {
            case 1:
                score += 50;
                break;
            case 2:
                score += 50;
                
                break;
            case 3:
                score += 50;
                break;
            case 4:
                score += 50;
                break;
            default:
                break;
        }
        checkScore();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GamePlay()
    {
        menu.SetActive(false);
    }
}
