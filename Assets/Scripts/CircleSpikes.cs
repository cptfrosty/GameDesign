using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSpikes : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.rotation += _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.BackToStartPosition();
        }
    }
}
