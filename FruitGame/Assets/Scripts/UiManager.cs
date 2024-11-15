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

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject difficultySelect;
    [SerializeField] GameObject gameUi;

    bool gameActive = false;
    enum gameDifficulty
    {
        Easy,
        Normal,
        Hard
    }
    gameDifficulty difficulty;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    private void FixedUpdate()
    {
        if (gameActive)
        {
            timerText.text = time.ToString("F0");
            scoreText.text = $"{score.ToString()} / {highScore.ToString()}";
            Timer();
        }
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
            gameActive = false;
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

            scoreText.text = $"{score}/{currentScore}";
        }
    }

    public void PlayButton()
    {
        mainMenu.SetActive(false);
        difficultySelect.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void Easybutton()
    {
        difficulty = gameDifficulty.Easy;
        difficultySelect.SetActive(false);
        gameUi.SetActive(true);
        gameActive = true;
    }

    public void Normalbutton()
    {
        difficulty = gameDifficulty.Normal;
        difficultySelect.SetActive(false);
        gameUi.SetActive(true);
        gameActive = true;
    }

    public void Hardbutton()
    {
        difficulty = gameDifficulty.Hard;
        difficultySelect.SetActive(false);
        gameUi.SetActive(true);
        gameActive = true;
    }
}
