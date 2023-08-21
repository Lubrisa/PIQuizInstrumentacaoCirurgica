using CustomTools;
using Quiz.Data;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

namespace Quiz
{
    /// <summary>
    /// Component responsible for controlling the time
    /// the player have to answer the question.
    /// </summary>
    [RequireComponent(typeof(QuestionDataEventListener))]
    public class QuestionTimer : MonoBehaviour
    {
        [Tooltip("The time that the player will have until he looses the chance to answer the question")]
        [SerializeField] private float m_maxTime;

        [Tooltip("The event that will be raised when the time run out")]
        [SerializeField] private GameEvent m_OnNextQuestionCall;

        private QuestionData m_currentQuestionData;

        /// <summary>
        /// The timer that will count the time.
        /// </summary>
        private readonly GameTimer m_timer = new();

        private Image m_timerImage;

        /// <summary>
        /// Starts the timer countdown after listening to the trigger event.
        /// </summary>
        public void StartTimer(QuestionData currentQuestionData)
        {
            m_currentQuestionData = currentQuestionData;
            m_timerImage = GetComponent<Image>();

            m_timer.AddOnTickListener((s, e) => ShowLeftingTime(e.RemainingTime));
            m_timer.StartTimer(m_maxTime, this, (s, e) => Continue());
        }

        /// <summary>
        /// Makes the timer show the time left.
        /// </summary>
        /// <param name="remainingTime"> The time left to load the next question. </param>
        private void ShowLeftingTime(float remainingTime) => m_timerImage.fillAmount = remainingTime / m_maxTime;

        /// <summary>
        /// Makes the timer invoke an event that will trigger the transition.
        /// </summary>
        private void Continue()
        {
            QuestionManager.Instance.AddAnsweredQuestion(m_currentQuestionData);

            m_OnNextQuestionCall?.Raise();
        }
    }
}