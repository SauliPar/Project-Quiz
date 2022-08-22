using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizCard : MonoBehaviour
{
    public Animator animator;



    public void QuestionPopUp()
    {
        animator.SetTrigger("pop");
    }
    public void QuestionClose()
    {
        animator.SetTrigger("close");
    }
}
