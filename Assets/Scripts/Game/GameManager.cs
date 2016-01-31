using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    class GameManager : MonoBehaviour
    {
        void Awake()
        {
            gameObject.AddComponent<EventManager>();
        }

        
    }
}
