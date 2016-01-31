using UnityEngine;

namespace Assets.Scripts.Game
{
    class CharacterInvoker : MonoBehaviour
    {
        GridManager boardGO;

        void Awake()
        {
            boardGO = GameObject.FindObjectOfType<GridManager>();

            EventManager.StartListening(cEvents.INVOKE_CHARACTER, OnInvokeCharacter);
        }

        void OnInvokeCharacter(object tag)
        {
            var invokerTag = tag as CharacterInvokerTag;

            var go = Instantiate(Resources.Load<GameObject>(invokerTag.Character));

            var t = go.transform;
            t.SetParent(boardGO.transform);
            t.localPosition = boardGO.CalcWorldCoord(new Vector2(invokerTag.X, invokerTag.Y));
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
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