using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] int _inflictingDamage = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out HealthSystem heathSystem))
        {
            heathSystem.DeductHeath(_inflictingDamage);
        }
    }
}
