using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Reel : MonoBehaviour
{
    [SerializeField] private ReelButton _reelButton;

    private Vector3 _rotation;
    private CapsuleCollider _collider;
    private float _speedRotationReelY;
    private float _maxSpeedRotationReel;
    private float _speedAcceleration;
    private bool _isActive;
    private bool _isWork;

    public UnityAction DieZombi;
    public UnityAction EndChangeRotation;
    public UnityAction HarvestedPlant;

    private void Awake()
    {
        _speedAcceleration = 1.5f;
        _maxSpeedRotationReel = 250f;
        _isActive = false;
        _collider = GetComponent<CapsuleCollider>();
        _collider.enabled = _isActive;
        _speedRotationReelY = 100f;
        _rotation = new Vector3(0, _speedRotationReelY, 0);
    }

    private void OnEnable()
    {
        if (_reelButton != null)
        {
            _reelButton.ReelActive += OnReelActive;
        }
    }

    private void OnDisable()
    {
        if (_reelButton != null)
        {
            _reelButton.ReelActive += OnReelActive;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Zombi zombi))
        {
            DieZombi?.Invoke();
        }
        if (other.TryGetComponent(out Plant plant))
        {
            HarvestedPlant?.Invoke();
        }
    }

    private void OnReelActive()
    {
        _isActive = !_isActive;

        if (_isActive == true)
        {

            StartCoroutine(ChangeUpSpeedRotation());
        }
        else
        {
            StartCoroutine(ChangeDownSpeedRotation());
        }
    }

    private IEnumerator ChangeUpSpeedRotation()
    {
        while (_speedRotationReelY < _maxSpeedRotationReel)
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);

            _speedRotationReelY += _speedAcceleration;
            _rotation.y = _speedRotationReelY;
            transform.Rotate(_rotation * Time.fixedDeltaTime);
        }

        if (_speedRotationReelY >= _maxSpeedRotationReel)
        {
            EndChangeRotation?.Invoke();
            _collider.enabled = _isActive;
            _isWork = true;
            StartCoroutine(RotateReel());
            StopCoroutine(ChangeUpSpeedRotation());
        }
    }

    private IEnumerator ChangeDownSpeedRotation()
    {
        while (_speedRotationReelY > 0)
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);
            _speedRotationReelY -= _speedAcceleration;
            _rotation.y = _speedRotationReelY;

            if (_speedRotationReelY <= 0)
            {
                _speedRotationReelY = 0;
                _collider.enabled = _isActive;
                EndChangeRotation?.Invoke();
                _isWork = false;
                StopCoroutine(RotateReel());
                StopCoroutine(ChangeUpSpeedRotation());
            }
        }
    }

    private IEnumerator RotateReel()
    {
        while (_isWork == true)
        {
            transform.Rotate(_rotation * Time.fixedDeltaTime);
            yield return null;
        }
    }
}

