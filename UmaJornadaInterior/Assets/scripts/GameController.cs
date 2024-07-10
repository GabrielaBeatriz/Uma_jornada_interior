using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int score;
    public int score2;
    public int score3;
    public Text scoreText;
    public Text scoreText2;
    public Text scoreText3;
    
    public static GameController instance;
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
