using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out HealthSystem enemy))
        {
            enemy.DeductHeath(20);
        }
        if(!collision.gameObject.TryGetComponent(out PlayerController controller))
        {
            Destroy(gameObject);
        }
    }

   

    public void Shoot()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * 40;
    }
}
