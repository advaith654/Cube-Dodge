using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Texts")]
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text bestScoreText;
    public TMP_Text difficultyText;
    public TMP_Text popupText;

    [Header("Panels")]
    public GameObject gameOverPanel;
    public GameObject victoryPanel;

    int difficulty = 1;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateScore(0);

        bestScoreText.text =
            "Best : " + PlayerPrefs.GetInt("BestScore", 0);

        popupText.gameObject.SetActive(false);

        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance == null)
            return;

        timerText.text =
            "Time : " +
            Mathf.Ceil(GameManager.Instance.timer);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score : " + score;

        if (score >
            PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);

            bestScoreText.text =
                "Best : " + score;
        }
    }

    public void IncreaseDifficulty()
    {
        difficulty++;

        difficultyText.text =
            "Difficulty : " + difficulty;

        StopAllCoroutines();

        StartCoroutine(PopupRoutine());
    }

    System.Collections.IEnumerator PopupRoutine()
    {
        popupText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);

        popupText.gameObject.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ShowVictory()
    {
        victoryPanel.SetActive(true);
    }
}