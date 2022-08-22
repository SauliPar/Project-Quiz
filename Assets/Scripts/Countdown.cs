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
        Time.timeScale = 1f;
        roundTime = time;
        enableTimer = true;
    }
    private void FixedUpdate()
    {
        if (enableTimer)
        {
            roundTime -= Time.fixedDeltaTime;
            countdownText.text = roundTime.ToString("F1");

            if (roundTime > 10f)
            {
                countdownText.color = Color.black;
            }
            else
            {
                countdownText.color = Color.red;
                if (roundTime <= 0f)
                {
                    countdownText.text = "0";
                    enableTimer = false;
                    GameManager.Instance.UpdateGameState(GameManager.GameState.GameOver);
                }
            }
        }
    }

    public void StopTimer()
    {
        enableTimer = false;
        countdownText.text = "0";
    }
}
