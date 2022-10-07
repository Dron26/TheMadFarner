using System.Collections.Generic;
using UnityEngine;

public class SpawnerZombi : MonoBehaviour
{
    public int MaxCount { get; private set; }

    [SerializeField] private List<Zombi> _zombi;
    [SerializeField] private int _maxCount;
    [SerializeField] private Harvester _harvester;

    private AIMovement _movement;
    private Vector3 createZombiPosition;
    private Quaternion _quaternion;
    private Zombi zombi;

    private float _currentposX;
    private float _currentposZ;
    private float _maxPositionX;
    private float _maxPositionZ;
    private float _minPositionX;
    private float _minPositionZ;


    private void Awake()
    {
        MaxCount = _maxCount;
        _quaternion = Quaternion.identity;
        _maxPositionX = 130;
        _maxPositionZ = 100;
        _minPositionX = -130;
        _minPositionZ = -30;
        PlacementPlant();
    }

    public void PlacementPlant()
    {
        for (int i = 0; i < _maxCount; i++)
        {
            _currentposX = Random.Range(_minPositionX, _maxPositionX);
            _currentposZ = Random.Range(_minPositionZ, _maxPositionZ);

            createZombiPosition.x = _currentposX;
            createZombiPosition.z = _currentposZ;

            zombi = Instantiate(_zombi[Random.Range(0, _zombi.Count)], createZombiPosition, _quaternion);
            zombi.transform.SetParent(transform);

            _movement = zombi.GetComponent<AIMovement>();
            _movement.SetTarget(_harvester.transform);
        }
    }
}
