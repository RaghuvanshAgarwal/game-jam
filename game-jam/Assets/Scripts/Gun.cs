using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GameObject pfBullet;
    [SerializeField] Transform _spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(pfBullet, _spawnPoint.position, Quaternion.identity);
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<Bullet>().Shoot();
        }
    }
}
