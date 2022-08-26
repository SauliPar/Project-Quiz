using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizMasterScript : MonoBehaviour
{    
    [Header("References")]
    [SerializeField] private QuizCard quizCardTemplate;
    [SerializeField] private Transform quizCardTransform;
    private int _questionCounter = 0;
    private List<Question> allQuestions;
    private QuizCard _quizCard;
    private List<Question> _unansweredQuestions;

    public void Initialize()
    {
        allQuestions = MasterCatalogManager.Instance.GetAllQuestions();
        _unansweredQuestions = allQuestions;
        ShuffleList();
        foreach (var question in allQuestions)
        {
            Debug.Log("Kyssäriteksti: " + question.questionText);
        }
    }

    public void DestroyQuizCard()
    {
        Destroy(_quizCard);
    }

    public void AskQuestion()
    {
        if (_quizCard != null)
        {
            Destroy(_quizCard);
        }

        if (_questionCounter < _unansweredQuestions.Count)
        {
            _quizCard = Instantiate(quizCardTemplate, quizCardTransform);
            _quizCard.Setup(_unansweredQuestions[_questionCounter]);
        }
        else
        {
            Debug.Log("Kyssärit shuffleen");
            ShuffleList();
            
            _questionCounter = 0;
            _quizCard = Instantiate(quizCardTemplate, quizCardTransform);
            _quizCard.Setup(_unansweredQuestions[_questionCounter]);
        }
        _questionCounter++;
    }
    private void ShuffleList()
    {
        for (int i = 0; i < _unansweredQuestions.Count; i++)
        {
            var temp = _unansweredQuestions[i];
            int randomIndex = Random.Range(i, _unansweredQuestions.Count);
            _unansweredQuestions[i] = _unansweredQuestions[randomIndex];
            _unansweredQuestions[randomIndex] = temp;
        }
    }
}
