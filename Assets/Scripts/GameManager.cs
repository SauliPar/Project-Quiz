using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour {

    [Header("References")]
    [SerializeField] private QuizMasterScript quizMasterScript;
    [SerializeField] private GameObject playerOnePanel;
    [SerializeField] private GameObject playerTwoPanel;

    [Header("Attributes")]
    [SerializeField] private float restartDelay = 3f;
    [SerializeField] private float roundTime = 60f;
    [SerializeField] private int waitTime = 3;

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
        UpdateGameState(GameState.PlayerTurn);
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
                HandleVictory();
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
        Invoke(nameof(NextPlayer), waitTime);
    }
    
    private void HandleWrong()
    {
        Debug.Log("WRONG");
        Invoke(nameof(NextPlayer), waitTime);
    }
    private void HandleVictory()
    {
        Debug.Log("VICTORY");
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
    