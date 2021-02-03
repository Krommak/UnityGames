using System.Collections;
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

    public GameObject explosionPrefab;

    private List<GameObject> explosions = new List<GameObject>();

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
        StartCoroutine(ClearLists());

        StartCoroutine(GenerateElement(dotsOfCreation));
    }

    IEnumerator ClearLists()
    {
        numbersOfTile.Clear();
        for (int i = 0; i < explosions.Count; i++)
        {
            Destroy(explosions[i]);
        }
        explosions.Clear();
        for (int i = 0; i < tilesGen.Count; i++)
        {
            GameObject res = Instantiate(explosionPrefab, tilesGen[i].transform.position, Quaternion.identity);
            explosions.Add(res);
            Destroy(tilesGen[i]);
            yield return new WaitForSeconds(0.2f);
        }
        tilesGen.Clear();
    }

    private IEnumerator GenerateElement(Transform[] transform)
    {
        int score = int.Parse(scoreText.text);
        bool isMatched = false;
        yield return StartCoroutine(ClearLists());
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
            if (index == numbersOfTile[x + 1] && index == numbersOfTile[x + 2])
            {
                count++;
            }
            if (count == 1)
            {
                score += 100;
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