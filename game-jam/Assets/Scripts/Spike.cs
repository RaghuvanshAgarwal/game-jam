using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] Rigidbody2D _obstacleRigibbody;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerController controller))
        {
            _obstacleRigibbody.isKinematic = false;
        }
    }
}
