using UnityEngine.Events;

public class UIWatermelonField : UIFieldButton
{
    public event UnityAction ClickWatermelonFieldButton;

    public void OnClickWatermelonFieldButton()
    {
        ClickWatermelonFieldButton?.Invoke();
    }
}
