using System;
using TMPro;
using UnityEngine;

public class UIEnemyStatus : MonoBehaviour
{
    [SerializeField] private ZombiStatusInformer _zombiStatus;

    private TMP_Text _countZombi;

    private void Awake()
    {
        _countZombi = gameObject.GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _zombiStatus.ChangeZombiCount += UpdateInfo;
    }

    private void OnDisable()
    {
        _zombiStatus.ChangeZombiCount -= UpdateInfo;
    }

    private void UpdateInfo(int count)
    {
        _countZombi.text = Convert.ToString(count);
    }
}
