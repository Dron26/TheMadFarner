using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Zombie2D : MonoBehaviour
{
    Animator _animator;
    public static readonly int IsZombie = Animator.StringToHash("IsZombie");
   
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(IsZombie, true);
    }

    private void Start()
    {
        SetAnimation();
    }

    private void SetAnimation()
    {       
        int percentChance=5;
        int random = Random.Range(0, percentChance);

        if (random < 3)
        {
            _animator.SetBool(IsZombie, false);
        }
    }
}
