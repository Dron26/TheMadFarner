using UnityEngine;

public class CornFirstField : MonoBehaviour
{
    [SerializeField] private AttackSelecter _attackSelecter;

    private int _isAttackFirstCornHash;
    private Animator _animator;

    private void Awake()
    {
        _animator=GetComponent<Animator>();
        _isAttackFirstCornHash = Animator.StringToHash("Attack");
        _animator.SetBool(_isAttackFirstCornHash, false);
    }

    private void OnEnable()
    {
        _attackSelecter.AttackFirstCornField += OnAttackFirstCornField;
    }

    private void OnDisable()
    {
        _attackSelecter.AttackFirstCornField -= OnAttackFirstCornField;
    }

    public void OnAttackFirstCornField()
    {
        _animator.SetBool(_isAttackFirstCornHash, true);
    }
}
