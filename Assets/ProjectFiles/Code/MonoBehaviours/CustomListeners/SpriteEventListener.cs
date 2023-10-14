using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Sprite Event Listener")]
    public sealed class SpriteEventListener : BaseGameEventListener<Sprite, SpriteGameEvent, UnityEvent<Sprite>>
    {
    }
}
