using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonScript : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    int buttonPressed;
    protected int theRightAnswer;

    public void buttonOne(){
        Debug.Log("Button One pressed.");
        checkRightAnswer(0);
    }
    public void buttonTwo(){
        Debug.Log("Button Two pressed.");
        checkRightAnswer(1);
    }
    public void buttonThree(){
        Debug.Log("Button Three pressed.");
        checkRightAnswer(2);
    }
    public void buttonFour(){
        Debug.Log("Button Four pressed.");
        checkRightAnswer(3);
    }
    public void setRightAnswer(int rightButton){
        theRightAnswer = rightButton;
    }
    public int getRightAnswer(){
        return theRightAnswer;
    }
    public void checkRightAnswer(int buttonPressed){
        GameManagerScript gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        int theButtonPressed = buttonPressed;
        theRightAnswer = getRightAnswer();
        if (theButtonPressed == theRightAnswer){
            Debug.Log("Correct!");
            setColorGreen(1, theButtonPressed, theRightAnswer);
            gameManager.CorrectAnswer();
        }
        else {
            Debug.Log("Wrong");
            setColorGreen(0, theButtonPressed, theRightAnswer);
            setColorRed(0, theButtonPressed);
            gameManager.GameOver();
        }
    }
        void setColorGreen(int isRight, int theButtonPressed, int theRightAnswer){
            if (isRight == 1){
                switch(theButtonPressed){
                    case 0: GameObject.Find("Button1").GetComponent<RawImage>().color = Color.green;
                    break;
                    case 1: GameObject.Find("Button2").GetComponent<RawImage>().color = Color.green;
                    break;
                    case 2: GameObject.Find("Button3").GetComponent<RawImage>().color = Color.green;
                    break;
                    case 3: GameObject.Find("Button4").GetComponent<RawImage>().color = Color.green;
                    break;
                    }
            } else if(isRight == 0){
                switch(theRightAnswer){
                    case 0: GameObject.Find("Button1").GetComponent<RawImage>().color = Color.green;
                    break;
                    case 1: GameObject.Find("Button2").GetComponent<RawImage>().color = Color.green;
                    break;
                    case 2: GameObject.Find("Button3").GetComponent<RawImage>().color = Color.green;
                    break;
                    case 3: GameObject.Find("Button4").GetComponent<RawImage>().color = Color.green;
                    break;
                    }
            }
        }
        void setColorRed(int isRight, int theButtonPressed){
            if(isRight == 0){
                switch(theButtonPressed){
                    case 0: GameObject.Find("Button1").GetComponent<RawImage>().color = Color.red;
                    break;
                    case 1: GameObject.Find("Button2").GetComponent<RawImage>().color = Color.red;
                    break;
                    case 2: GameObject.Find("Button3").GetComponent<RawImage>().color = Color.red;
                    break;
                    case 3: GameObject.Find("Button4").GetComponent<RawImage>().color = Color.red;
                    break;
                    }
            }
        }
}