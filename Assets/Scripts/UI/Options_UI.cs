using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options_UI : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private TextMeshProUGUI inputOneError;
    [SerializeField] private TextMeshProUGUI inputTwoError;

    [SerializeField] private Button startButton;

    [SerializeField] private int minimumCharacters;

    [SerializeField] private Button[] allScores;

    private string playerOneName = "";
    private string playerTwoName = "";

    private int scoreToWin;

    void Awake()
    {
        gameManager = GameManager.instance;

        gameManager.ClearGameData();

        scoreToWin = gameManager.GetScoreToWin();

        inputOneError.color = SetColor(inputOneError, 0);
        inputTwoError.color = SetColor(inputOneError, 0);

        HandleScoreToWin();
    }

    void Update()
    {
        HandleInputError();
        HandleScoreToWin();
    }

    void HandleInputError()
    {
        startButton.interactable = playerOneName.Length >= minimumCharacters && playerTwoName.Length >= minimumCharacters;

        inputOneError.color = (playerOneName.Length < minimumCharacters && playerOneName.Length > 0)
            ? SetColor(inputOneError, 1)
            : SetColor(inputOneError, 0);

        inputTwoError.color = (playerTwoName.Length < minimumCharacters && playerTwoName.Length > 0)
            ? SetColor(inputTwoError, 1)
            : SetColor(inputTwoError, 0);
    }

    Color SetColor(TextMeshProUGUI input, float alpha) => new(input.color.r, input.color.g, input.color.b, alpha);

    void HandleScoreToWin()
    {
        foreach (Button score in allScores)
        {
            string scoreText = score.GetComponentInChildren<TextMeshProUGUI>().text.Trim();

            if (scoreText == scoreToWin.ToString())
            {
                score.image.color = new Color32(176, 176, 176, 255); // Use Color32 for 0–255 range
            }
            else
            {
                score.image.color = new Color32(26, 26, 26, 255);
            }
        }
    }

    public void SetScoreToWin(int scoreToWin) => this.scoreToWin = scoreToWin;

    public void SetPlayerOneName(string name) => playerOneName = name;
    public void SetPlayerTwoName(string name) => playerTwoName = name;

    public void MenuClickSFX() => AudioManager.instance.PlaySFX(0);

    public void StartGame()
    {
        MenuClickSFX();

        gameManager.ClearGameData();

        gameManager.SetPlayerOneName(playerOneName);
        gameManager.SetPlayerTwoName(playerTwoName);

        gameManager.SetScoreToWin(scoreToWin);

        SceneManager.LoadScene("Game");
    }
}
