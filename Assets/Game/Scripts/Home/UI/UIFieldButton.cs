using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public abstract class UIFieldButton : MonoBehaviour
{
    protected Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }
}
