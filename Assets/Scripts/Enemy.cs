using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Transform _leftCollision;
    [SerializeField] private Transform _rightCollision;
    [SerializeField] private Transform _topCollision;
    [SerializeField] private Transform _downCollision;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private LayerMask _groundLayer;

    private Vector3 _leftCollisionPos, _rightCollisionPos;

    private Rigidbody2D _body;
    private Animator _anim;
    private bool _moveLeft;

    private bool _canMove;
    private bool _stunned;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _leftCollisionPos = _leftCollision.localPosition;
        _rightCollisionPos = _rightCollision.localPosition;
    }

    private void Start()
    {
        _moveLeft = true;
        _canMove = true;
    }

    private void Update()
    {
        if (_canMove)
        {
            if (_moveLeft)
            {
                _body.velocity = new Vector2(-_moveSpeed, _body.velocity.y);
            }
            else
            {
                _body.velocity = new Vector2(_moveSpeed, _body.velocity.y);
            }
        }

        CheckCollision();
    }

    private void CheckCollision()
    {
        RaycastHit2D ground;
        RaycastHit2D player;

        if (_moveLeft)
        {
            ground = Physics2D.Raycast(_leftCollision.position, Vector2.left, 0.1f, _groundLayer);
            player = Physics2D.Raycast(_leftCollision.position, Vector2.left, 0.1f, _playerLayer);
        }
        else
        {
            ground = Physics2D.Raycast(_rightCollision.position, Vector2.right, 0.1f, _groundLayer);
            player = Physics2D.Raycast(_rightCollision.position, Vector2.right, 0.1f, _playerLayer);
        }

        Collider2D topHit = Physics2D.OverlapCircle(_topCollision.position, 0.2f, _playerLayer);

        if (!Physics2D.Raycast(_downCollision.position, Vector2.down, 0.1f) || ground) 
            ChangeDirection();

        if (player) 
            player.transform.GetComponent<Player>().BackToStartPosition();

        if (topHit) 
            Destroy(this.gameObject);
    }

    private void ChangeDirection()
    {
        _moveLeft = !_moveLeft;
        Vector3 tempScale = transform.localScale;
        if (_moveLeft)
        {
            tempScale.x = Mathf.Abs(tempScale.x);

            _leftCollision.localPosition = _leftCollisionPos;
            _rightCollision.localPosition = _rightCollisionPos;
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);

            _leftCollision.localPosition = _rightCollisionPos;
            _rightCollision.localPosition = _leftCollisionPos;
        }

        transform.localScale = tempScale;
    }

    private IEnumerator Dead(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);

    }

    //private void OnTriggerExit2D(Collider2D target)
    //{
    //    if (target.tag == MyTags.BULLET_TAG)
    //    {
    //        if (tag == MyTags.BEETLE_TAG)
    //        {
    //            _anim.Play("Beetle_stunned");
    //            _canMove = false;
    //            _body.velocity = new Vector2(0, 0);

    //            StartCoroutine(Dead(0.4f));
    //        }

    //        if (tag == MyTags.SNAIL_TAG)
    //        {
    //            if (!_stunned)
    //            {
    //                _anim.Play("Snail_stunned");
    //                _stunned = true;
    //                _canMove = false;
    //                _body.velocity = new Vector2(0, 0);
    //            }
    //            else
    //            {
    //                gameObject.SetActive(false);
    //            }
    //        }
    //    }
    //}
}
