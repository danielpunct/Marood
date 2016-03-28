using UnityEngine;

public class UiController : MonoBehaviour
{
    void Awake()
    {
        EventManager.StartListening(cEvents.USER_START_DRAG_ON_TILE, OnStartDrag);
        EventManager.StartListening(cEvents.USER_END_DRAG_ON_TILE, OnEndDrag);


    }

    public static cCards CurrentCharacterTag { get; private set; }

    public static void SetInMenu(cCards selected)
    {
        var cam = Camera.main.GetComponent<CameraDrag>();
        bool isChecked = selected != cCards.None;

        cam.Direction = isChecked;
        if(isChecked)
        {
            GameSuperviser.Instance.SM_General.MenuItemSelected();
        }
        else
        {
            GameSuperviser.Instance.SM_General.MenuSelectionFinishded();
        }

        CurrentCharacterTag = selected;
    }

    public void OnStartDrag(object tag)
    {
        var tileInteraction = tag as TileInteraction;
        if(GameSuperviser.Instance.SM_General.CurrentState == StatesGeneralSM.InMenu)
        {
            GameSuperviser.Invoker.ShowPreviewObject(tileInteraction);
        }
    }

    public void OnEndDrag(object tag)
    {
        var tEnt = tag as TileEntity;

        if (GameSuperviser.Instance.SM_General.CurrentState == StatesGeneralSM.InMenu)
        {
            GameSuperviser.Invoker.GenerateCharacterFromPrefab();
            SetInMenu(cCards.None);
        }
        else
        {
            EventManager.TriggerEvent(cEvents.USER_SEND_TILE, tEnt);
        }
    }
}
