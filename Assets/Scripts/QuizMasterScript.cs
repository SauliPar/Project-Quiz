using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizMasterScript : MonoBehaviour
{
    protected string wrongAnswer1;
    protected string wrongAnswer2;
    protected string wrongAnswer3;
    protected string rightAnswer;
    public Text buttonOneText;
    public Text buttonTwoText;
    public Text buttonThreeText;
    public Text buttonFourText;
    public TMP_Text questionText;

    public void displayQuestion(Questions i){
        ButtonScript buttonController = GameObject.FindGameObjectWithTag("ButtonController").GetComponent<ButtonScript>();
        int rngNumber = Random.Range(0,3);
        questionText.text = i.questionName;
        wrongAnswer1 = i.wrongOption1;
        wrongAnswer2 = i.wrongOption2;
        wrongAnswer3 = i.wrongOption3;
        rightAnswer = i.rightOption;
        switch(rngNumber){
            case 0: buttonOneText.text = rightAnswer;
                    buttonTwoText.text = wrongAnswer1;
                    buttonThreeText.text = wrongAnswer2;
                    buttonFourText.text = wrongAnswer3;
                    buttonController.setRightAnswer(0);
                    break;
            case 1: buttonTwoText.text = rightAnswer;
                    buttonThreeText.text = wrongAnswer2;
                    buttonFourText.text = wrongAnswer1;
                    buttonOneText.text = wrongAnswer3;
                    buttonController.setRightAnswer(1);
                    break;
            case 2: buttonThreeText.text = rightAnswer;
                    buttonFourText.text = wrongAnswer3;
                    buttonOneText.text = wrongAnswer2;
                    buttonTwoText.text = wrongAnswer1;
                    buttonController.setRightAnswer(2);
                    break;
            case 3: buttonFourText.text = rightAnswer;
                    buttonOneText.text = wrongAnswer2;
                    buttonTwoText.text = wrongAnswer1;
                    buttonThreeText.text = wrongAnswer3;
                    buttonController.setRightAnswer(3);
                    break;
        }
    } 
}
