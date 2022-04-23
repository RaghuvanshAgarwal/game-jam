using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out KeySystem keySystem))
        {
            if(keySystem.KeyCount == 3)
            {
                Destroy(gameObject);
            }
        }
    }
}
