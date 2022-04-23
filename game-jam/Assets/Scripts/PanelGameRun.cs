using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGameRun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private HealthSystem _playerHeathSystem;
    [SerializeField] private KeySystem _keySystem;
    [Header("Visual")]
    [SerializeField] Gradient _playerHealthGradient;
    [SerializeField] Image _heathFiller;
    [SerializeField] Image _silverKey;
    [SerializeField] Image _goldKey;
    [SerializeField] Image _platinumKey;

    private void OnEnable()
    {
        _playerHeathSystem.OnHeathChanged += Player_HealthChanged;
        _keySystem.OnKeyAdded += OnKeyAdded;
    }

    

    private void OnDisable()
    {
        _playerHeathSystem.OnHeathChanged -= Player_HealthChanged;
        _keySystem.OnKeyAdded -= OnKeyAdded;
    }

    private void Player_HealthChanged(int amount, bool didIncreased)
    {
        _heathFiller.color =  _playerHealthGradient.Evaluate(_playerHeathSystem.GetCurrentHeathNormalized());
        _heathFiller.fillAmount = _playerHeathSystem.GetCurrentHeathNormalized();
    }

    private void OnKeyAdded(eKeyType obj)
    {
        switch (obj)
        {
            case eKeyType.SILVER:
                _silverKey.gameObject.SetActive(true);
                break;
            case eKeyType.GOLD:
                _goldKey.gameObject.SetActive(true);
                break;
            case eKeyType.PLATINUM:
                _platinumKey.gameObject.SetActive(true);
                break;
        }
    }
}
