using UnityEngine;
using Zenject;

namespace Quiz.Data
{
    public class QuestionsDataInstaller : MonoInstaller
    {
        [Tooltip("The data that will be injected in every script that needs the questions data")]
        [SerializeField] private QuestionData[] m_questionsData;

        public override void InstallBindings() => Container.Bind<QuestionData[]>().FromInstance(m_questionsData).AsTransient();
    }
}