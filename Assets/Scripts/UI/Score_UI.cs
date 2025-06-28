using TMPro;
using UnityEngine;

public class Score_UI : MonoBehaviour
{
    private GameManager gameManager;

    [Header("Name")]
    [SerializeField] private TextMeshProUGUI playerOneName;
    [SerializeField] private TextMeshProUGUI playerTwoName;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI playerOneScore;
    [SerializeField] private TextMeshProUGUI playerTwoScore;

    void Awake()
    {
        gameManager = GameManager.instance;
    }

    void Start()
    {
        SetPlayerNames();
        SetPlayerScores();
    }

    void Update()
    {
        SetPlayerScores();
    }

    void SetPlayerNames()
    {
        playerOneName.text = gameManager.GetPlayerOneName();
        playerTwoName.text = gameManager.GetPlayerTwoName();
    }

    void SetPlayerScores()
    {
        playerOneScore.text = gameManager.GetPlayerOneScore().ToString();
        playerTwoScore.text = gameManager.GetPlayerTwoScore().ToString();
    }
}