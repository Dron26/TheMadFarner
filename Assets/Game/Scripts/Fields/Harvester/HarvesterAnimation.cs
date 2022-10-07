using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MoveHarvester))]

public class HarvesterAnimation : MonoBehaviour
{
    [SerializeField] private ReelButton _reelButton;
    [SerializeField] private Animator _animator;

    private MoveHarvester _moveHarvester;
    public UnityAction EndChangeRotation;

    private int _speedCashName;
    private int _reversCashName;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _moveHarvester = GetComponent<MoveHarvester>();
        _speedCashName = Animator.StringToHash("Speed");
        _reversCashName = Animator.StringToHash("Revers");
    }

    private void OnEnable()
    {
        _moveHarvester.Drive += OnDrive;
    }

    private void OnDisable()
    {
        _moveHarvester.Drive -= OnDrive;
    }

    private void OnDrive(float speed)
    {
        if (speed < 0)
        {
            float reversSpeed = speed * -1;
            int speedRotation = 14;
            _animator.SetFloat(_reversCashName, reversSpeed / speedRotation);
        }
        else
        {
            int speedRotation = 12;
            _animator.SetFloat(_speedCashName, speed / speedRotation);
        }
    }
}
