using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    private int _playerOneCorrectAnswers;
    private int _playerTwoCorrectAnswers;
    
    private int _playerOneWrongAnswers;
    private int _playerTwoWrongAnswers;
    
    private float _playerOnePercentage;
    private float _playerTwoPercentage;

    [SerializeField] private UpdateStatistics updateStatistics;

    public void IncrementPlayerCorrectAnswers(int playerNumber = 1)
    {
        if (playerNumber == 1)
        {
            _playerOneCorrectAnswers++;
        }
        else
        {
            _playerTwoCorrectAnswers++;
        }
     
        CalculatePercentages(playerNumber);
    }
    
    public void IncrementPlayerWrongAnswers(int playerNumber = 1)
    {
        if (playerNumber == 1)
        {
            _playerOneWrongAnswers++;
        }
        else
        {
            _playerTwoWrongAnswers++;
        }
     
        CalculatePercentages(playerNumber);
    }

    private void UpdateStatisticsScreen()
    {
        updateStatistics.UpdatePlayerAnswers(1, _playerOneCorrectAnswers, _playerOneWrongAnswers);    
        updateStatistics.UpdatePlayerAnswers(2, _playerTwoCorrectAnswers, _playerTwoWrongAnswers);  
        updateStatistics.UpdatePlayerPercentages(1, _playerOnePercentage);
        updateStatistics.UpdatePlayerPercentages(2, _playerTwoPercentage);
    }

    private void CalculatePercentages(int playerNumber)
    {
        var total = 1.0;
        
        if (playerNumber == 1)
        {
            total = _playerOneCorrectAnswers + _playerOneWrongAnswers;
            _playerOnePercentage = (float)(_playerOneCorrectAnswers / total);
        }
        else
        {
            total = _playerTwoCorrectAnswers + _playerTwoWrongAnswers;
            _playerTwoPercentage = (float)(_playerTwoCorrectAnswers / total);
        }
        
        UpdateStatisticsScreen();
    }
}
