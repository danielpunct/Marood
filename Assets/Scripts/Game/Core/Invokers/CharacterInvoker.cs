using UnityEngine;

class CharacterInvoker : MonoBehaviour
{
    void Awake()
    {
        EventManager.StartListening(cEvents.INVOKE_CHARACTER, OnInvokeCharacter);
    }

    void OnInvokeCharacter(object tag)
    {
        var invokerTag = tag as CharacterInvokerTag;

        var go = Instantiate(Resources.Load<GameObject>(invokerTag.Character.ToString()));

        var cm = go.AddComponent<CharacterEntity>();

        cm.Init(GridBoard.Instance.GetTile(invokerTag.X, invokerTag.Y), invokerTag.Character);
    }
}

class CharacterInvokerTag
{
    public int X;
    public int Y;
    public cCharacters Character;
}
