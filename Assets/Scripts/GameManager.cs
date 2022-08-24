using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour {



    [Header("References")]
    [SerializeField] private QuizMasterScript quizMasterScript;

    [Header("Attributes")]
    [SerializeField] private float restartDelay = 3f;
    [SerializeField] private float roundTime = 60f;
    [SerializeField] private int waitTime = 3;

    [Header("Declarations")]
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
        UpdateGameState(GameState.PlayerOneTurn);
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
            case GameState.PlayerOneTurn:
                HandlePlayerOneTurn();
                break;
            case GameState.PlayerTwoTurn:
                HandlePlayerTwoTurn();
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

    private void HandlePlayerOneTurn()
    {
        Debug.Log("Player 1 turn");
        quizMasterScript.AskQuestion();
    }
    private void HandlePlayerTwoTurn()
    {
        Debug.Log("Player 2 turn");
        quizMasterScript.AskQuestion();
    }
    private void NextPlayer()
    {
        quizMasterScript.DestroyQuizCard();
        if (TurnSwapper() == true)
        {
            UpdateGameState(GameState.PlayerOneTurn);
        }
        else
        {
            UpdateGameState(GameState.PlayerTwoTurn);
        }
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
        PlayerOneTurn,
        PlayerTwoTurn,
        Correct,
        Wrong,
        Victory,
        GameOver
    }
}
    