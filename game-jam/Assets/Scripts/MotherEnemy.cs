using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherEnemy : MonoBehaviour
{
    [SerializeField] float _spawnRate = 1;
    [SerializeField] GameObject _pfEnemy;
    [SerializeField] float radius;

    private float _currTime;
    private PlayerController playerController;

    public void Start()
    {
        playerController = Global.Instance.GetPlayerController();
        _currTime = 0;
    }
    private void Update()
    {
        if(Vector3.Distance(playerController.transform.position, transform.position) < radius)
        {
            if(_currTime > _spawnRate)
            {
                _currTime = 0;
                Vector2 _spawnPoint = (Vector2)transform.position + (Random.insideUnitCircle * 10);
                Instantiate(_pfEnemy, _spawnPoint, Quaternion.identity);
            }
        }
        _currTime += Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
