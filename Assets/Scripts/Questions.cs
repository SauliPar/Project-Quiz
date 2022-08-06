using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Assets/Question")]
public class Questions : ScriptableObject {
    public string questionId;
    [TextArea]
    public string questionName;
    public string wrongOption1;
    public string wrongOption2;
    public string wrongOption3;
    public string rightOption;
}
