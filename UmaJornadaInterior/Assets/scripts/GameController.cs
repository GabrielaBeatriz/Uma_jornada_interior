using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text healthText;
    
    public int score;
    public int score2;
    public int score3;
    public Text scoreText;
    public Text scoreText2;
    public Text scoreText3;

    public GameObject pauseObj;
    public GameObject gameOverObj; 

    private bool isPaused;
        
    public static GameController instance;
    void Awake()
    {
        if (instance == null)
        {
             instance = this;
             DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    private void OnEnable()
    {
        UiObserver.AtualizarVidaEvent += UpdateLives;
    }

    private void OnDisable()
    {
        UiObserver.AtualizarVidaEvent -= UpdateLives;

    }

    void Update()
    {
        PauseGame();
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        
    }
    
    public void UpdateScore2(int value)
    {
        score2 += value;
        scoreText2.text = score2.ToString();
        
    }
    public void UpdateScore3(int value)
    {
        score3 += value;
        scoreText3.text = score3.ToString();
        
    }

    public void UpdateLives(int value)
    {
        healthText.text = "x" + value.ToString();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        AudioObserver.OnStopMusicEvent();
        gameOverObj.SetActive(true);
    }

    public void RestartGame()
    {
        AudioObserver.OnPlayMusicEvent();
        SceneManager.LoadScene(0);
    }
}
