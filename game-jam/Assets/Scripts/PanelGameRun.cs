using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameRun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private HealthSystem _playerHeathSystem;
    [Header("Visual")]
    [SerializeField] Gradient _playerHealthGradient;
    [SerializeField] Image _heathFiller;

    private void OnEnable()
    {
        _playerHeathSystem.OnHeathChanged += Player_HealthChanged;
    }

    private void OnDisable()
    {
        _playerHeathSystem.OnHeathChanged -= Player_HealthChanged;
    }

    private void Player_HealthChanged(int amount, bool didIncreased)
    {
        _heathFiller.color =  _playerHealthGradient.Evaluate(_playerHeathSystem.GetCurrentHeathNormalized());
        _heathFiller.fillAmount = _playerHeathSystem.GetCurrentHeathNormalized();
    }
}
