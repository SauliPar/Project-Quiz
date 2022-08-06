using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Assets/Question")]
public class Question : ScriptableObject {
    public string questionId;
    [TextArea]
    public string questionText;

    public string wrongOption1;
    public string wrongOption2;
    public string wrongOption3;
    public string rightOption;
}
