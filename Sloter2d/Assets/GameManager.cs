﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Transform[] dotsOfCreation;

    public GameObject[] tilePrefabs;

    private List<int> numbersOfTile = new List<int>();

    private List<GameObject> tilesGen = new List<GameObject>();

    public Text scoreText;

    public GameObject menuPanel, soundOff, soundOn;

    public GameObject audioObj;

    void Start()
    {
        if (PlayerPrefs.GetInt("Score") == 0)
        {
            scoreText.text = "5000";
        }
        StartSound();
    }
    private void StartSound()
    {
        bool sound = PlayerPrefs.GetInt("Sound") == 1 ? false : true;
        audioObj.SetActive(sound);
        soundOff.SetActive(sound);
        soundOn.SetActive(!sound);
    }
    public void SetSound(int a)
    {
        PlayerPrefs.SetInt("Sound", a);
        soundOff.SetActive(!soundOff.activeSelf);
        soundOn.SetActive(!soundOff.activeSelf);
        audioObj.SetActive(soundOff.activeSelf);
    }

    public void GenerateElements()
    {
        numbersOfTile.Clear();
        for (int i = 0; i < tilesGen.Count; i++)
        {
            Destroy(tilesGen[i]);
        }
        tilesGen.Clear();

        // for (int i = 0; i < dotsOfCreation.Length; i++)
        // {
        //     GenerateElement(dotsOfCreation[i]);
        // }

        StartCoroutine(GenerateElement(dotsOfCreation));
        
    }
    private IEnumerator GenerateElement(Transform[] transform)
    {
        int score = int.Parse(scoreText.text);
        bool isMatched = false;
        foreach (Transform tr in transform)
        {
            int index = Random.Range(0, tilePrefabs.Length);
            numbersOfTile.Add(index);
            Vector2 pos = tr.position;
            GameObject res = Instantiate(tilePrefabs[index], pos, Quaternion.identity);
            res.transform.parent = tr;
            tilesGen.Add(res);
            yield return new WaitForSeconds(0.1f);
        }
        for (int x = 0; x < 3; x++)
        {
            int count = 0;
            int index = numbersOfTile[x];
            if (index == numbersOfTile[x + 3] && index == numbersOfTile[x + 6])
            {
                count++;
            }
            if (count == 1)
            {
                score += 50;
                scoreText.text = score.ToString();
                PlayerPrefs.SetInt("Score", score);
                isMatched = true;
            }
        }
        for (int y = 0; y < 9; y += 3)
        {
            int count = 0;
            int index = numbersOfTile[y];
            if (index == numbersOfTile[y + 1] && index == numbersOfTile[y + 2])
            {
                count++;
            }
            if (count == 1)
            {
                score += 50;
                scoreText.text = score.ToString();
                PlayerPrefs.SetInt("Score", score);
                isMatched = true;
            }
        }
        if (!isMatched)
        {
            score -= 50;
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("Score", score);
        }
        isMatched = false;
    }
    // private void GenerateElement(Transform transform)
    // {
    //     int index = Random.Range(0, tilePrefabs.Length);
    //     numbersOfTile.Add(index);
    //     Vector2 pos = transform.position;
    //     GameObject res = Instantiate(tilePrefabs[index], pos, Quaternion.identity);
    //     res.transform.parent = transform;
    //     tilesGen.Add(res);
    // }

    public void GamePlay()
    {
        menuPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        menuPanel.SetActive(true);
        for (int i = 0; i < tilesGen.Count; i++)
        {
            Destroy(tilesGen[i]);
        }
        tilesGen.Clear();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}