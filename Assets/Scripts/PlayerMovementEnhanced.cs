using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovementEnhanced : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private new Rigidbody2D rigidbody2D;

    [SerializeField] private LayerMask _layerMask;
    

    [Header("Parameters")]
    [SerializeField]
    private float speed;

    [SerializeField] private float jumpForce;
    [SerializeField] private float maxJumpForce;

    private float _currentJumpForce;
    private bool _canJump;

    private void Start()
    {
        _canJump = true;
        _currentJumpForce = 0f;
    }

    private void Update()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, .5f, LayerMask.GetMask("Ground"));
        Debug.DrawRay(transform.position, Vector2.down, Color.yellow);
        // Debug.DrawLine(transform.position, hit.point, Color.red);

        if (hit.collider)
        {
            Debug.Log($"{hit.collider.name} collision");
        }
        
        Move();

        if (Input.GetButton("Jump") && _canJump)
        {
            AccelerateJump();
        }

        if (Input.GetButtonUp("Jump") && _canJump)
        {
            Jump();
        }
    }

    private void Move()
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        rigidbody2D.linearVelocity = new Vector2(inputX * speed, rigidbody2D.linearVelocity.y);
    }

    private void AccelerateJump()
    {
        if (_currentJumpForce <= maxJumpForce)
        {
            _currentJumpForce += (Time.deltaTime * jumpForce);
        }
    }

    private void Jump()
    {
        rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, _currentJumpForce);
        _canJump = false;
        _currentJumpForce = 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            //checks contact surface.
            Vector3 normal = collision.contacts[0].normal;
            if (normal == Vector3.up)
            {
                _canJump = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            _canJump = false;
        }
    }
}