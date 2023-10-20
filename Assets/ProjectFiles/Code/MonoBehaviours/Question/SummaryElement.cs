using Quiz.Data;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    public class SummaryElement : MonoBehaviour
    {
        public void FillInfo(QuestionData answeredQuestionData)
        {
            TMP_Text text = GetComponentInChildren<TextMeshProUGUI>();
            Image image = GetComponentInChildren<Image>();

            image.sprite = answeredQuestionData.SurgeryToolImage;

            StringBuilder stringBuilder = new();
            foreach (var answerData in answeredQuestionData.Answers)
            {
                if (answerData.IsTrue)
                {
                    stringBuilder.Append("Resposta: " + answerData.Answer + "\n");
                    break;
                }
            }
            stringBuilder.Append("Sua Resposta: ");
            if (answeredQuestionData.Answers[4].Answer == string.Empty) stringBuilder.Append("---");
            else stringBuilder.Append(answeredQuestionData.Answers[4].Answer);

            text.text = stringBuilder.ToString();
        }
    }
}