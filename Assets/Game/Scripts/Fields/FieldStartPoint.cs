using UnityEngine;

public class FieldStartPoint : MonoBehaviour
{
    [SerializeField] private Load _load;
    [SerializeField] private Save _save;

    private void Awake()
    {
        _load.StartFieldScene();
        _load.LoadData();
        _save.ExitFieldScene();
    }
}
