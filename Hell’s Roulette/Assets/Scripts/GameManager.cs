using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Rigidbody2D circle;

    public Text scoreText, rotateSpeedText;

    public GameObject menu, soundOff, soundOn, audioObj, settingPanel, audioWin, audioFall;

    [SerializeField] private Indicator indicator;

    public Image [] images;

    [SerializeField]public List<int> selectedNum = new List<int>();

    private int torque;

    private bool isRotate;

    private int number;

    private int score;

    private int rotateSpeed;

    private bool isSound;

    void Start()
    {
        if(PlayerPrefs.GetInt("RotateSpeed") == 0)
        {
            rotateSpeed = 1;
        }
        PlayerPrefs.SetInt("Score", 5000);
        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        StartSound();
        isSound = PlayerPrefs.GetInt("Sound") == 1 ? false : true;
        rotateSpeedText.text = rotateSpeed.ToString();
    }

    void FixedUpdate()
    {
        if(isRotate)
        {
            circle.angularVelocity -= Time.deltaTime*40;
            if(circle.angularVelocity < 0)
            {
                circle.angularVelocity = 0;
                isRotate = false;
                CalcScore();
            }
        }
    }

    
    void Update()
    {
        if(isRotate && isSound)
        {
            circle.GetComponent<AudioSource>().enabled = true;
        }
    }

    #region Игровые функции

    public void SelectNum(int a)
    {
        if(selectedNum.Count >= 3)
        {
            images[selectedNum[0]].color = new Color(1f, 0.3971356f, 0.1745283f);
            images[selectedNum[0]].gameObject.tag = "Untagged";
            selectedNum.RemoveAt(0);
            selectedNum.Add(int.Parse(images[a].gameObject.name));
        }
        else
        {
            selectedNum.Add(int.Parse(images[a].gameObject.name));
        }
    }
    
    public void RotateCircle()
    {
        torque = Random.Range(rotateSpeed+6, rotateSpeed+11);
        circle.AddTorque(torque, ForceMode2D.Impulse);
        isRotate = true;
    }
    
    private void CalcScore()
    {
        score = int.Parse(scoreText.text);
        number = indicator.number;
        bool isMatch = false;
        circle.GetComponent<AudioSource>().enabled = false;
        foreach(int num in selectedNum)
        {
            if(num == number)
            {
                score +=1000;
                isMatch = true;
                if(isSound)
                {
                    StartCoroutine(WinSound());
                }
            }
        }
        if(!isMatch)
        {
            score -= 100;
            if(isSound)
            {
                StartCoroutine(FallSound());
            }
        }
        CheckScore(score);
    }

    private void CheckScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
        scoreText.text = score.ToString();
    }

    private IEnumerator WinSound()
    {
        audioWin.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        audioWin.SetActive(false);
    }
    private IEnumerator FallSound()
    {
        audioFall.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        audioFall.SetActive(false);
    }
    #endregion

    #region UI
    private void StartSound()
    {
        isSound = PlayerPrefs.GetInt("Sound") == 1 ? false : true;
        audioObj.SetActive(isSound);
        soundOff.SetActive(isSound);
        soundOn.SetActive(!isSound);
    }
    public void Sound(int a)
    {
        PlayerPrefs.SetInt("Sound", a);
        soundOff.SetActive(!soundOff.activeSelf);
        soundOn.SetActive(!soundOff.activeSelf);
        audioObj.SetActive(soundOff.activeSelf);
        isSound = a == 1 ? false : true;
    }
    public void Play()
    {
        menu.SetActive(false);
        
        settingPanel.SetActive(false);
    }

    public void ToMenu()
    {
        menu.SetActive(true);
    }

    public void ToSettings()
    {
        settingPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SetRotateSpeed(int a)
    {
        rotateSpeed+=a;
        PlayerPrefs.SetInt("RotateSpeed", rotateSpeed);
        rotateSpeedText.text = rotateSpeed.ToString();
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("Score", 1000);
        scoreText.text = 1000.ToString();
    }

    #endregion
}