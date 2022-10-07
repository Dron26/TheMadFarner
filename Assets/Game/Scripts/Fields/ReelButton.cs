using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ReelButton : MonoBehaviour
{
    private Button _button;
    [SerializeField] private GameObject _indicationOn;
    [SerializeField] private GameObject _indicationOff;
    [SerializeField] private Reel _rell;

    private bool _isActive;

    public UnityAction ReelActive;

    private void Awake()
    {
        _isActive = false;
        _button = GetComponent<Button>();
        _indicationOn.SetActive(_isActive);
        _indicationOff.SetActive(!_isActive);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnReelActive);
        _rell.EndChangeRotation += OnEndChangeRotation;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnReelActive);
        _rell.EndChangeRotation -= OnEndChangeRotation;
    }

    private void OnReelActive()
    {
        ReelActive?.Invoke();
        _button.enabled = false;
        _isActive = !_isActive;
        _indicationOn.SetActive(_isActive);
        _indicationOff.SetActive(!_isActive);
    }

    private void OnEndChangeRotation()
    {
        _button.enabled = true;
    }
}
