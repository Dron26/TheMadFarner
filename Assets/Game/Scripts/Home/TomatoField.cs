using UnityEngine;

public class TomatoField : MonoBehaviour
{
    [SerializeField] private AttackSelecter _attackSelecter;

    private int _isAttackTomatoField;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _isAttackTomatoField = Animator.StringToHash("Attack");
        _animator.SetBool(_isAttackTomatoField, false);
    }

    private void OnEnable()
    {
        _attackSelecter.AttackTomatoField += OnAttackTomatoField;
    }

    private void OnDisable()
    {
        _attackSelecter.AttackTomatoField -= OnAttackTomatoField;
    }

    public void OnAttackTomatoField()
    {
        _animator.SetBool(_isAttackTomatoField, true);
    }
}
