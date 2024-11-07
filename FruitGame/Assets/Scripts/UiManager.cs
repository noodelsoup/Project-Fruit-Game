using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    int score;
    int highScore;
    [SerializeField] float time = 60;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    private void FixedUpdate()
    {
        timerText.text = time.ToString("F0");
        scoreText.text = $"{score.ToString()} / {highScore.ToString()}";
        Timer();
    }

    void Timer()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            //game over
            UpdateHighScore(score);
        }
    }

    public void ScoreTestButton()
    {
        score++;
    }

    private void UpdateHighScore(int currentScore)
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            PlayerPrefs.Save();

            scoreText.text = $"Score: {score}/{currentScore}";
        }
    }
}
