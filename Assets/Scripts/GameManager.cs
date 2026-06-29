using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game")]
    public int score = 0;
    public float timer = 90f;

    public bool gameEnded = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (gameEnded)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            WinGame();
        }
    }

    public void AddScore()
    {
        score++;

        UIManager.Instance.UpdateScore(score);

        if (score % 5 == 0)
        {
            EnemySpawner.Instance.IncreaseDifficulty();

            UIManager.Instance.IncreaseDifficulty();
        }
    }

    public void GameOver()
    {
        if (gameEnded)
            return;

        gameEnded = true;

        UIManager.Instance.ShowGameOver();

        Time.timeScale = 0;
    }

    public void WinGame()
    {
        if (gameEnded)
            return;

        gameEnded = true;

        UIManager.Instance.ShowVictory();

        Time.timeScale = 0;
    }
}