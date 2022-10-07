using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Zombi : MonoBehaviour
{
    [SerializeField] private ParticleSystem _fXExplosionBody;
    [SerializeField ]private  SkinnedMeshRenderer _meshRenderer;

    private ParticleSystem _particle;
    private Quaternion _quaternion;
    private Animator _animator;
    private int IsTakeHitHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        IsTakeHitHash = Animator.StringToHash("IsTakeHit");
        _quaternion = Quaternion.identity;
        _meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ViewingRadius>(out ViewingRadius radius))
        {
            _meshRenderer.enabled = true;
        }
        else if(other.TryGetComponent<Reel>(out Reel harvesterReel))
        {
            InstantiateExplosion();
            Destroy(gameObject);
        }
        else if (other.TryGetComponent<HarvesterBody>(out HarvesterBody harvesterBody))
        {
            _animator.SetBool(IsTakeHitHash, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ViewingRadius>(out ViewingRadius radius))
        {
            _meshRenderer.enabled = false;
        }
    }


    public void InstantiateExplosion()
    {
        _particle = Instantiate(_fXExplosionBody, transform.position, _quaternion);        
    }

    public void StendUp()
    {
        _animator.SetBool(IsTakeHitHash, false);
    }
}