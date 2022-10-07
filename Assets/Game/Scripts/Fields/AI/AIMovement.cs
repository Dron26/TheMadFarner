using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AIMovement : MonoBehaviour
{
    private Vector3 _vector;
    private Vector3 _vectorForRun;
    private NavMeshAgent _agent;
    private Transform _harvesterTransform;
    private Animator _animator;
    private float _timer = 0.0f;
    private float maxTime = 1.0f;
    private float maxDistance = 15.0f;
    private float speed;
    private int speedHash;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        speedHash = Animator.StringToHash("Speed");
    }

    void Start()
    {
        _vector=transform.position;       
    }

    // Update is called once per frame
    void Update()
    {
        speed = _agent.velocity.magnitude;
        _timer -=Time.deltaTime;
        _animator.SetFloat(speedHash, speed);

        if (_timer < 0.0f)
        {
            float sqDistance = (_harvesterTransform.position - _agent.destination).sqrMagnitude;

            if (sqDistance < maxDistance * maxDistance)
            {
                SelectPoint();
            }
            _timer = maxTime;

            _animator.SetFloat(speedHash, 0);

        }
        if (_vector == _vectorForRun)
        {
            _animator.SetFloat(speedHash, _agent.velocity.magnitude);
        }
    }

    private void SelectPoint()
    {
        float maxDistanceZ = 30.0f;
        float maxDistanceX = 25.0f;
        float minDistanceZ = 15.0f;
        float minDistanceX = -30.0f;

        Vector3 Z = Vector3.forward * (_vector.z + Random.Range(minDistanceZ, maxDistanceZ));
        Vector3 X= Vector3.right * (_vector.x + Random.Range(minDistanceX, maxDistanceX));
        _vectorForRun = new Vector3 (X.x, 0, Z.z);
        transform.LookAt(_vectorForRun);

        _agent.destination = _vectorForRun;
        _animator.SetFloat(speedHash, speed);
    }

    public void SetTarget(Transform transform)
    {
        _harvesterTransform = transform;
    }
}
