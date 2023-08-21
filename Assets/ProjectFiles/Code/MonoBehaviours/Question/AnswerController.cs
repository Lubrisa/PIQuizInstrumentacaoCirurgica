using Quiz.Data;
using ScriptableObjectArchitecture;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    /// <summary>
    /// Component responsible for controlling the answer buttons functions.
    /// </summary>
    public class AnswerController : MonoBehaviour
    {
        private static List<int> m_answersIDSave = new();
        private int m_answerID;

        [Tooltip("The event that will be raised when the button is clicked")]
        [SerializeField] private GameEvent m_OnNextQuestionCall;

        /// <summary>
        /// The data of the current question being answered.
        /// </summary>
        private QuestionData m_currentQuestion;

        /// <summary>
        /// Updates how the button is shown and behaves accordingly with the data given.
        /// </summary>
        /// <param name="currentQuestion"> The question from wich the data will be used. </param>
        public void UpdateAnswerData(QuestionData currentQuestion)
        {
            m_currentQuestion = currentQuestion;

            m_answerID = SortID();

            TMP_Text text = GetComponentInChildren<TextMeshProUGUI>();
            text.text = currentQuestion.Answers[m_answerID].Answer;

            Button button = GetComponent<Button>();
            if (currentQuestion.Answers[m_answerID].IsTrue) button.onClick.AddListener(RightAnswer);
            else button.onClick.AddListener(WrongAnswer);
        }

        private int SortID()
        {
            int ID;
            do
            {
                ID = new System.Random().Next(0, 4);
            }
            while (m_answersIDSave.Contains(ID));
            m_answersIDSave.Add(ID);

            return ID;
        }

        private void SendAnswerData()
        {
            m_currentQuestion.SetPlayerAnswer(m_currentQuestion.Answers[m_answerID]);

            QuestionManager.Instance.AddAnsweredQuestion(m_currentQuestion);
        }

        /// <summary>
        /// Called when the player clicks in the right answer.
        /// </summary>
        private void RightAnswer()
        {
            SendAnswerData();
            QuestionManager.Instance.IncreaseScore(1);
            m_OnNextQuestionCall.Raise();
        }

        /// <summary>
        /// Called when the player clicks in the wrong answer.
        /// </summary>
        private void WrongAnswer()
        {
            SendAnswerData();
            m_OnNextQuestionCall.Raise();
        }

        /// <summary>
        /// Disables the interaction from the button.
        /// </summary>
        public void DisableButton()
        {
            m_answersIDSave.Clear();
            GetComponent<Button>().interactable = false;
        }
    }
}