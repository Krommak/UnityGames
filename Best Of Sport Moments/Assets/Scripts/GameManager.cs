using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isStart;

    public float speedUp = 0.1f;

    public int speedUpFrequency = 10;

    public Transform player;

    private int count = 1;

    public GameObject audioObj, soundOff, soundOn;

    void Update()
    {
        if(((int)player.position.z+7)%speedUpFrequency == 0 && (int)player.position.z+7 != 0 && ((int)player.position.z+7)/speedUpFrequency == count)
        {
            player.gameObject.GetComponent<Animator>().speed+=speedUp;
            count++;
            player.gameObject.GetComponent<PlayerController>().toLeftRight += 0.1f;
        }
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
}
