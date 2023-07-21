using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Text countdownText;

    private bool enableTimer;
    private float roundTime;

    public void InitializeTimer(float time)
    {
        countdownText.enabled = true;
        Time.timeScale = 1f;
        roundTime = time;
        enableTimer = true;
        SetTimerColor();
    }
    private void FixedUpdate()
    {
        if (enableTimer)
        {
            roundTime -= Time.fixedDeltaTime;
            countdownText.text = roundTime.ToString("F1");

            if (roundTime <= 10f)
            {
                SetTimerColor("red");
                    if (roundTime <= 0f)
                    {
                        StopTimer();
                        countdownText.text = "0";
                        GameManager.Instance.UpdateGameState(GameManager.GameState.GameOver);
                    }
            }
        }
    }

    public void StopTimer()
    {
        enableTimer = false;
    }

    public void SetTimerColor(string colorString = "black")
    {
        countdownText.color = colorString switch
        {
            "black" => Color.black,
            "red" => Color.red,
            "green" => Color.green,
            _ => Color.black,
        };
    }
    public void HideTimer()
    {
        countdownText.enabled = false;
    }
}
