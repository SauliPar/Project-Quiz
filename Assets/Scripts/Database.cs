using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Database : MonoBehaviour
{
    public QuestionDatabase questions;
    private static Database instance;

    private void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    public static Questions GetQuestionById(string Id){
        return instance.questions.allQuestions.FirstOrDefault(i => i.questionId == Id);
    }
    public static Questions GetRandomQuestion(){
        return instance.questions.allQuestions[Random.Range(0, instance.questions.allQuestions.Count())];
    }
}
