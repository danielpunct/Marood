using UnityEngine;

namespace Assets.Scripts.Game
{
    class CharacterInvoker : MonoBehaviour
    {
        GridBoard boardGO;

        void Awake()
        {
            boardGO = GameObject.FindObjectOfType<GridBoard>();

            EventManager.StartListening(cEvents.INVOKE_CHARACTER, OnInvokeCharacter);
        }

        void OnInvokeCharacter(object tag)
        {
            var invokerTag = tag as CharacterInvokerTag;

            var go = Instantiate(Resources.Load<GameObject>(invokerTag.Character));

            var cm = go.AddComponent<CharacterManager>();
            go.AddComponent<CharacterMoveBehaviour>();
            go.AddComponent<CharacterVisualization>();

            var t = go.transform;
            t.localPosition = boardGO.CalcWorldPosFromCoords(invokerTag.X, invokerTag.Y);
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
            t.SetParent(boardGO.transform);
            go.layer = boardGO.gameObject.layer;
        }
    }

    class CharacterInvokerTag
    {
        public int X;
        public int Y;
        public string Character;
    }
}