using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class GameManager : MonoBehaviour
    {
        void Awake()
        {
            gameObject.AddComponent<EventManager>();
            gameObject.AddComponent<CharacterInvoker>();
        }

        void Start()
        {
            EventManager.TriggerEvent(cEvents.INVOKE_CHARACTER, new CharacterInvokerTag() { Character = "Character", X = -3, Y = 6 } );
        }
    }
}
