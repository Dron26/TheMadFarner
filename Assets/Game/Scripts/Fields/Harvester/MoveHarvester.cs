using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]

public class MoveHarvester : MonoBehaviour
{
    [SerializeField] private DriveButton _drive;
    [SerializeField] private RotateButton _rotate;
    [SerializeField] private float _speed;
    [SerializeField] private SliderGasTank _gasTank;

    private Rigidbody _rigidbody;
    private int _angleRotation;
    private int _outputPower;
    private int _numberPosition;
    private int _currentSpeedPosition;
    private bool _isWork;

    public UnityAction<float> Drive;
    public UnityAction Stop;


    private void Start()
    {
        _isWork = true;
        _outputPower = 2;
        _currentSpeedPosition = 0;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rotate.ChangeRotation += OnChangeRotation;
        _drive.ChangeDirection += OnChangeDirection;
        _gasTank.EndLevel += OnEndFuel;
    }

    private void OnDisable()
    {
        _rotate.ChangeRotation -= OnChangeRotation;
        _drive.ChangeDirection -= OnChangeDirection;
        _gasTank.EndLevel -= OnEndFuel;
    }

    private void FixedUpdate()
    {
        if (_isWork)
        {
            Move();
        }
    }

    public void Move()
    {
        if (_currentSpeedPosition != 0)
        {
            int speedturn = 30;
            _rigidbody.velocity = transform.TransformDirection(Vector3.forward * _speed);
            transform.Rotate(Vector3.up * Time.deltaTime * speedturn * _angleRotation);
        }       
    }

    public void OnChangeRotation(int angle)
    {
        _angleRotation = angle;
    }

    private void OnChangeDirection(int direction)
    {
        int minSpeedPosition = -4;
        int maxSpeedPosition = 4;

        _currentSpeedPosition += direction;
        _currentSpeedPosition = Mathf.Clamp(_currentSpeedPosition, minSpeedPosition, maxSpeedPosition);
        _speed = _outputPower * _currentSpeedPosition;
        Drive?.Invoke(_currentSpeedPosition);
    }

    private void OnEndFuel()
    {
        StartCoroutine(StopEngine());
    }

    private IEnumerator StopEngine()
    {
        int speedPosition=3;

        while (_speed > 0)
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);
            _speed -= Time.fixedDeltaTime * speedPosition;
        }

        StopCoroutine(StopEngine());
    }
}


