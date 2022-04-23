using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] eKeyType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out KeySystem controller))
        {
            controller.AddKey(type);
            Destroy(gameObject);
        }
    }
}
