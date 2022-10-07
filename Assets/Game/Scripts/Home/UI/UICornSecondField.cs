using UnityEngine.Events;

public class UICornSecondField : UIFieldButton
{
    public event UnityAction ClickCornSecondFieldButton;

    public void OnClickCornSecondFieldButton()
    {
        ClickCornSecondFieldButton?.Invoke();
    }
}