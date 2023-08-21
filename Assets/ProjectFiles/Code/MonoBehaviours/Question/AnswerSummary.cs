using UnityEngine;

namespace Quiz
{
    public class AnswerSummary : MonoBehaviour
    {
        [SerializeField] private SummaryElement summaryElement;

        private void Start()
        {
            foreach (var questionData in QuestionManager.Instance.QuestionsAnswered)
            {
                SummaryElement instance = Instantiate(summaryElement, transform);
                instance.FillInfo(questionData);
                questionData.ResetPlayerAnswer();
            }
        }
    }
}