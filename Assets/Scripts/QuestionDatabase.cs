using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Assets/Databases/Question Database")]
public class QuestionDatabase : ScriptableObject {
    public List<Questions> allQuestions;
}
