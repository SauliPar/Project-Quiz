using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RoundAmountSelection : MonoBehaviour
{
    public RoundAmount InputRoundAmount;
    public enum RoundAmount
    {
        Fast = 5,
        Medium = 10,
        Long = 15
    }

    public void RoundButtonPressed()
    {
        SettingsManager.Instance.SetGameRules(InputRoundAmount);
    }
}