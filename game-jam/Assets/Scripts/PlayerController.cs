using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _horizontalSpeed;
    [SerializeField] float _jumpVelocity;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] float _checkWidth;
    [SerializeField] float _checkHeight;
    [SerializeField] Transform _checkTransform;
    Rigidbody2D _rigidbody2D;
    HealthSystem _heathSystem;
    float _horizontalInput;
    bool _jumping;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _heathSystem = GetComponent<HealthSystem>();
        _heathSystem.OnHeathChanged += HealthSystem_OnHealthChanged;
    }

    private void HealthSystem_OnHealthChanged(int health, bool didIncreased)
    {
        Debug.Log(health);
    }

    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && IsGround())
        {
            _jumping = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 playerVelocity = _rigidbody2D.velocity;
        if (IsGround())
        {
            playerVelocity.x = _horizontalInput * _horizontalSpeed;
            if(Mathf.Abs(_horizontalInput) > 0)
            {
                HandleRotation();
            }
        }
        if (_jumping)
        {
            _jumping = false;
            playerVelocity.y = _jumpVelocity;
        }
        VariableGravity();
        _rigidbody2D.velocity = playerVelocity;
    }

    Collider2D[] colliders;
    private bool IsGround()
    {
        colliders = Physics2D.OverlapBoxAll(_checkTransform.position, new Vector2(_checkWidth, _checkHeight),0f, _groundLayer);
        return colliders.Length > 0;
    }

    private void VariableGravity()
    {
        if (!IsGround())
        {
            Vector2 velocity = _rigidbody2D.velocity;
            if(velocity.y > 0)
            {
                _rigidbody2D.gravityScale = 4;
            }
            else
            {
                _rigidbody2D.gravityScale = 6;
            }
        }
    }

    private void HandleRotation()
    {
        if(_horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.up * -180);
        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }


    private void OnDrawGizmos()
    {
        if (_checkTransform != null)
        {
            Gizmos.DrawWireCube(_checkTransform.position, new Vector3(_checkWidth, _checkHeight, 1));
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            SceneManager.LoadScene(0);
        }
    }

}
