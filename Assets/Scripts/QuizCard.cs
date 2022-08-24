using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class QuizCard : MonoBehaviour
{
    public Animator animator;
    [Header("References")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI button0Text;
    [SerializeField] private TextMeshProUGUI button1Text;
    [SerializeField] private TextMeshProUGUI button2Text;
    [SerializeField] private TextMeshProUGUI button3Text;
    [SerializeField] private Countdown countdown;

    [Header("Attributes")]
    [SerializeField] private int PopCloseTime = 2;
    private int _correctSpot;
    private bool _correctAnswer;
    
    public void Setup(Question questionInfo)
    {
        _correctSpot = Random.Range(0, 3);
        QuestionPopUp();
        countdown.InitializeTimer(GameManager.Instance.GetRoundTime());

        questionText.text = questionInfo.questionText;
        switch (_correctSpot)
        {
            case 0:
                button0Text.text = questionInfo.rightOption;
                button1Text.text = questionInfo.wrongOption1;
                button2Text.text = questionInfo.wrongOption2;
                button3Text.text = questionInfo.wrongOption3;
                break;
            case 1:
                button0Text.text = questionInfo.wrongOption1;
                button1Text.text = questionInfo.rightOption;
                button2Text.text = questionInfo.wrongOption2;
                button3Text.text = questionInfo.wrongOption3;
                break;
            case 2:
                button0Text.text = questionInfo.wrongOption1;
                button1Text.text = questionInfo.wrongOption2;
                button2Text.text = questionInfo.rightOption;
                button3Text.text = questionInfo.wrongOption3;
                break;
            case 3:
                button0Text.text = questionInfo.wrongOption1;
                button1Text.text = questionInfo.wrongOption2;
                button2Text.text = questionInfo.wrongOption3;
                button3Text.text = questionInfo.rightOption;
                break;
        } 
    }

    public void OnButton0Pressed()
    {
        HandleButtonPress(0);
    }
    public void OnButton1Pressed()
    {
        HandleButtonPress(1);
    }
    public void OnButton2Pressed()
    {
        HandleButtonPress(2);
    }
    public void OnButton3Pressed()
    {
        HandleButtonPress(3);
    }
    private void HandleButtonPress(int buttonIndex)
    {
        if (buttonIndex == _correctSpot)
        {
            Debug.Log("OIKEIN MENI :D");
            countdown.StopTimer();
            _correctAnswer = true;
            Invoke(nameof(QuestionClose), PopCloseTime);
        }
        else
        {
            Debug.Log("V‰‰rin meni :DD");
            countdown.StopTimer();
            _correctAnswer = false;
            Invoke(nameof(QuestionClose), PopCloseTime);
        }
    }
    public void QuestionPopUp()
    {
        animator.SetTrigger("pop");
    }
    public void QuestionClose()
    {
        animator.SetTrigger("close");
        if (_correctAnswer)
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Correct);
        }
        else
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Wrong);
        }
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
