using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherEnemy : MonoBehaviour
{
    [SerializeField] float _spawnRate = 1;
    [SerializeField] GameObject _pfEnemy;
    private bool _isInsideSphere = false;

    private void OnEnable()
    {
        
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (_isInsideSphere)
        {
            yield return new WaitForSeconds(_spawnRate);
            Vector2 _spawnPoint = (Vector2)transform.position + (Random.insideUnitCircle * 10);
            Instantiate(_pfEnemy, _spawnPoint, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerController controller))
        {
            _isInsideSphere = true;
            StartCoroutine(SpawnEnemyCoroutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController controller))
        {
            _isInsideSphere = false;
            StopCoroutine(SpawnEnemyCoroutine());
        }
    }
}
