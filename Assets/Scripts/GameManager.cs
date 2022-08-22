using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour {



    [Header("References")]
    [SerializeField] private Countdown countDown;
    [SerializeField] private Text countdownText;
    [SerializeField] private QuizMasterScript quizMasterScript;

    [Header("Attributes")]
    [SerializeField] private float restartDelay = 2f;
    [SerializeField] private float roundTime = 60f;

    [Header("Declarations")]
    public GameState State;
    public static GameManager Instance;
    public static event Action<GameState> OnGameStateChanged;
    

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
        UpdateGameState(GameState.PlayerOneTurn);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState) 
        {
            case GameState.PlayerOneTurn:
                HandlePlayerOneTurn();
                break;
            case GameState.PlayerTwoTurn:
                HandlePlayerTwoTurn();
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

    private void HandlePlayerOneTurn()
    {
        Debug.Log("Player 1 turn");
        quizMasterScript.AskQuestion();
        countDown.InitializeTimer(roundTime);
    }
    private void HandlePlayerTwoTurn()
    {
        Debug.Log("Player 2 turn");
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

    public enum GameState
    { 
        PlayerOneTurn,
        PlayerTwoTurn,
        Victory,
        GameOver
    }
}
    