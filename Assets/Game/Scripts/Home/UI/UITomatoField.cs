using UnityEngine.Events;

public class UITomatoField : UIFieldButton
{
    public event UnityAction ClickTomatoFieldButton;

    public void OnClickTomatoFieldButton()
    {
        ClickTomatoFieldButton?.Invoke();
    }
}
