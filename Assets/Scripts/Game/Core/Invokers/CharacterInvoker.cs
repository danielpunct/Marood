using UnityEngine;

public class CharacterInvoker : MonoBehaviour
{
    void Awake()
    {
        EventManager.StartListening(cEvents.INVOKE_CHARACTER, OnInvokeCharacter);
       // EventManager.StartListening(cEvents.USER_END_DRAG_ON_TILE, GenerateCharacterFromPrefab);
    }

    void OnInvokeCharacter(object tag)
    {
        var invokerTag = tag as CharacterInvokerTag;

        var go = Instantiate(Resources.Load<GameObject>(invokerTag.Character.ToString()));

        var cm = go.AddComponent<CharacterEntity>();

        cm.Init(GridBoard.Instance.GetTile(invokerTag.X, invokerTag.Y), invokerTag.Character);
    }

    public void ShowPreviewObject(TileInteraction tInteraction)
    {
        if (previewGO == null)
        {
            var go = Instantiate(Resources.Load<GameObject>(UiController.CurrentCharacterTag.ToString()));
            previewGO = go;

            var bidp = go.AddComponent<BuildItemDragPreview>();

            bidp.Init(tInteraction.GridTile.X, tInteraction.GridTile.Y);
        }
    }

    public void GenerateCharacterFromPrefab()
    {
        var preview = previewGO.GetComponent<BuildItemDragPreview>();

        var cm = previewGO.AddComponent<CharacterEntity>();

        cm.Init(GridBoard.Instance.GetTile(preview.X, preview.Y), UiController.CurrentCharacterTag);

        Destroy(preview);

        previewGO = null;
    }       

    public static GameObject previewGO;
}

class CharacterInvokerTag
{
    public int X;
    public int Y;
    public cCards Character;
}