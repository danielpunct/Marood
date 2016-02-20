using UnityEngine;

namespace Assets.Scripts.Game
{
    class CharacterInvoker : MonoBehaviour
    {
        void Awake()
        {
            EventManager.StartListening(cEvents.INVOKE_CHARACTER, OnInvokeCharacter);
        }

        void OnInvokeCharacter(object tag)
        {
            var invokerTag = tag as CharacterInvokerTag;

            var go = Instantiate(Resources.Load<GameObject>(invokerTag.Character));

            var cm = go.AddComponent<CharacterManager>();

            cm.Init(GridBoard.Instance.GetTile(invokerTag.X, invokerTag.Y).GridTile);
        }
    }

    class CharacterInvokerTag
    {
        public int X;
        public int Y;
        public string Character;
    }
}