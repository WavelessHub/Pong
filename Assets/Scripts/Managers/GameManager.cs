using UnityEngine;

struct PlayerData
{
    public string playerName;
    public int playerScore;
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private PlayerData playerOne;
    private PlayerData playerTwo;

    private int scoreToWin = 5;

    private bool hasGameStarted = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (!instance)
            instance = this;
        else
            Destroy(gameObject);

        ClearGameData();
    }

    void Update()
    {
        if (!HasGameStarted())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hasGameStarted = true;
            }
        }
    }

    public void ClearGameData()
    {
        scoreToWin = 5;
        hasGameStarted = false;

        SetPlayerOneName("");
        SetPlayerTwoName("");

        ResetScores();
    }

    public void ResetScores()
    {
        playerOne.playerScore = 0;
        playerTwo.playerScore = 0;
    }

    public bool HasGameStarted() => hasGameStarted;
    public bool SetHasGameStarted(bool hasGameStarted) => this.hasGameStarted = hasGameStarted;

    public int GetScoreToWin() => scoreToWin;
    public void SetScoreToWin(int scoreToWin) => this.scoreToWin = scoreToWin;

    public int GetPlayerOneScore() => playerOne.playerScore;
    public int GetPlayerTwoScore() => playerTwo.playerScore;

    public void IncrementPlayerOneScore() => playerOne.playerScore++;
    public void IncrementPlayerTwoScore() => playerTwo.playerScore++;

    public string GetPlayerOneName() => playerOne.playerName;
    public string GetPlayerTwoName() => playerTwo.playerName;

    public void SetPlayerOneName(string name) => playerOne.playerName = name;
    public void SetPlayerTwoName(string name) => playerTwo.playerName = name;
}