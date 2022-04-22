using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    [SerializeField] float _upwardVelocity;
    [SerializeField] Transform _downPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Rigidbody2D rigidbody2d))
        {
            if (collision.gameObject.transform.position.y < _downPoint.position.y)
            {
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, _upwardVelocity);
            }
        }
    }
}
