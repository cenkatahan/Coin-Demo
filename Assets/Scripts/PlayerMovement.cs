using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private new Rigidbody2D rigidbody2D;
    
    [Header("Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
    private bool _isGrounded;

    private void Start()
    {
        // _isGrounded = rigidbody2D.gravityScale > 0;
        _isGrounded = true;
    }

    private void Update()
    {
        if (_isGrounded)
        {
            Move();
        } 
        
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jump();
        }
    }

    private void Move()
    {
        var inputX = Input.GetAxisRaw("Horizontal");
        rigidbody2D.linearVelocity = new Vector2(inputX * speed, rigidbody2D.linearVelocity.y);
        _isGrounded = true;
    }

    private void Jump()
    {
        _isGrounded = false;
        rigidbody2D.linearVelocity = new Vector2(rigidbody2D.linearVelocity.x, jumpForce);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            _isGrounded = true;
        }
    }
}
