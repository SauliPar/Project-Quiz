using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [SerializeField] private Countdown countdown;
    [SerializeField] private QuizMasterScript quizMasterScript;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;
    public float restartDelay = 2f;

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
    }
    private void HandlePlayerTwoTurn()
    {
    }
    private void HandleVictory()
    {
    }
    private void HandleGameOver()
    {
    }

    public enum GameState
    { 
        PlayerOneTurn,
        PlayerTwoTurn,
        Victory,
        GameOver
    }
}
    