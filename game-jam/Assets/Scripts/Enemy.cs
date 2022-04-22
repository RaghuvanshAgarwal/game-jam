using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform _targetTransform;
    [SerializeField] int _damageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerController playerController))
        {
            _targetTransform = playerController.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out HealthSystem healthSystem))
        {
            healthSystem.DeductHeath(_damageAmount);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_targetTransform == null) return;
        Vector3 moveDir = (_targetTransform.position - transform.position).normalized;
        transform.position += moveDir * 5 * Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController playerController))
        {
            _targetTransform = null;
        }
    }
}
