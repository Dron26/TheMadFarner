using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class Plant : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Reel>(out Reel harvesterReel))
        {
            Destroy(gameObject);
        }
        else if (other.TryGetComponent<ViewingRadius>(out ViewingRadius radius))
        {
            _meshRenderer.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ViewingRadius>(out ViewingRadius radius))
        {
            _meshRenderer.enabled = false;
        }
    }
}
