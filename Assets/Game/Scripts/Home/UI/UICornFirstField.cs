using UnityEngine.Events;
using UnityEngine.UI;

public class UICornFirstField : UIFieldButton
{
    public event UnityAction ClickFirstFieldButton;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void OnClickCornFirstFieldButton()
    {
        ClickFirstFieldButton?.Invoke();
    }
}
