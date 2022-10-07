using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderHealth : MonoBehaviour
{
    [SerializeField] private HarvesterHealth _harvesterHealth;
    [SerializeField] private HealthAlarm _healthAlarm;

    private Slider _slider;
    public UnityAction<float> HealthLevel;
    public UnityAction EndLevel;

    private int _maxValue;
    private int _minValue;
    private int _currentValue;

    public void Awake()
    {
        _slider = GetComponent<Slider>();
        _minValue = 0;
    }

    private void Start()
    {
        _maxValue = _harvesterHealth.MaxHealth;
        _currentValue = _harvesterHealth.Health;
        _slider.maxValue = _maxValue;
        _slider.minValue = _minValue;

        StartCoroutine(SetSliderValue(_currentValue));
    }

    public void OnEnable()
    {
        _harvesterHealth.ChangeHealth += SetParametrs;
    }

    public void OnDisable()
    {
        _harvesterHealth.ChangeHealth += SetParametrs;
    }

    public void SetParametrs(int value)
    {
        _currentValue = Mathf.Clamp(value, _minValue, _maxValue);
        HealthLevel?.Invoke(_currentValue);

        StartCoroutine(SetSliderValue(_currentValue));
    }

    public IEnumerator SetSliderValue(int health)
    {
        int step = 10;

        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, Time.deltaTime * step);
            yield return null;
        }
    }
}
