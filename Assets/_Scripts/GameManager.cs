using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour {

    [Header("References")]
    [SerializeField] private QuizMasterScript quizMasterScript;
    [SerializeField] private GameObject playerOnePanel;
    [SerializeField] private GameObject playerTwoPanel;
    [SerializeField] private GameObject playerOneWinPanel;
    [SerializeField] private GameObject playerTwoWinPanel;
    [SerializeField] private TextMeshProUGUI playerOneScoreText;
    [SerializeField] private TextMeshProUGUI playerTwoScoreText;
    [SerializeField] private GameObject statisticsWindow;
    [SerializeField] private StatsManager statsManager;

    [Header("Attributes")]
    [SerializeField] private float restartDelay = 3f;
    [SerializeField] private float roundTime = 60f;
    [SerializeField] private int waitTime = 3;

    [Header("Game Settings")]
    [SerializeField] private int playerOneScore = 0;
    [SerializeField] private int playerTwoScore = 0;
    [SerializeField] private int pointsToWin = 3;

    [Header("GameState")]
    public GameState State;

    public static GameManager Instance;
    public static event Action<GameState> OnGameStateChanged;
    private bool _playerOneTurn = true;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        MasterCatalogManager.Instance.Initialize();
        quizMasterScript.Initialize();
        Initialize();
    }

    public void Initialize()
    {
        SettingsManager.Instance.HideAllMenus();
        UpdatePlayerScore();
        UpdateGameState(GameState.PlayerTurn);
    }

    private void UpdatePlayerScore(int playerNumber = 0)
    {
        if (playerNumber == 1)
        {
            playerOneScore++;
            statsManager.IncrementPlayerCorrectAnswers();
        }
        else if (playerNumber == 2)
        {
            playerTwoScore++;
            statsManager.IncrementPlayerCorrectAnswers(2);
        }
        else
        {
            playerOneScore = playerTwoScore = 0;
        }
        playerOneScoreText.text = $"P1: {playerOneScore}";
        playerTwoScoreText.text = $"P2: {playerTwoScore}";
    }

    public bool TurnSwapper()
    {
        _playerOneTurn = !_playerOneTurn;
        return _playerOneTurn;
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState) 
        {
            case GameState.PlayerTurn:
                ShowPlayerPanel();
                break;
            case GameState.Correct:
                HandleCorrect();
                break;
            case GameState.Wrong:
                HandleWrong();
                break;
            case GameState.Victory:
                Invoke(nameof(HandleVictory), waitTime);
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }
    private void ShowPlayerPanel()
    {
        if (_playerOneTurn)
        {
            playerOnePanel.SetActive(true);
            Invoke(nameof(HandlePlayerOneTurn), waitTime);
        }
        else
        {
            playerTwoPanel.SetActive(true);
            Invoke(nameof(HandlePlayerTwoTurn), waitTime);
        } 
    }
    private void HandlePlayerOneTurn()
    {
        Debug.Log("Player 1 turn");
        playerOnePanel.SetActive(false);
        quizMasterScript.AskQuestion();
    }
    private void HandlePlayerTwoTurn()
    {
        Debug.Log("Player 2 turn");
        playerTwoPanel.SetActive(false);
        quizMasterScript.AskQuestion();
    }
    private void NextPlayer()
    {
        quizMasterScript.DestroyQuizCard();
        TurnSwapper();
        UpdateGameState(GameState.PlayerTurn);
    }
    private void HandleCorrect()
    {
        Debug.Log("CORRECT");
        if (_playerOneTurn) UpdatePlayerScore(1);
        else UpdatePlayerScore(2);
        if (playerOneScore >= pointsToWin || playerTwoScore >= pointsToWin)
        {
            UpdateGameState(GameState.Victory);
        }
        else
        {
            Invoke(nameof(NextPlayer), waitTime);
        }
    }
    
    private void HandleWrong()
    {
        Debug.Log("WRONG");

        if (_playerOneTurn)
        {
            statsManager.IncrementPlayerWrongAnswers();
        }
        else
        {
            statsManager.IncrementPlayerWrongAnswers(2);
        }
        
        Invoke(nameof(NextPlayer), waitTime);
    }
    private void HandleVictory()
    {
        if (playerOneScore > playerTwoScore)
        {
            Debug.Log("Player One Wins!");
            playerOneWinPanel.SetActive(true);
        }
        else if (playerTwoScore > playerOneScore)
        {
            Debug.Log("Player Two Wins");
            playerTwoWinPanel.SetActive(true);
        }
        Invoke(nameof(ShowStatisticsWindow), restartDelay);
    }
    private void HandleGameOver()
    {
        Debug.Log("GAME OVER.");
        Invoke("RestartGame", restartDelay);
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ShowStatisticsWindow()
    {
        playerOneWinPanel.SetActive(false);
        playerTwoWinPanel.SetActive(false);

        statisticsWindow.SetActive(true);
    }

    public float GetRoundTime()
    {
        return roundTime;
    }

    public enum GameState
    { 
        PlayerTurn,
        Correct,
        Wrong,
        Victory,
        GameOver
    }
}
    