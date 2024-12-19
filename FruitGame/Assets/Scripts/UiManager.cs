using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public int score;
    int highScore;
    public float time = 60;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject difficultySelect;
    [SerializeField] GameObject gameUi;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject pauseMenu;

    bool gameActive = false;

    GameObject spawner;
    private ItemSpawner spawnerItem;

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
        difficultySelect.SetActive(false);
        spawnerItem = GameObject.Find(" FruitSpawner").GetComponent<ItemSpawner>();
        spawner = GameObject.Find(" FruitSpawner");
        spawner.SetActive(false);


    }
    private void FixedUpdate()
    {
        if (gameActive)
        {
            timerText.text = time.ToString("F0");
            scoreText.text = $"{score.ToString()} / {highScore.ToString()}";
            Timer();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
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
            gameOver.SetActive(true);
            spawner.SetActive(false);
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


    private void SetDifficulty(gameDifficulty newDifficulty)
    {
        switch (newDifficulty)
        {
            case gameDifficulty.Easy:
                spawnerItem.itemsPerWave = 1;

                spawnerItem.spawnInterval = 3;

                break;

            case gameDifficulty.Normal:
                spawnerItem.itemsPerWave = 2;
                spawnerItem.spawnInterval = 3;

                break;

            case gameDifficulty.Hard:
                spawnerItem.itemsPerWave = 3;
                spawnerItem.spawnInterval = 3;

                break;

        }


    }
    public void Easybutton()
    {
        difficulty = gameDifficulty.Easy;
        time = 60f;
        DifficultyButton(difficulty);
    }

    public void Normalbutton()
    {
        difficulty = gameDifficulty.Normal;
        time = 40f;
        DifficultyButton(difficulty);
    }

    public void Hardbutton()
    {
        difficulty = gameDifficulty.Hard;
        time = 20f;
        DifficultyButton(difficulty);
    }
    private void DifficultyButton(gameDifficulty newDifficulty)
    {
        difficultySelect.SetActive(false);
        gameUi.SetActive(true);
        gameActive = true;
        spawner.SetActive(true);

        SetDifficulty(newDifficulty);
    }
    public void MainMenuButton()
    {
        time = 10f;
        score = 0;
        gameOver.SetActive(false);
        gameUi.SetActive(false);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        gameActive = false;
        spawner.SetActive(false);
    }

    public void RestartButton()
    {
        switch (difficulty)
        {
            case gameDifficulty.Easy:
                time = 60;
                break;

            case gameDifficulty.Normal:
                time = 40f;
                break;

            case gameDifficulty.Hard:
                time = 20f;
                break;
        }
        score = 0;
        gameOver.SetActive(false);
        gameActive = true;
        spawner.SetActive(true);
    }

    public void ContinueButton()
    {
        pauseMenu.SetActive(false);
        gameActive = true;
    }

    void Pause()
    {
        gameActive = false;
        pauseMenu.SetActive(true);
    }

    public void AddScoreAndTime(int scoreAmount, float timeAmount) 
    {
        score += scoreAmount;
        time += timeAmount;
    }
}
