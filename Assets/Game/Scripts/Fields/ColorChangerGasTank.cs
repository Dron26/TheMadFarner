using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ColorChangerGasTank : MonoBehaviour
{
    [SerializeField] private SliderGasTank _sliderGasTank;

    private int _fuelLevelNameHash;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _fuelLevelNameHash = Animator.StringToHash("FuelLevel");
    }

    private void OnEnable()
    {
        _sliderGasTank.FuelLevel += OnChangeGasLevel;
    }

    private void OnDisable()
    {
        _sliderGasTank.FuelLevel -= OnChangeGasLevel;
    }

    private void OnChangeGasLevel(float level)
    {
        _animator.SetFloat(_fuelLevelNameHash, level);
    }
}
