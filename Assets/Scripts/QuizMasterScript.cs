using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizMasterScript : MonoBehaviour
{    
    [Header("References")]
    [SerializeField] private GameObject buttonTemplate;
    [SerializeField] private Transform[] buttonTransforms;
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
      
        var questionSlot0 = Instantiate(buttonTemplate, buttonTransforms[0]);
        questionSlot0.GetComponent<ButtonScript>().Setup(allQuestions[randomNum].wrongOption1, "false", HandleButtonPress);

        var questionSlot1 = Instantiate(buttonTemplate, buttonTransforms[1]);
        questionSlot1.GetComponent<ButtonScript>().Setup(allQuestions[randomNum].wrongOption2, "false", HandleButtonPress);

        var questionSlot2 = Instantiate(buttonTemplate, buttonTransforms[2]);
        questionSlot2.GetComponent<ButtonScript>().Setup(allQuestions[randomNum].wrongOption3, "false", HandleButtonPress);

        var questionSlot3 = Instantiate(buttonTemplate, buttonTransforms[3]);
        questionSlot3.GetComponent<ButtonScript>().Setup(allQuestions[randomNum].rightOption, "true", HandleButtonPress);
    }
    private void HandleButtonPress(string isCorrect)
    {
        if (isCorrect == "false")
        {
            Debug.Log("WRONG");
        }
        if (isCorrect == "true")
        {
            Debug.Log("CORRECT!");
        }
    }
}
