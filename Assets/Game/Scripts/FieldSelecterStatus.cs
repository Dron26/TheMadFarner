using UnityEngine;

public class FieldSelecterStatus : MonoBehaviour
{
    [SerializeField] private UICornFirstField _cornFirstField;
    [SerializeField] private UITomatoField _tomatoField;

    public int NumberSelectField { get; private set; }

    private void OnEnable()
    {
        _cornFirstField.ClickFirstFieldButton += OnClickkFirstFieldButton;
        _tomatoField.ClickTomatoFieldButton += OnCliickTomatoButton;
    }

    private void OnDisable()
    {
        _cornFirstField.ClickFirstFieldButton -= OnClickkFirstFieldButton;
        _tomatoField.ClickTomatoFieldButton -= OnCliickTomatoButton;
    }

    private void OnClickkFirstFieldButton()
    {
        NumberSelectField = 0;
    }

    private void OnCliickTomatoButton()
    {
        NumberSelectField = 1;
    }
}
