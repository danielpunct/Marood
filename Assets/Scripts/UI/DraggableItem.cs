using UnityEngine;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour
{
    public cCharacters prefabName;

    Animator uiAnimator;

    void Awake()
    {
        uiAnimator = GetComponent<Animator>();
    }

    public void UiItemChecked()
    {
        bool isChecked = GetComponent<Toggle>().isOn;

        var cam  =Camera.main.GetComponent<CameraDrag>();
        cam.Direction = isChecked;

        UIManager.IsInMenu = isChecked;
        UIManager.CurrentCharacterTag = prefabName;
        uiAnimator.SetTrigger(isChecked ? "Checked" : "Normal");
    }
}
