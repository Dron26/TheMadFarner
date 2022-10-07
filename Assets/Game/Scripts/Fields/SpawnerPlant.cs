using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlant : MonoBehaviour
{

    [SerializeField] private List<Plant> _propPlants;
    [SerializeField] private float maxSizeX;
    [SerializeField] private float maxSizeZ;

    private Vector3 _wheatPosition;
    private Vector3 _rotation;
    private Quaternion _startRotation;
    private Plant _plant;
    private float _step;
    private float _maxAngle;
    private float _angle;
    private float _currentposX;
    private float _currentposZ;
    private int _numberSelectField;

    private void Awake()
    {
        _wheatPosition=transform.position;
        _currentposX= _wheatPosition.x;
        _currentposZ = _wheatPosition.z;
        _step = 2;
        _maxAngle = 100;
    }

    private void Start()
    {
        PlacementPlant();
    }

    public void PlacementPlant()
    {
        for (float stepZ = 0; stepZ < maxSizeZ; stepZ+= _step)
        {
            for (float stepX = 0; stepX < maxSizeX; stepX += _step)
            {           
                _wheatPosition.x += _step;
                _angle = Random.Range(0, _maxAngle);
                _rotation = new Vector3(0, _angle, 0);
                _startRotation = Quaternion.Euler(_rotation);
                _plant = Instantiate(_propPlants[_numberSelectField], _wheatPosition, _startRotation);
                _plant.transform.SetParent(transform);
            }

            _wheatPosition.x = _currentposX;
            _wheatPosition.z += _step;
        }  
    }

    public void LoadParametr(int numberSelectField)
    {
        _numberSelectField = numberSelectField;
        PlacementPlant();
    }
}
