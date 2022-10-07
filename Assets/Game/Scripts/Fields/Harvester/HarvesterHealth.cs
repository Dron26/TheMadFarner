using UnityEngine;
using UnityEngine.Events;

public class HarvesterHealth : MonoBehaviour
{
    public int Health { get => _currentHealth; }
    public int MaxHealth { get => _maxHealth; }


    private Harvester _harvesterParametr;
    private int _maxHealth;
    private int _currentHealth;
    private int _minHealth = 0;

    public UnityAction Dead;
    public UnityAction<int> ChangeHealth;

    private void Start()
    {
        _harvesterParametr = GetComponent<Harvester>();
        _maxHealth = _harvesterParametr.MaxHealth;
        _currentHealth = _harvesterParametr.Health;
    }

    public virtual void AddHealth(int value)
    {
        int tempHealth = _currentHealth;
        tempHealth += value;
        _currentHealth = Mathf.Clamp(tempHealth, _minHealth, _maxHealth);

        ChangeHealth?.Invoke(_currentHealth);
    }

    public void RemoveHealth(int value)
    {
        int tempHealth = _currentHealth;
        tempHealth -= value;
        _currentHealth = Mathf.Clamp(tempHealth, _minHealth, _maxHealth);

        ChangeHealth?.Invoke(_currentHealth);

        if (_currentHealth == _minHealth)
        {
            Dead?.Invoke();
        }
    }
}