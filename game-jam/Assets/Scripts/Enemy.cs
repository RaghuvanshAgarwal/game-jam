using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _damageAmount;
    [SerializeField] float radius;
    private PlayerController playerController;

    public void Start()
    {
        playerController = Global.Instance.GetPlayerController();
        GetComponent<HealthSystem>().OnDead += OnDead;
    }

    private void OnDead()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Vector3.Distance(playerController.transform.position, transform.position) < radius)
        {
            float xDiff = transform.position.x - playerController.transform.position.x;
            if(xDiff > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);

            }
            Vector3 moveDir = (playerController.transform.position - transform.position).normalized;
            transform.position += moveDir * 5 * Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerController playerController))
        {
            playerController.GetComponent<HealthSystem>().DeductHeath(_damageAmount);
            Destroy(gameObject);
        }
    }
}
