using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class QuizCard : MonoBehaviour
{
    public Animator animator;
    [Header("Text Fields")]
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private TextMeshProUGUI button0Text;
    [SerializeField] private TextMeshProUGUI button1Text;
    [SerializeField] private TextMeshProUGUI button2Text;
    [SerializeField] private TextMeshProUGUI button3Text;
    [SerializeField] private Countdown countdown;
    
    [Header("Images")]
    [SerializeField] private Image button0image;
    [SerializeField] private Image button1image;
    [SerializeField] private Image button2image;
    [SerializeField] private Image button3image;

    [Header("Buttons")]
    [SerializeField] private Button[] buttons;

    [Header("Attributes")]
    [SerializeField] private float PopCloseTime = 3f;
    [SerializeField] private float RevealWrongAnswerTime = 2f;
    [SerializeField] private float RevealRightAnswerTime = 2f;
    private int _correctSpot;
    private bool _correctAnswer;
    private int _selectedButtonIndex;
    private ColorBlock _normalColors;
    
    public void Setup(Question questionInfo)
    {
        _normalColors = buttons[0].colors;
        foreach (Button button in buttons)
        {
            button.colors = _normalColors;
        }
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
        _selectedButtonIndex = buttonIndex;
        countdown.StopTimer();
        if (_selectedButtonIndex == _correctSpot)
        {
            _correctAnswer = true;
        }
        else
        {
            _correctAnswer = false;
        }
        Invoke(nameof(RevealAnswer), RevealRightAnswerTime);
    }
    public void QuestionPopUp()
    {
        animator.SetTrigger("pop");
    }
    public void QuestionPopOut()
    {
        animator.SetTrigger("close");
    }
    
    public void RevealAnswer()
    {
        if (_correctAnswer)
        {
            switch (_correctSpot)
            {
                case 0:
                    button0image.color = Color.green;
                    break;
                case 1:
                    button1image.color = Color.green;
                    break;
                case 2:
                    button2image.color = Color.green;
                    break;
                case 3:
                    button3image.color = Color.green;
                    break;
            }

            GameManager.Instance.UpdateGameState(GameManager.GameState.Correct);
        }
        else
        {
            var changedColors = _normalColors;
            changedColors.selectedColor = Color.red;
            foreach (Button button in buttons)
            {
                button.colors = changedColors;
            }
            Invoke(nameof(RevealWrongAnswer), RevealWrongAnswerTime);
        }
        Invoke(nameof(QuestionPopOut), PopCloseTime);
    }

    private void RevealWrongAnswer()
    {
        switch (_correctSpot)
        {
            case 0:
                button0image.color = Color.green;
                break;
            case 1:
                button1image.color = Color.green;
                break;
            case 2:
                button2image.color = Color.green;
                break;
            case 3:
                button3image.color = Color.green;
                break;
        }

        GameManager.Instance.UpdateGameState(GameManager.GameState.Wrong);
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
