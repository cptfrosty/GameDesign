using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator _animator;
    private bool IsCheck = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsCheck) return;
        if(collision.TryGetComponent<Player>(out Player player))
        {
            player.SaveNewPos(transform.position + new Vector3(0,0.5f,0));
            IsCheck = true;
            _animator.SetBool("IsCheck", IsCheck);
        }
    }
}
