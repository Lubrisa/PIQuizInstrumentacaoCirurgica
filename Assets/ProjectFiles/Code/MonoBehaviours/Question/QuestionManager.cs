using Quiz.Data;
using ScriptableObjectArchitecture;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Quiz
{
    /// <summary>
    /// Component responsible for managing the game cycle.
    /// </summary>
    [RequireComponent(typeof(GameEventListener))]
    public class QuestionManager : MonoBehaviour
    {
        /// <summary>
        /// The manager instance.
        /// </summary>
        public static QuestionManager Instance { get; private set; }
        [Tooltip("Quantity of questions to be answered")]
        [SerializeField]
        private int m_questionQuantity;
        private int m_questionCount = 0;

        /// <summary>
        /// The list of questions answered.
        /// </summary>
        public List<QuestionData> QuestionsAnswered { get; private set; } = new List<QuestionData>();
        /// <summary>
        /// The current score of the player.
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// The list of questions that might be sorted.
        /// </summary>
        private List<QuestionData> m_questionsData;

        /// <summary>
        /// The current question that needs to be answered.
        /// </summary>
        private QuestionData m_currentQuestionData;

        [Tooltip("The event that will update the tool image")]
        [SerializeField] private SpriteGameEvent m_OnSurgeryToolUpdate;

        [Tooltip("The event that will be raised when the question is updated")]
        [SerializeField] private QuestionDataGameEvent m_OnQuestionDataUpdate;

        [Tooltip("The event that will be raised when the quiz scene is loaded")]
        [SerializeField] private GameEvent m_OnQuizScreenLoad;

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this) Destroy(gameObject);
        }

        /// <summary>
        /// The injection method for this component.
        /// </summary>
        [Zenject.Inject]
        private void Init(QuestionData[] questionsData) => m_questionsData = questionsData.ToList();

        private void Start()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }

        /// <summary>
        /// Sets the question context after the scene is loaded.
        /// </summary>
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            int questionID = new System.Random().Next(0, m_questionsData.Count);

            m_currentQuestionData = m_questionsData[questionID];

            m_OnSurgeryToolUpdate?.Raise(m_currentQuestionData.SurgeryToolImage);
            m_OnQuestionDataUpdate?.Raise(m_currentQuestionData);

            m_OnQuizScreenLoad?.Raise();

            m_questionCount++;
        }

        public void AddAnsweredQuestion(QuestionData answeredQuestion) => QuestionsAnswered.Add(answeredQuestion);

        public void IncreaseScore(int score) => Score += score;

        /// <summary>
        /// Loads the next question scene after listening to the trigger event.
        /// </summary>
        public void LoadNextQuestion()
        {
            m_questionsData.Remove(m_currentQuestionData);

            if (m_questionCount < m_questionQuantity) SceneManager.LoadScene(2);
            else
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
                SceneManager.LoadScene(3);
            }
        }

        public void ClearInstance()
        {
            Instance = null;
            Destroy(gameObject);
        }
    }
}