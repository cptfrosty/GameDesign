using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Transform _groundCheckPosition;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _body;
    private Animator _anim;

    private bool _isGrounded;
    private bool _jumped;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        CheckIfGround();
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float inputH = Input.GetAxisRaw("Horizontal");
        _body.velocity = new Vector2(_speed * inputH, _body.velocity.y);
        _anim.SetInteger("speed", Mathf.Abs((int)inputH));

        if (inputH > 0) ChangeDirection(1);
        if (inputH < 0) ChangeDirection(-1);
    }

    private void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    private void CheckIfGround()
    {
        _isGrounded = Physics2D.Raycast(_groundCheckPosition.position, Vector2.down, 0.1f, _groundLayer);
        if (_isGrounded)
        {
            if (_jumped)
            {
                _jumped = false;
                _anim.SetBool("jump", false);
            }
        }
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _jumped = true;
                _body.velocity = new Vector2(_body.velocity.x, _jumpForce);
                _anim.SetBool("jump", true);
            }
        }
    }
}
