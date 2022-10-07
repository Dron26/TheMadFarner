using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Harvester : MonoBehaviour
{
    [SerializeField] private Reel _reel;
    [SerializeField] private Wallet _wallet;

    public int Health { get => _health; private set { } }
    public int MaxHealth { get => _maxHealth; private set { } }
    public int MaxGasLevel { get => _maxGasLevel; private set { } }
    public int GasLevel { get => _gasLevel; private set { } }
    public int CountReelsKilledZombi { get => _countReelsKilledZombi; private set { } }

    public UnityAction<List<Item>> BuySparePart;

    private List<Item> _spareParts;
    private int _health;
    private int _maxHealth;
    private int _gasLevel;
    private int _maxGasLevel;
    private int _countReelsKilledZombi;

    private void Awake()
    {
        _maxHealth = 100;
        _maxGasLevel = 100;
        _gasLevel = _maxGasLevel;
    }

    private void OnEnable()
    {
        if (_reel != null)
        {
            _reel.DieZombi += OnKilledZombi;
        }
    }

    private void OnDisable()
    {
        if (_reel != null)
        {
            _reel.DieZombi -= OnKilledZombi;
        }
    }
    public void BuySpareParts(Item sparePart)
    {
        _spareParts = new List<Item>();
        _spareParts.Add(sparePart);

        List<Item> tempSparePart = new List<Item>();

        foreach (var item in _spareParts)
        {
            tempSparePart.Add(item);
        }

        BuySparePart?.Invoke(tempSparePart);
    }

    private void OnKilledZombi()
    {
        _countReelsKilledZombi++;
    }

    public void LoadParametr(int countReelsKilledZombi)
    {
        _countReelsKilledZombi = countReelsKilledZombi;
    }

    public void RemoveFertilizers(int countFertilizers)
    {
        countFertilizers = Mathf.Clamp(countFertilizers, 0, _countReelsKilledZombi);
        _countReelsKilledZombi = -countFertilizers;
    }
}
