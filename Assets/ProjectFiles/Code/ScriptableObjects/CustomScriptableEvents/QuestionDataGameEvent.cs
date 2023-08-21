using Quiz.Data;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    [CreateAssetMenu(
        fileName = "BoolGameEvent.asset",
        menuName = SOArchitecture_Utility.GAME_EVENT + "QuestionData",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS + 5)]
    public sealed class QuestionDataGameEvent : GameEventBase<QuestionData>
    {
    }
}