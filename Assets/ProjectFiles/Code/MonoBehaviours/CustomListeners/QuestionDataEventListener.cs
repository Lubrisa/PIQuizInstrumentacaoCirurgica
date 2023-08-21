using Quiz.Data;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "QuestionData Event Listener")]
    public sealed class QuestionDataEventListener : BaseGameEventListener<QuestionData, QuestionDataGameEvent, UnityEvent<QuestionData>>
    {
    }
}