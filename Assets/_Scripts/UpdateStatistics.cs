using TMPro;
using UnityEngine;

namespace _Scripts
{
    public class UpdateStatistics : MonoBehaviour
    {
        [Header("Player One References")]
        [SerializeField] private TextMeshProUGUI playerOneCorrectAnswerText;
        [SerializeField] private TextMeshProUGUI playerOneWrongAnswerText;
        [SerializeField] private TextMeshProUGUI playerOnePercentageText;
    
        [Header("Player Two References")]
        [SerializeField] private TextMeshProUGUI playerTwoCorrectAnswerText;
        [SerializeField] private TextMeshProUGUI playerTwoWrongAnswerText;
        [SerializeField] private TextMeshProUGUI playerTwoPercentageText;

        public void UpdatePlayerAnswers(int playerNumber, int totalRightAnswers, int totalWrongAnswers)
        {
            if (playerNumber == 1)
            {
                playerOneCorrectAnswerText.text = totalRightAnswers.ToString();
                playerOneWrongAnswerText.text = totalWrongAnswers.ToString();
            }
            else
            {
                playerTwoCorrectAnswerText.text = totalRightAnswers.ToString();
                playerTwoWrongAnswerText.text = totalWrongAnswers.ToString();
            }
        }

        public void UpdatePlayerPercentages(int playerNumber, float totalPercentage)
        {
            if (playerNumber == 1)
            {
                playerOnePercentageText.text = totalPercentage.ToString("N2");
            }
            else
            {
                playerTwoPercentageText.text = totalPercentage.ToString("N2");
            }
        }
    }
}
