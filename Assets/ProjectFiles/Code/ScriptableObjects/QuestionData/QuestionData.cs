using UnityEngine;

namespace Quiz.Data
{
    /// <summary>
    /// Data for questions.
    /// </summary>
    [CreateAssetMenu(fileName = "ID_QuestionData", menuName = "Data/QuestionData")]
    public class QuestionData : ScriptableObject
    {
        /// <summary>
        /// The question text.
        /// </summary>
        [field: SerializeField] public string Question { get; private set; }

        /// <summary>
        /// The array of possible answers.
        /// </summary>
        [field: SerializeField] public AnswerData[] Answers { get; private set; } = new AnswerData[5];

        public void ResetPlayerAnswer() => Answers[4] = new();

        public void SetPlayerAnswer(AnswerData answer) => Answers[4] = Answers[4].Answer == string.Empty ? answer : Answers[4];
    }

    /// <summary>
    /// Data for answers.
    /// </summary>
    [System.Serializable]
    public sealed class AnswerData
    {
        /// <summary>
        /// The answer text.
        /// </summary>
        [field: SerializeField] public string Answer { get; private set; }

        /// <summary>
        /// Check if the answer is a true sentence.
        /// </summary>
        [field: SerializeField] public bool IsTrue { get; private set; }
    }
}