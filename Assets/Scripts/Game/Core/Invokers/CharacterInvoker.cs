using UnityEngine;

class CharacterInvoker : MonoBehaviour
{
    void Awake()
    {
        EventManager.StartListening(cEvents.INVOKE_CHARACTER, OnInvokeCharacter);
        EventManager.StartListening(cEvents.USER_START_DRAG_ON_TILE, ShowPreviewObject);
        EventManager.StartListening(cEvents.USER_END_DRAG_ON_TILE, GenerateCharacterFromPrefab);
    }

    void OnInvokeCharacter(object tag)
    {
        var invokerTag = tag as CharacterInvokerTag;

        var go = Instantiate(Resources.Load<GameObject>(invokerTag.Character.ToString()));

        var cm = go.AddComponent<CharacterEntity>();

        cm.Init(GridBoard.Instance.GetTile(invokerTag.X, invokerTag.Y), invokerTag.Character);
    }

    void ShowPreviewObject(object tag)
    {
        TileEntity tEnt = tag as TileEntity;

        if (previewGO == null)
        {
            var go = Instantiate(Resources.Load<GameObject>(UIManager.CurrentCharacterTag.ToString()));
            previewGO = go;

            var bidp = go.AddComponent<BuildItemDragPreview>();

            bidp.Init(tEnt.InteractionComponent.GridTile.X, tEnt.InteractionComponent.GridTile.Y);
        }
    }

    void GenerateCharacterFromPrefab(object tag)
    {
        var preview = previewGO.GetComponent<BuildItemDragPreview>();

        TileEntity tEnt = tag as TileEntity;

        var cm = previewGO.AddComponent<CharacterEntity>();

        cm.Init(GridBoard.Instance.GetTile(preview.X, preview.Y), UIManager.CurrentCharacterTag);

        previewGO = null;
        UIManager.IsInMenu = false;
    }

    public static GameObject previewGO;
}

class CharacterInvokerTag
{
    public int X;
    public int Y;
    public cCharacters Character;
}