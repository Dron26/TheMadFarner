using System.Collections.Generic;
using UnityEngine;

public class ZombiSpawnerHome : MonoBehaviour
{
    [SerializeField] private List<HomeZombi> _zombi;
    [SerializeField] private AttackSelecter _attackSelecter;

    private HomeZombi zombi;
    private Quaternion _quaternion;

    private void Start()
    {     
        _quaternion = Quaternion.identity;
    }

    private void OnEnable()
    {
        _attackSelecter.StartAttack += Spawn;
    }

    private void OnDisable()
    {
        _attackSelecter.StartAttack -= Spawn;
    }

    private void Spawn(List<Vector3> spawnPosition)
    {
        for (int i = 0; i < _zombi.Count; i++)
        {
            zombi = Instantiate(_zombi[i], spawnPosition[i], _quaternion);
            zombi.transform.SetParent(transform);
        }
    }
}
