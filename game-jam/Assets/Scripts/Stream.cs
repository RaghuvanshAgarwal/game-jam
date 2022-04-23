using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    [SerializeField] float _upwardVelocity;
    [SerializeField] Transform _downPoint;
    [SerializeField] BoxCollider2D _boxCollider;
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube((Vector2)transform.position + _boxCollider.offset, _boxCollider.size);
    }
}
