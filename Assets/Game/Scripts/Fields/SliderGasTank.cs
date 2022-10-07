using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderGasTank : MonoBehaviour
{
    [SerializeField] private Harvester _harvesterParametr;
    [SerializeField] private MoveHarvester _moveHarvester;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private UIFuelAlarm _fuelAlarm;

    private Slider _slider;
    public UnityAction<float> FuelLevel;
    public UnityAction EndLevel;

    private float _currentValue;
    private float _speedPosition;
    private int _maxValue;
    private int _minValue;
    private bool _drive;

    public void Awake()
    {
        _fuelAlarm.gameObject.SetActive(false);
        _slider = GetComponent<Slider>();
        _minValue = 0;
    }

    private void Start()
    {
        float speed = 0.01f;
        _speedPosition = 1;
        _maxValue = _harvesterParametr.MaxGasLevel;
        _currentValue = _harvesterParametr.GasLevel;
        _slider.value = _currentValue;
        _slider.maxValue = _maxValue;
        _slider.minValue = _minValue;

        StartCoroutine(ChangeLevel(speed));
    }

    public void OnEnable()
    {
        _moveHarvester.Drive += UpdateStatus;
    }

    public void OnDisable()
    {
        _moveHarvester.Drive -= UpdateStatus;
    }

    private void UpdateStatus(float speedPosition)
    {

        _speedPosition = speedPosition;

        if (_speedPosition < 0)
        {
            _speedPosition *= -1;
        }

        if (_speedPosition == 0)
        {
            _drive = false;
        }
        else
        {
            _drive = true;
        }
    }

    private IEnumerator ChangeLevel(float speed)
    {
        while (_currentValue != 0)
        {
            if (_drive == true)
            {
                yield return new WaitForSeconds(Time.fixedDeltaTime);
                _currentValue -= speed * _speedPosition;
            }
            else
            {
                yield return new WaitForSeconds(Time.fixedDeltaTime);
                _currentValue -= speed;
            }

            _slider.value =  Mathf.Clamp(_currentValue,_minValue,_maxValue);
            FuelLevel?.Invoke(_slider.value);
        }

        EndLevel?.Invoke();

        StartCoroutine(AlarmEndFuel());
        StopCoroutine(ChangeLevel(speed));

    }

    private IEnumerator AlarmEndFuel()
    {
        float timeBeforeChangeScene = 3f;

        _fuelAlarm.gameObject.SetActive(true);

        while (timeBeforeChangeScene > 0)
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);
            timeBeforeChangeScene -= Time.fixedDeltaTime;
        }

        _sceneChanger.ChangeScene(1);

        StopCoroutine(AlarmEndFuel());
    }
}
