using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public Action<int, bool> OnHeathChanged;
    public Action OnDead;
    [SerializeField] int _maxHeath;
    private int _currentHeath;

    private void Awake()
    {
        _currentHeath = _maxHeath;
    }

    public void AddHeath(int amount)
    {
        _currentHeath += amount;
        _currentHeath = Mathf.Clamp(_currentHeath, 0, _maxHeath);
        OnHeathChanged?.Invoke(_currentHeath, true);
    }

    public void DeductHeath(int amount)
    {
        _currentHeath -= amount;
        _currentHeath = Mathf.Clamp(_currentHeath, 0, _maxHeath);
        OnHeathChanged?.Invoke(_currentHeath,false);

        if (IsDead())
        {
            OnDead?.Invoke();
        }    
    }


    private bool IsDead() => _currentHeath == 0;
    private int GetCurrentHeath() => _currentHeath;
    public float GetCurrentHeathNormalized() => _currentHeath / (float)_maxHeath;
    private void RefillHeath()
    {
        _currentHeath = _maxHeath;
        OnHeathChanged?.Invoke(_currentHeath, true);
    }

}
