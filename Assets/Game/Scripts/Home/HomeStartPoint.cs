using UnityEngine;

public class HomeStartPoint : MonoBehaviour
{
    [SerializeField] private Load _load;
    [SerializeField] private Save _save;

    private void Awake()
    {
        _load.StartHomeScene();
        _load.LoadData();
        _save.ExitHomeScene();  
    }
}
