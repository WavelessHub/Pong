using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGame_UI : MonoBehaviour
{
    private Ball ball;

    [SerializeField] private GameObject startGameText;

    [SerializeField] private GameObject gameOver;
    [SerializeField] private TextMeshProUGUI WinStatus;

    void Awake()
    {
        gameOver.SetActive(false);
    }

    void Update()
    {
        if (GameManager.instance.GetPlayerOneScore() == GameManager.instance.GetScoreToWin())
        {
            GameOver(GameManager.instance.GetPlayerOneName());
        }

        if (GameManager.instance.GetPlayerTwoScore() == GameManager.instance.GetScoreToWin())
        {
            GameOver(GameManager.instance.GetPlayerTwoName());
        }

        ball = FindFirstObjectByType<Ball>();

        if (ball)
        {
            startGameText.SetActive(!GameManager.instance.HasGameStarted());
        }
    }

    void GameOver(string playerName)
    {
        WinStatus.text = playerName + " WON!!!";

        gameOver.SetActive(true);
    }

    public void PlayAgain()
    {
        gameOver.SetActive(false);

        GameManager.instance.ResetScores();
    }

    public void GoToMenu() => SceneManager.LoadScene("Menu");
}
