using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private bool _isFollow;

    //От 0 до 1
    private float _maxX = 0.7f;
    private float _minX = 0.3f;
    private float _maxY = 0.6f;
    private float _minY = 0.4f;

    private Transform _targetPlayer;
    private void Start()
    {
        _targetPlayer = GameObject.FindObjectOfType<Player>().transform;
    }

    private void LateUpdate()
    {
        if (!_isFollow) return;

        Vector2 posPlayerCam = Camera.main.WorldToViewportPoint(_targetPlayer.position);
        bool resultFollowPos = posPlayerCam.x > _maxX || posPlayerCam.x < _minX ||
                               posPlayerCam.y > _maxY || posPlayerCam.y < _minY;
        if (resultFollowPos)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, _targetPlayer.position, 0.5f);
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
    }
}
