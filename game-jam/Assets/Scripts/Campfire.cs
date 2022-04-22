using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    HealthSystem _healthSystem;
    [SerializeField] int _heathAmount;
    [SerializeField] int _maxHeath;
    float _cooldown = 0.1f;
    float _currTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out HealthSystem healthSystem))
        {
            _healthSystem = healthSystem;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_healthSystem == null) return;
        _currTime += Time.deltaTime;
        if (_currTime > _cooldown)
        {
            _currTime = 0;
            _healthSystem.AddHeath(_heathAmount);
            _maxHeath -= _heathAmount;
            if(_maxHeath <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
