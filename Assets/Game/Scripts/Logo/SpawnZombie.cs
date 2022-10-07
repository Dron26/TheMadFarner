using System.Collections;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] private Zombie2D _zombie2D;

    private WaitForSeconds _timer;
    private Vector3 _zombiePosition;
    private Vector3 _zombieRotation;
    private Quaternion _startRotation;
    private int _maxCount;
    private float _time;
    private float _maxStep;

    private void Awake()
    {
        _maxStep = 3;
        _maxCount = 2;
        _zombiePosition = transform.position;
        _zombieRotation = new Vector3(0, -90, 0);
        _time = 1.15f;
        _timer = new WaitForSeconds(_time);

    }

    private void Start()
    {
        StartCoroutine(PlacementZombie());
    }

    private IEnumerator PlacementZombie()
    {
        int step =0;

        while (step < _maxCount)
        {
            for (; step < _maxCount; step ++)
            {
                float stepX = Random.Range(0, _maxStep);
                _zombiePosition.x += stepX;
                _startRotation = Quaternion.Euler(_zombieRotation);
                Zombie2D _zombie = Instantiate(_zombie2D, _zombiePosition, _startRotation);
                _zombie.transform.SetParent(transform);
                yield return _timer;
            }
        }           
    }
}