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
    [SerializeField] private Countdown countDown;
    private List<Question> allQuestions;
    private QuizCard _quizCard;

    public void Initialize()
    {
        allQuestions = MasterCatalogManager.Instance.GetAllQuestions();

        //foreach (var question in allQuestions)
        //{
        //    Debug.Log("Kyssäriteksti: " +question.questionText);
        //}
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
        var randomNum = Random.Range(0, allQuestions.Count);

        _quizCard = Instantiate(quizCardTemplate, quizCardTransform);
        _quizCard.Setup(allQuestions[randomNum]);
    }
}
