using UnityEngine;

namespace ScriptableObjectArchitecture
{
    [System.Serializable]
    [CreateAssetMenu(
        fileName = "SpriteGameEvent.asset",
        menuName = SOArchitecture_Utility.GAME_EVENT + "Sprite",
        order = SOArchitecture_Utility.ASSET_MENU_ORDER_EVENTS + 5)]
    public sealed class SpriteGameEvent : GameEventBase<Sprite>
    {
    }
}