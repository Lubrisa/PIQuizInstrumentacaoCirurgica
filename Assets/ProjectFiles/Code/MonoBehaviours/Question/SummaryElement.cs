using Quiz.Data;
using System.Text;
using TMPro;
using UnityEngine;

namespace Quiz
{
    public class SummaryElement : MonoBehaviour
    {
        public void FillInfo(QuestionData answeredQuestionData)
        {
            TMP_Text text = GetComponentInChildren<TextMeshProUGUI>();

            StringBuilder stringBuilder = new();
            stringBuilder.Append("Pergunta: " + answeredQuestionData.Question + "\n");
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