using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    public float restartDelay = 2f;
    private Countdown countDown;
    private PopUpSystem pop;
    private QuizMasterScript quiz;
    public int idCounter = 1;

    private void Start()
    {
        pop = GetComponent<PopUpSystem>();
        quiz = GameObject.FindGameObjectWithTag("QuizMaster").GetComponent<QuizMasterScript>();
        countDown = GetComponent<Countdown>();
        Invoke("startGame", restartDelay);
    }
    private void startGame()
    { 
        pop.PopUp();
        countDown.enableTimer = true;
        quiz.displayQuestion(Database.GetQuestionById(idCounter.ToString()));
    }
    public void CorrectAnswer(){
        Debug.Log("Correct!");
        countDown.enableTimer = false;
        idCounter = idCounter + 1;
        WaitingPeriod();
    }
    private void WaitingPeriod()
    {
        //buttonController.SetActive(false);
        Invoke("nextRound", restartDelay);
    }
    private void NextRound()
    {
        Debug.Log("Tultiin tänne");
        Debug.Log(idCounter);
        quiz.displayQuestion(Database.GetQuestionById(idCounter.ToString()));
    }
    public void WinningTheGame()
    {
        Debug.Log("Congrats!");
        countDown.enableTimer = false;
        Invoke("Restart", restartDelay);
    }
    public void GameOver()
    {
        Debug.Log("Game Over");
        countDown.enableTimer = false;
        Invoke("Restart", restartDelay);
    }
    private void Restart()
    {
        Destroy(pop.gameObject);
        Destroy(quiz.gameObject);
        Destroy(countDown.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}