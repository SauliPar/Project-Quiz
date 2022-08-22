using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizMasterScript : MonoBehaviour
{    
    [Header("References")]
    [SerializeField] private GameObject buttonTemplate;
    [SerializeField] private QuizCard quizCard;
    [SerializeField] private TextMeshProUGUI questionText;

    private List<Question> allQuestions;

    public void Initialize()
    {
        Debug.Log("alustettiin quizmasterscript");
        
        allQuestions = MasterCatalogManager.Instance.GetAllQuestions();
        foreach (var question in allQuestions)
        {
            Debug.Log("Kyssäriteksti: " +question.questionText);
        }
    }

    public void AskQuestion()
    {
        var randomNum = Random.Range(0, allQuestions.Count);

        quizCard.enabled = true;
        quizCard.QuestionPopUp();

        questionText.text = allQuestions[randomNum].questionText;
    }
}
