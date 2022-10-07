using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackSelecter : MonoBehaviour
{
    private List<Vector3> _spawnPosition;
    private Vector3 firstZombiPosition;
    private Vector3 secondZombiPosition;
    
    private float _firstZombiX;
    private float _firstZombiZ;
    private float _secondZombiX;
    private float _secondZombiZ;
    private float _maxWaiteTime;
    private float _minWaiteTime;
    private int _numberField;
    private bool _isAttackStart;
    private bool _isFirstCornFieldUnderAttack;
    private bool _isTomatoUnderAttack;
    private bool _canAttack;
    
    public UnityAction <List<Vector3>> StartAttack;
    public UnityAction  AttackFirstCornField;
    public UnityAction  AttackTomatoField;

    private void Start()
    {
        _isFirstCornFieldUnderAttack = false;
        _isTomatoUnderAttack = false;
        _canAttack = true;
        _spawnPosition =new List<Vector3>();

        firstZombiPosition = new Vector3();
        secondZombiPosition = new Vector3();

        _minWaiteTime = 3;
        _maxWaiteTime = 6;
        _isAttackStart = false;

        StartCoroutine(WaiteBeforAttack());
    }

    private IEnumerator WaiteBeforAttack()
    {
        float waiteTime = Random.Range(_minWaiteTime, _maxWaiteTime);
        float time = 0f;

        while (_isAttackStart == false)
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);
            time += Time.fixedDeltaTime;

            if (time >= waiteTime)
            {
                _isAttackStart = true;

                if (SelectField()==true)
                {
                    StartZombiAttack();
                }
                else
                {
                    StopCoroutine(WaiteBeforAttack());
                    StartCoroutine(WaiteBeforAttack());
                }                          
            }
        }
    }

    private bool  SelectField()
    {   
        if (_numberField == 0 & _isFirstCornFieldUnderAttack == false)
        {
            AttackFirstCornField?.Invoke();
            InitializePositionFirstCornField();
            _isFirstCornFieldUnderAttack = true;
            _canAttack = true;
        }
        else if (_isTomatoUnderAttack == false)
        {
            AttackTomatoField?.Invoke();
            InitializePositionTomatoField();
            _isTomatoUnderAttack = true;
            _canAttack = true;
        }
        else
        {
            _canAttack = false;
        }

        return _canAttack;
    }

    private void StartZombiAttack()
    {
        StartAttack?.Invoke( _spawnPosition);
        _spawnPosition.Clear();

        StopCoroutine(WaiteBeforAttack());
        StartCoroutine(WaiteBeforAttack());
    }

    private void InitializePositionFirstCornField()
    {
        _firstZombiX = 27f;
        _firstZombiZ = -32f;
        _secondZombiX = 48f;
        _secondZombiZ = -41f;

        firstZombiPosition.x = _firstZombiX;
        firstZombiPosition.z = _firstZombiZ;

        secondZombiPosition.x = _secondZombiX;
        secondZombiPosition.z = _secondZombiZ;

        _spawnPosition.Add(firstZombiPosition);
        _spawnPosition.Add(secondZombiPosition);
    }

    private void InitializePositionTomatoField()
    {
        _firstZombiX = -1.6f;
        _firstZombiZ = 30f;

        _secondZombiX = -21.06f;
        _secondZombiZ = 21.88f;

        firstZombiPosition.x = _firstZombiX;
        firstZombiPosition.z = _firstZombiZ;

        secondZombiPosition.x = _secondZombiX;
        secondZombiPosition.z = _secondZombiZ;

        _spawnPosition.Add(firstZombiPosition);
        _spawnPosition.Add(secondZombiPosition);
    }
}
