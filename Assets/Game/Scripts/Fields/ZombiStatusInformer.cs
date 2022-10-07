using UnityEngine;
using UnityEngine.Events;

public class ZombiStatusInformer : MonoBehaviour
{
    [SerializeField] private Reel _reel;
    
    public int countZombi { get; private set; }

    private SpawnerZombi _spawnerZombi;

    public UnityAction<int> ChangeZombiCount;

    void Awake()
    {
        _spawnerZombi =GetComponent<SpawnerZombi>();
        countZombi = _spawnerZombi.MaxCount;          
    }

    private void Start()
    {
        ChangeZombiCount?.Invoke(countZombi);
    }

    private void OnEnable()
    {
        _reel.DieZombi += OnDieZombi;
    }

    private void OnDisable()
    {
        _reel.DieZombi -= OnDieZombi;
    }

    private void OnDieZombi()
    {
        countZombi--;
        ChangeZombiCount?.Invoke(countZombi);
    }
}
