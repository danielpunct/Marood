using UnityEngine;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour
{
    public cCards prefabName;

    Animator uiAnimator;

    void Start()
    {
        uiAnimator = GetComponent<Animator>();
        EventManager.StartListening(cEvents.SM_END_MENU_SELECTION, OnEndMenuSelection);


    }

    public void UiItemChecked()
    {
        bool isChecked = GetComponent<Toggle>().isOn;
        uiAnimator.SetTrigger(isChecked ? "Checked" : "Normal");

        UiController.SetInMenu(isChecked ? prefabName : cCards.None);

    }

    public void OnEndMenuSelection(object notUsed)
    {
        GetComponent<Toggle>().isOn = false;
        uiAnimator.SetTrigger( "Normal");
    }
}
